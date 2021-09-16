
$loc = 'southeastasia'
$grp = 'VMWebAppTest'
$vm='VM_WEST_US'

az group create --name $grp --location $loc
$ipaddress = (az vm create --resource-group $grp --name $vm --image ubuntults --admin-username kamal --admin-password Hello@12345# --location $loc  -o json --query PublicIpAddress)

az vm open-port -g $grp -n $vm --port 80

ssh kamal@13.76.82.218

# INSTALLING NGINX
apt-get upgrade
apt-get update
apt install nginx -y
systemctl status nginx

# INSTALLING APACHE
apt-get upgrade
apt-get update
apt-get install apache2

# INSTALLING DOTNET
wget https://packages.microsoft.com/config/ubuntu/21.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb

sudo apt-get update; \
  sudo apt-get install -y apt-transport-https && \
  sudo apt-get update && \
  sudo apt-get install -y dotnet-sdk-5.0