$grp="LB1TestRG"
$location="southeastasia"
$vnetName="SEA_VNET"
$subnetName="SEA_SUBNET_1"
$vmName="SEA_VM_1"
$vmName2="SEA_VM_2"
$nsg="NSG1"
$avset="AVSET1"

# CREATE RESOURCE GROUP
az group create --name $grp --location $location

# CREATE VIRTUAL NETWORK
az network vnet create --address-prefixes 10.0.0.0/16 --name $vnetName --resource-group $grp

# CREATING SUBNET
az network vnet subnet create -g $grp --vnet-name $vnetName -n $subnetName --address-prefixes 10.0.0.0/24

# CREATING SECURITY GROUP
az network nsg create -g $grp -n NSG1

# CREATING AVAILABILITY SET
az vm availability-set create -n $avset -g $grp --platform-fault-domain-count 2 --platform-update-domain-count 2

# CREATING VM1
az vm create --resource-group $grp --name $vmName --image ubuntults --vnet-name $vnetName --subnet $subnetName --nsg $nsg --availability-set $avset --admin-username kamal --admin-password Hello@12345#

# CREATING VM2
az vm create --resource-group $grp --name $vmName2 --image ubuntults --vnet-name $vnetName --subnet $subnetName --nsg $nsg --availability-set $avset --admin-username kamal --admin-password Hello@12345#

# INSTALLING APACHE
apt-get update -y
apt-get upgrade -y
apt-get install apache2 -y
echo "Hello From VM 1" > /var/www/html/index.html

apt-get update -y
apt-get upgrade -y
apt-get install apache2 -y
echo "Hello From VM 2" > /var/www/html/index.html