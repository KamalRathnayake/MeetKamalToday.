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
  subscription_id = "7ef6d74d-ee59-4831-b41e-6a5c3e6e3995"
}

data "azurerm_resource_group" "example" {
  name     = "rg-container-apps-jobs"
}

data "azurerm_container_app_environment" "example" {
  name                       = "cae-jobs-demo-01"
  resource_group_name        = data.azurerm_resource_group.example.name
}

resource "azurerm_container_app_job" "example" {
  name                         = "example-container-app-job"
  location                     = data.azurerm_resource_group.example.location
  resource_group_name          = data.azurerm_resource_group.example.name
  container_app_environment_id = data.azurerm_container_app_environment.example.id

  replica_timeout_in_seconds = 10
  replica_retry_limit        = 10
  manual_trigger_config {
    parallelism              = 4
    replica_completion_count = 1
  }

  template {
    container {
      image = "mkt01.azurecr.io/sample-app:v1"
      name  = "testcontainerappsjob0"

      cpu    = 0.5
      memory = "1Gi"
    }
  }
}