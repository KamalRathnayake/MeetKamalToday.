$grp="NetworkStorageRG"
$location="southeastasia"
$storageAccountName = '20211015storage1'
$vmName="AppServerVM"

# CREATE RESOURCE GROUP
az group create --name $grp --location $location

# CREATING STORAGE
az storage account create --name $storageAccountName --resource-group $grp

# CREATING VM
az vm create --resource-group $grp --name $vmName --image Win2019Datacenter --admin-username kamal --admin-password Hello@12345$