$grp="NSGTestRG"
$location="southeastasia"
$vnetName="VNET"
$subnetName="SUBNET_1"
$subnetName2="SUBNET_2"
$vmName="VM_1"
$vmName2="VM_2"

# CREATE RESOURCE GROUP
az group create --name $grp --location $location

# CREATE VIRTUAL NETWORK
az network vnet create --address-prefixes 10.0.0.0/16 --name $vnetName --resource-group $grp

# CREATING SUBNETS
az network vnet subnet create -g $grp --vnet-name $vnetName -n $subnetName --address-prefixes 10.0.0.0/24
az network vnet subnet create -g $grp --vnet-name $vnetName -n $subnetName2 --address-prefixes 10.0.10.0/24

# CREATING VMs IN EACH SUBNET
az vm create --resource-group $grp --name $vmName --image ubuntults --vnet-name $vnetName --subnet $subnetName --admin-username kamal --admin-password Hello@12345#
az vm create --resource-group $grp --name $vmName2 --image ubuntults --vnet-name $vnetName --subnet $subnetName2 --admin-username kamal --admin-password Hello@12345#


# INSTALLING APACHE

apt-get update -y
apt-get upgrade -y
apt-get install apache2 -y


echo "Hello From VM2!" > /var/www/html/index.html