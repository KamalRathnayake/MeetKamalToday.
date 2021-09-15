```bash
$storageAccountName="funcappstorage2021"
$loc = 'southeastasia'
$grp="QBLLRG"
$sbNamespaceName = "kamalsnamespace"
$sbQueueName = "the-queue"

az group create --name $grp --location $loc
az storage account create --name $storageAccountName --resource-group $grp
az functionapp create --name apibackend2021 --resource-group $grp --consumption-plan-location westus --os-type Windows --runtime dotnet --storage funcappstorage2021


az servicebus namespace create --resource-group $grp --name $sbNamespaceName --location $loc --sku Basic
az servicebus queue create --resource-group $grp --namespace-name $sbNamespaceName --name $sbQueueName
$key=(az servicebus namespace authorization-rule keys list --resource-group $grp --namespace-name $sbNamespaceName --name RootManageSharedAccessKey --output json --query primaryConnectionString)
echo $key

```
