```bash
$storageAccountName="funcappstorage2021"
$loc = 'southeastasia'
$grp="QBLLRG"
$pln='QBLLPLAN'
$sbNamespaceName = "kamalsnamespace"
$sbQueueName = "the-queue"

# CREATING RESOURCE GROUP
az group create --name $grp --location $loc --tags CreatedBy=kamalr@99x.io

# CREATING WEB API APP
az appservice plan create --name $pln --resource-group $grp --location $loc --sku Free
az webapp create --name seasiaapp2021 --plan $pln --resource-group $grp

# CREATING FUNCTION APP
az storage account create --name $storageAccountName --resource-group $grp
az functionapp create --name apibackend2021 --resource-group $grp --consumption-plan-location westus --os-type Windows --runtime dotnet --storage funcappstorage2021

# CREATING SERVICE BUS
az servicebus namespace create --resource-group $grp --name $sbNamespaceName --location $loc --sku Basic
az servicebus queue create --resource-group $grp --namespace-name $sbNamespaceName --name $sbQueueName
$key=(az servicebus namespace authorization-rule keys list --resource-group $grp --namespace-name $sbNamespaceName --name RootManageSharedAccessKey --output json --query primaryConnectionString)
echo $key

az group delete --resource-group $grp --yes
```
