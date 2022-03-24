$loc = 'westus'
$grp = 'CosmosDbPrivateAccess'
$pln = 'cosmosdemo1'
$appname = 'cosmosdemoapp123'
$vnetName='cosmosdemo-vnet'
$subnetName='cosmosdemo-vnet-subnet1'
$cosmosdb='cosmosdemoaccount1'


# CREATE RESOURCE GROUP
az group create --name $grp --location $loc --tags CreatedFor=AzureDemo

### CREATING COSMOSDB ACCOUNT
az cosmosdb create --name $cosmosdb --resource-group $grp --locations regionName=$loc

### CREATE VIRTUAL NETWORK
az network vnet create --address-prefixes 10.0.0.0/16 --name $vnetName --resource-group $grp

### CREATE SUBNET
az network vnet subnet create -g $grp --vnet-name $vnetName -n $subnetName --address-prefixes 10.0.0.0/24

### CREATE APP SERVICE
az group create --name $grp --location $loc
az appservice plan create --name $pln --resource-group $grp --location $loc --sku S1
az webapp create --name $appname --plan $pln --resource-group $grp

az group delete --resource-group $grp