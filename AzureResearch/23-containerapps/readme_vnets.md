$grp = "cnrgvnets"
$image = "nginx:latest"
$app = "my-countries-app"
$loc = "eastus"
$environment = "cne"
$vnetName="cnxvnet1"
$subnetName="SUBNET_1"

az group create --name $grp `
                --location $loc `
                

# Creating VNet
az network vnet create --address-prefixes 10.0.0.0/16 --name $vnetName --resource-group $grp

# Creating Subnet
az network vnet subnet create -g $grp --vnet-name $vnetName -n $subnetName --address-prefixes 10.0.0.0/24


az containerapp env create --name $environment `
                           --resource-group $grp `
                           --internal-only false `
                           --location $loc


$image = "kamalrathnayake/sampleappmvcapp"
$grp = "cnrg"
$app = "my-sample-todo-app"
$environment = "cne"

az containerapp create `
  --name $app `
  --resource-group $grp `
  --image $image `
  --environment $environment `
  --cpu 0.5 --memory 1.0Gi `
  --ingress external `
  --target-port 80