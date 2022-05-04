# Setting Up
# Net Integration
# [Across Regions]
$grp="VNetIntegrationDemo"
$loc = 'eastus'
az group create --name $grp --location $loc

# Creating App Service
# * Region - East US
$plan = "vnet-test-plan"
$appService = "app-service-202252"
az appservice plan create --name $plan --resource-group $grp --location $loc --sku S1
az webapp create --name $appService --plan $plan --resource-group $grp

# Creating VNET + Subnet
# * Region - East US
$vnetName='vnet-eastus'
$subnetName='vnet-eastus-sub1'
$loc='eastus'
az network vnet create --address-prefixes 10.10.0.0/16 --name $vnetName --resource-group $grp --location $loc
az network vnet subnet create -g $grp --vnet-name $vnetName -n $subnetName --address-prefixes 10.10.0.0/24

# Creating VNET + Subnet
# * Region - West US
$vnetName='vnet-westus'
$subnetName='vnet-westus-sub1'
$loc='westus'
az network vnet create --address-prefixes 10.10.0.0/16 --name $vnetName --resource-group $grp --location $loc
az network vnet subnet create -g $grp --vnet-name $vnetName -n $subnetName --address-prefixes 10.10.0.0/24