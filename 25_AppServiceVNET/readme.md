$loc = 'southeastasia'
$grp = 'AppServiceVNETDemoRG'
$pln = 'AppServiceVNETDemoRGPlan'
$appname = 'appservicevnetdemo1'
$vnetName = 'VNET_1'
$subnetName = 'SUBNET_1'
$vmName = 'VM1'

# CREATING RESOURCE GROUP
az group create --name $grp --location $loc

# CREATING APP SERVICE PLAN
az appservice plan create --name $pln --resource-group $grp --location $loc --sku S1

# CREATE VIRTUAL NETWORK
az network vnet create --address-prefixes 10.0.0.0/16 --name $vnetName --resource-group $grp

# CREATING SUBNET
az network vnet subnet create -g $grp --vnet-name $vnetName -n $subnetName --address-prefixes 10.0.0.0/24

# CREATING VM
az vm create --resource-group $grp --name $vmName --image ubuntults --vnet-name $vnetName --subnet $subnetName --admin-username kamal --admin-password Hello@12345#

# INSTALLING APACHE
apt-get update -y
apt-get upgrade -y
apt-get install apache2 -y

echo "Hello From Virtual Machine!" > /var/www/html/index.html
