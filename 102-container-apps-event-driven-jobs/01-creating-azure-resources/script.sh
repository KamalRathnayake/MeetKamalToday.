#!/bin/bash

RESOURCE_GROUP="rg-demo-container-registry"
LOCATION="eastus"
CONTAINER_REGISTRY_NAME="{container_registry_name}"

az group create --name $RESOURCE_GROUP --location $LOCATION

az acr create \
    --resource-group $RESOURCE_GROUP \
    --name $CONTAINER_REGISTRY_NAME \
    --sku Basic \
    --location $LOCATION

echo "Container registry '$CONTAINER_REGISTRY_NAME', created successfully."
