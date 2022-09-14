# configure providers
terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "~> 3.22.0"
    }

    azapi = {
      source  = "Azure/azapi"
      version = "~>0.5.0"
    }
  }
  
  # backend "azurerm" {
  #   resource_group_name  = "TFStorage"
  #   storage_account_name = "tfdata1000"
  #   container_name       = "tfstatecontainer"
  #   key                  = "terraform.tfstate"
  # }
}

provider "azurerm" {
   features {}
}

# creating resource group
resource "azurerm_resource_group" "rg" {
  name     = "ACATFDemo"
  location = "eastus"
}

# creating log analytics workspace
resource "azurerm_log_analytics_workspace" "law" {
  name                = "law-aca-terraform"
  resource_group_name = azurerm_resource_group.rg.name
  location            = azurerm_resource_group.rg.location
  sku                 = "PerGB2018"
  retention_in_days   = 90
}

# creating aca environment
resource "azapi_resource" "aca_env" {
  type      = "Microsoft.App/managedEnvironments@2022-03-01"
  parent_id = azurerm_resource_group.rg.id
  location  = azurerm_resource_group.rg.location
  name      = "aca-env-terraform"

  body = jsonencode({
    properties = {
      appLogsConfiguration = {
        destination = "log-analytics"
        logAnalyticsConfiguration = {
          customerId = azurerm_log_analytics_workspace.law.workspace_id
          sharedKey  = azurerm_log_analytics_workspace.law.primary_shared_key
        }
      }
    }
  })
}

# creating the aca
resource "azapi_resource" "aca" {
  type      = "Microsoft.App/containerApps@2022-03-01"
  parent_id = azurerm_resource_group.rg.id
  location  = azurerm_resource_group.rg.location
  name      = "terraform-app"

  body = jsonencode({
    properties : {
      managedEnvironmentId = azapi_resource.aca_env.id
      configuration = {
        ingress = {
          external   = true
          targetPort = 80
        }
      }
      template = {
        containers = [
          {
            name  = "web"
            image = "nginx"
            resources = {
              cpu    = 0.5
              memory = "1.0Gi"
            }
          }
        ]
        scale = {
          minReplicas = 2
          maxReplicas = 20
        }
      }
    }
  })
}