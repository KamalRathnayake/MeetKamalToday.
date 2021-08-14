## Create Storage

`$storageAccountName=funcappstorage2021`

`$grp="StorageGroup"`

`az storage account create --name $storageAccountName --resource-group $grp`

## Create Web Application

`$loc = 'southeastasia'`

`$grp = '03TrafficManager'`

`$pln = '03TF-SEA'`

`az group create --name $grp --location $loc`

`az appservice plan create --name 03TFPlan --resource-group $grp --location $loc --sku Free`

`az webapp create --name seasiaapp2021 --plan 03TFPlan --resource-group $grp`

## Create Function App

`$storageAccountName=funcappstorage2021`

`$grp="StorageGroup"`

`az storage account create --name $storageAccountName --resource-group $grp`

`az functionapp create --name apibackend2021 --resource-group $grp --consumption-plan-location westus --os-type Windows --runtime dotnet --storage funcappstorage2021`

## Creating a VM (Ubuntu)

`az vm create --resource-group $grp --name VM_WEST_US --image ubuntults --admin-username kamal --admin-password Hello@12345#`

## Creating SQL Server Db
`
$grp="SampleSQLRG"
$serverName="myserver20210801"
$databaseName="mydb1"

az sql server create -l southeastasia -g $grp -n $serverName -u kamal -p Hello@12345#

az sql db create --resource-group $grp --server $serverName --name $databaseName --edition Standard --zone-redundant false --backup-storage-redundancy Local`
