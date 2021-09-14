# TRYING OUT VNET PEERING
$grp="VirtualNetworksTestRG"
$location1="southeastasia"
$location2="westus"
$vnetName1="SEAvnet"
$vnetName2="WESTUSvnet"
$subnetName="myfirstsubnet"
$vmName="MY_VM_IN_SEA"
$vmName2="MY_VM_IN_WESTUS"

# CREATE RESOURCE GROUP
az group create --name $grp --location $location1

# CREATE VIRTUAL NETWORK 1
az network vnet create --address-prefixes 10.0.0.0/16 --name $vnetName1 --resource-group $grp --location $location1
az network vnet subnet create -g $grp --vnet-name $vnetName1 -n $subnetName --address-prefixes 10.0.0.0/24
az vm create --resource-group $grp --name $vmName --image ubuntults --vnet-name $vnetName1 --subnet $subnetName --admin-username kamal --admin-password Hello@12345#

# CREATE VIRTUAL NETWORK 2
az network vnet create --address-prefixes 10.0.0.0/16 --name $vnetName2 --resource-group $grp --location $location2
az network vnet subnet create -g $grp --vnet-name $vnetName2 -n $subnetName --address-prefixes 10.0.0.0/24
az vm create --resource-group $grp --name $vmName --image ubuntults --vnet-name $vnetName2 --subnet $subnetName --admin-username kamal --admin-password Hello@12345#

az group delete --resource-group $grp --yes