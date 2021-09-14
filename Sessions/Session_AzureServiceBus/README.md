$grp="SerivceBusDemoRG"
$location="southeastasia"
$namespaceName="MySBNamespace202109"
$storageAccountName="funcappstorage2021"

# CREATE RESOURCE GROUP
az group create --name $grp --location $location

# CREATING SERVICE BUS NAMESPACE
az servicebus namespace create --resource-group $grp --name $namespaceName --location $location --tags --sku Basic

# CREATOMG SERVICE BUS QUEUE
az servicebus queue create --resource-group $grp --namespace-name $namespaceName --name the-queue

# CREATING AZURE FUNCTION APP
az storage account create --name $storageAccountName --resource-group $grp
az functionapp create --name apibackend2021 --resource-group $grp --consumption-plan-location westus --os-type Windows --runtime dotnet --storage funcappstorage2021