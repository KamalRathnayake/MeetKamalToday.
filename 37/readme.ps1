$grp="ManagedIdentityStorageTestRG"
$loc = 'southeastasia'
$appname='managedidentitydemo20211023'
$pln = 'testplan'
$storageAccountName="funcappstorage2021"

# CREATING RESOURCE GROUP
az group create --name $grp --location southeastasia

# CREATING APP SERVICE
az appservice plan create --name $pln --resource-group $grp --location $loc --sku Free
az webapp create --name $appname --plan $pln --resource-group $grp

# STORAGE ACCOUNT
az storage account create --name $storageAccountName --resource-group $grp