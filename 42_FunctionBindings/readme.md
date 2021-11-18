$location="southeastasia"
$vmName="WebFrontEnd"

# PRODUCTION
$grp="ProductionRG"
az group create --name $grp --location $location
az vm create --resource-group $grp --name $vmName --image ubuntults --admin-username kamal --admin-password Hello@12345#

# STAGING
$grp="StagingRG"
az group create --name $grp --location $location
az vm create --resource-group $grp --name $vmName --image ubuntults --admin-username kamal --admin-password Hello@12345#


# script
apt-get update -y
apt-get upgrade -y
apt-get install apache2 -y
echo "Hello from Production" > /var/www/html/index.html