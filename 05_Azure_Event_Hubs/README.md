```bash

$loc = 'southeastasia'
$grp = '05AzureEventHubs'
$pln = '03TF-SEA'
$namespace="MyEventHubsNamespace"
$eventHubName="MyEventHub"
$storageAccountName="funcappstorage2021"

# CREATING RESOURCE GROP
az group create --name $grp --location $loc

az storage account create --name $storageAccountName --resource-group $grp
az functionapp create --name apibackend2021 --resource-group $grp --consumption-plan-location westus --os-type Windows --runtime dotnet --storage funcappstorage2021

# CREATING EVENT HUB NAMESPACE
az eventhubs namespace create --name $namespace --resource-group $grp --sku Basic --location $loc

# CREATING THE EVENT HUB
az eventhubs eventhub create --name $eventHubName --namespace-name $namespace --resource-group $grp --message-retention 1 --partition-count 2

# GETTNG THE AUTHORIZATION INFO
az eventhubs namespace authorization-rule keys list --resource-group $grp --namespace-name $namespace --name RootManageSharedAccessKey --output json

az group delete --resource-group $grp --yes

```