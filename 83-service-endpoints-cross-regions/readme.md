# Setting Up
# Service Endpoints
# [Across Regions]
$grp="ServiceEndpointsDemo"
$loc = 'eastus'
az group create --name $grp --location $loc

# Creating SQL Server
# In East US region
# A database
$serverName="sqlserver202252"
$databaseName="mydatabase"
az sql server create -l $loc -g $grp -n $serverName -u kamal -p Hello@12345#
az sql db create --resource-group $grp --server $serverName --name $databaseName --edition Standard --zone-redundant false --backup-storage-redundancy Local

# Firewall Rule 
# For direct connections.
az sql server firewall-rule create --name allowingall --server $serverName --resource-group $grp --start-ip-address 0.0.0.0 --end-ip-address 255.255.255.255

# Creating a Storage Account
# In East US region
$storageAccountName = "vnetstorage202252"
az storage account create --name $storageAccountName --resource-group $grp --sku Standard_LRS --location $loc

# Creating VNET + Subnet
# * Region - West US
$vnetName='vnet-westus'
$subnetName='vnet-westus-sub1'
$loc='westus'
az network vnet create --address-prefixes 10.10.0.0/16 --name $vnetName --resource-group $grp --location $loc
az network vnet subnet create -g $grp --vnet-name $vnetName -n $subnetName --address-prefixes 10.10.0.0/24

# Creating VNET + Subnet
# * Region - East US
$vnetName='vnet-eastus'
$subnetName='vnet-eastus-sub1'
$loc='eastus'
az network vnet create --address-prefixes 10.10.0.0/16 --name $vnetName --resource-group $grp --location $loc
az network vnet subnet create -g $grp --vnet-name $vnetName -n $subnetName --address-prefixes 10.10.0.0/24

# Can We Create;
# Service Endpoint Integrations?
# -> Let's find out!