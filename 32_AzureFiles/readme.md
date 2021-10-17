$loc = 'southeastasia'
$grp = 'Storage2RG'
$storageAccountName = '20211015storage1'

az group create --name $grp --location $loc
az storage account create --name $storageAccountName --resource-group $grp
