# We strongly recommend using the required_providers block to set the
# Azure Provider source and version being used
terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "=4.15.0"
    }
  }
}

# Configure the Microsoft Azure Provider
provider "azurerm" {
  features {}
  subscription_id = "{azure_subscription_id}"
}

resource "azurerm_resource_group" "example" {
  name     = "rg-jobs-test-resources"
  location = "West Europe"
}

resource "azurerm_log_analytics_workspace" "example" {
  name                = "example-log-analytics-workspace"
  location            = azurerm_resource_group.example.location
  resource_group_name = azurerm_resource_group.example.name
  sku                 = "PerGB2018"
  retention_in_days   = 30
}

resource "azurerm_container_app_environment" "example" {
  name                       = "example-container-app-environment"
  location                   = azurerm_resource_group.example.location
  resource_group_name        = azurerm_resource_group.example.name
  log_analytics_workspace_id = azurerm_log_analytics_workspace.example.id
}

resource "azurerm_servicebus_namespace" "example" {
  name                = "sb-aca-jobs-demo-101010"
  location            = azurerm_resource_group.example.location
  resource_group_name = azurerm_resource_group.example.name
  sku                 = "Standard"
}

resource "azurerm_servicebus_topic" "example" {
  name                = "example-servicebus-topic"
  namespace_id        = azurerm_servicebus_namespace.example.id
}

resource "azurerm_servicebus_subscription" "example" {
  name                = "example-subscription"
  topic_id            = azurerm_servicebus_topic.example.id
  max_delivery_count  = 10
  lock_duration       = "PT5M"
}

# Service Bus Queue
resource "azurerm_servicebus_queue" "example" {
  name                = "example-servicebus-queue"
  namespace_id        = azurerm_servicebus_namespace.example.id
}


resource "azurerm_container_app_job" "example" {
  name                         = "example-container-app-job"
  location                     = azurerm_resource_group.example.location
  resource_group_name          = azurerm_resource_group.example.name
  container_app_environment_id = azurerm_container_app_environment.example.id

  replica_timeout_in_seconds = 400
  replica_retry_limit        = 10

  event_trigger_config {

    parallelism = 2
    replica_completion_count = 5
    
    scale {
      polling_interval_in_seconds = 10
      rules {
        name = "scale-up"
        custom_rule_type = "azure-servicebus"
        metadata = {
          topicName        = azurerm_servicebus_topic.example.name
          subscriptionName = azurerm_servicebus_subscription.example.name
          connectionFromEnv = "con-string-secret"
          namespace = azurerm_servicebus_namespace.example.name
        }
        authentication {
            secret_name = "con-string-secret"
            trigger_parameter = "connection"
        }
      }
    }
  }

  registry {
    server             = "{container_registry_name}.azurecr.io"
    username           = "{container_registry_name}"
    password_secret_name = "registry-password"
  }

  secret {
    name  = "registry-password"
    value = "{registry_password}"
  }

  secret {
    name  = "con-string-secret"
    value = azurerm_servicebus_namespace.example.default_primary_connection_string
  }

  template {
    container {
      image = "{container_registry_name}.azurecr.io/sample-app:v1"
      name  = "testcontainerappsjob0"

      cpu    = 0.5
      memory = "1Gi"
      
      env {
        name  = "SERVICEBUS_CONNECTION_STRING"
        value = azurerm_servicebus_namespace.example.default_primary_connection_string
      }
      env {
        name  = "SERVICEBUS_TOPIC_NAME"
        value = azurerm_servicebus_topic.example.name
      }
      env {
        name  = "SERVICEBUS_SUBSCRIPTION_NAME"
        value = azurerm_servicebus_subscription.example.name
      }
    
    }
    
  }
}


# Job to Listen to Service Bus Queue
resource "azurerm_container_app_job" "queue_listener" {
  name                         = "queue-listener-job"
  location                     = azurerm_resource_group.example.location
  resource_group_name          = azurerm_resource_group.example.name
  container_app_environment_id = azurerm_container_app_environment.example.id

  replica_timeout_in_seconds = 120
  replica_retry_limit        = 10

  event_trigger_config {
    scale {
      polling_interval_in_seconds = 10
      rules {
        name             = "scale-up"
        custom_rule_type = "azure-servicebus"
        metadata = {
          queueName         = azurerm_servicebus_queue.example.name
          connectionFromEnv = "queue-con-string-secret"
          namespace         = azurerm_servicebus_namespace.example.name
        }
        authentication {
          secret_name       = "queue-con-string-secret"
          trigger_parameter = "connection"
        }
      }
    }
  }

  registry {
    server             = "{container_registry_name}.azurecr.io"
    username           = "{container_registry_name}"
    password_secret_name = "registry-password"
  }

  secret {
    name  = "registry-password"
    value = "{registry_password}"
  }

  secret {
    name  = "queue-con-string-secret"
    value = azurerm_servicebus_namespace.example.default_primary_connection_string
  }

  template {
    container {
      image = "{container_registry_name}.azurecr.io/sample-app:v1"
      name  = "queue-listener"
      cpu   = 0.5
      memory = "1Gi"
      env {
        name  = "SERVICEBUS_QUEUE_NAME"
        value = azurerm_servicebus_queue.example.name
      }
    }
  }
}