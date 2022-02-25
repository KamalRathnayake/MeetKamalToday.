$grp="AppServiceVNETRG"
$location="southeastasia"
$vnetName="SEA_VNET"
$subnetName="SEA_SUBNET_1"
$vmName="AppServerVM"

# CREATE RESOURCE GROUP
az group create --name $grp --location $location --tags CreatedBy=kamalr@99x.io

# CREATE VIRTUAL NETWORK + VM
az network vnet create --address-prefixes 10.0.0.0/16 --name $vnetName --resource-group $grp
az network vnet subnet create -g $grp --vnet-name $vnetName -n $subnetName --address-prefixes 10.0.0.0/24

az vm create --resource-group $grp --name $vmName --image Win2019Datacenter --vnet-name $vnetName --subnet $subnetName --admin-username kamal --admin-password Hello@12345#


# CREATE APP SERVICES
az appservice plan create --name serviceendpointtest1plan --resource-group $grp --location $location --sku S1
az webapp create --name serviceendpointtest1 --plan serviceendpointtest1plan --resource-group $grp

az appservice plan create --name serviceendpointtest2plan --resource-group $grp --location $location --sku S1
az webapp create --name serviceendpointtest2 --plan serviceendpointtest2plan --resource-group $grp