
$grp="VirtualNetworksTestRG"
$location1="southeastasia"
$vnetName1="SEAvnet"
$subnetName="myfirstsubnet"
$vmName="MY_VM_IN_SEA"

# CREATE RESOURCE GROUP
az group create --name $grp --location $location1

# CREATING THE VM
az network vnet create --address-prefixes 10.0.0.0/16 --name $vnetName1 --resource-group $grp --location $location1
az network vnet subnet create -g $grp --vnet-name $vnetName1 -n $subnetName --address-prefixes 10.0.0.0/24
az vm create --resource-group $grp --name $vmName --image ubuntults --vnet-name $vnetName1 --subnet $subnetName --admin-username kamal --admin-password Hello@12345#


