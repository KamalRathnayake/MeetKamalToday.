$grp="AppGatewayTestRG"
$location="southeastasia"
$vnetName="VNET"
$subnetName="SUBNET_1"
$vmName="IMAGE_VM"
$vmName2="VIDEO_VM"

# CREATE RESOURCE GROUP
az group create --name $grp --location $location

# CREATE VIRTUAL NETWORK
az network vnet create --address-prefixes 10.0.0.0/16 --name $vnetName --resource-group $grp

# CREATING SUBNET
az network vnet subnet create -g $grp --vnet-name $vnetName -n $subnetName --address-prefixes 10.0.0.0/24

# CREATING VMs
az vm create --resource-group $grp --name $vmName --image ubuntults --vnet-name $vnetName --subnet $subnetName --admin-username kamal --admin-password Hello@12345#
az vm create --resource-group $grp --name $vmName2 --image ubuntults --vnet-name $vnetName --subnet $subnetName --admin-username kamal --admin-password Hello@12345#


# SETTING UP WEB SERVERS
apt-get update -y
apt-get upgrade -y
apt-get install apache2 -y

echo "See all of your IMAGES here!" > /var/www/html/index.html
echo "See all of your VIDEOS here!" > /var/www/html/index.html

mkdir /var/www/html/images
mv /var/www/html/index.html /var/www/html/images/index.html

mkdir /var/www/html/videos
mv /var/www/html/index.html /var/www/html/videos/index.html