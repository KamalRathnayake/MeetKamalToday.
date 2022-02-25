# CloudRG
$grp="CloudRG"
$location="eastus"
$vmName="ServerVM"

# CREATE RESOURCE GROUP
az group create --name $grp --location $location

# CREATING VM
az vm create --location $location --resource-group $grp --name $vmName --image Win2019Datacenter --admin-username kamal --admin-password Hello@12345#

# OnPremRG
$grp="OnPremRG"
$location="southeastasia"
$vnetName="OnPremVNET"
$subnetName="SubnetA"
$vmName="ClientVM"

# CREATE RESOURCE GROUP
az group create --name $grp --location $location

# CREATE VIRTUAL NETWORK
az network vnet create --address-prefixes 10.1.0.0/16 --name $vnetName --resource-group $grp

# CREATING SUBNETS
az network vnet subnet create -g $grp --vnet-name $vnetName -n $subnetName --address-prefixes 10.1.1.0/24

# CREATING VM
az vm create --location $location --resource-group $grp --name $vmName --image Win2019Datacenter --vnet-name $vnetName --subnet $subnetName --admin-username kamal --admin-password Hello@12345#