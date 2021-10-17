$loc = 'southeastasia'
$grp="ServiceEndpointAppServiceRG"
$pln='AppPlan'
$vnetName="VNET"
$subnetName="SUBNET_1"
$vmName="VM_1"

# CREATING RESOURCE GROUP
az group create --name $grp --location $loc

# CREATING WEB APPS
az appservice plan create --name $pln --resource-group $grp --location $loc --sku S1
az webapp create --name appgwdemoapp1 --plan $pln --resource-group $grp

# CREATE VIRTUAL NETWORK
az network vnet create --address-prefixes 10.0.0.0/16 --name $vnetName --resource-group $grp

# CREATING SUBNET
az network vnet subnet create -g $grp --vnet-name $vnetName -n $subnetName --address-prefixes 10.0.0.0/24

# CREATING VMs
az vm create --resource-group $grp --name $vmName --image ubuntults --vnet-name $vnetName --subnet $subnetName --admin-username kamal --admin-password Hello@12345#

# ACCESS RESTRICTION ON WEB APP
az webapp config access-restriction add --resource-group $grp --name appgwdemoapp1 --rule-name AppGwSubnet --priority 200 --subnet $subnetName --vnet-name $vnetName