$grp = "VNetDemoRG"
$loc = "eastus"
$cne = "capp-env"
$vnetName = "container-apps-vnet"
$subnetNameVM = "vm-subnet"
$subnetNameContainers = "infra-subnet"
$vmName = "win-vm"

# creating resource group
az group create --name $grp `
    --location $loc

# creating vnet + subnet
az network vnet create `
    --resource-group $grp `
    --name $vnetName `
    --location $loc `
    --address-prefix 10.0.0.0/16

az network vnet subnet create `
    --resource-group $grp `
    --vnet-name $vnetName `
    --name $subnetNameVM `
    --address-prefixes 10.0.0.0/23

az network vnet subnet create `
    --resource-group $grp `
    --vnet-name $vnetName `
    --name $subnetNameContainers `
    --address-prefixes 10.0.254.0/23

# a vm for testing the integration
az vm create --resource-group $grp `
    --location $loc `
    --name $vmName `
    --image Win2019Datacenter `
    --vnet-name $vnetName `
    --subnet $subnetNameVM `
    --admin-username kamal `
    --admin-password Hello@12345#

# creating container app
$infraSubnet = (az network vnet subnet show --resource-group $grp --vnet-name $vnetName --name $subnetName --query "id" -o tsv)

az containerapp env create `
    --name $cne `
    --resource-group $grp `
    --location $loc `
    --internal-only false `
    --infrastructure-subnet-resource-id $infraSubnet

az containerapp create `
    --name sample-app-4 `
    --resource-group $grp `
    --environment $cne `
    --image kamalrathnayake/webapp:latest `
    --target-port 80 `
    --ingress 'internal' `
    --min-replicas 1 `
    --max-replicas 5


# configuring dns
$ENVIRONMENT_DEFAULT_DOMAIN = (az containerapp env show --name $cne --resource-group $grp --query "properties.defaultDomain" -o tsv)
$ENVIRONMENT_STATIC_IP = (az containerapp env show --name $cne --resource-group $grp --query "properties.staticIp" -o tsv)
$VNET_ID = (az network vnet show --resource-group $grp --name $vnetName --query id -o tsv)

az network private-dns zone create `
    --resource-group $grp `
    --name $ENVIRONMENT_DEFAULT_DOMAIN

az network private-dns link vnet create `
    --resource-group $grp `
    --name $vnetName `
    --virtual-network $VNET_ID `
    --zone-name $ENVIRONMENT_DEFAULT_DOMAIN -e true

az network private-dns record-set a add-record `
    --resource-group $grp `
    --record-set-name "*" `
    --ipv4-address $ENVIRONMENT_STATIC_IP `
    --zone-name $ENVIRONMENT_DEFAULT_DOMAIN

az group delete -g $grp --yes