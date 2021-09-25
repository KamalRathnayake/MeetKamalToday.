$grp="MyVPNRG"
$location="southeastasia"
$vmName="MyVPNServer"

# CREATE RESOURCE GROUP
az group create --name $grp --location $location

# CREATING VM
az vm create --resource-group $grp --name $vmName --image ubuntults --admin-username kamal --admin-password Hello@12345# --size Standard_B1ls

# OPENING THE PORTS
az vm open-port -g $grp -n $vmName --priority 100 --port 80
az vm open-port -g $grp -n $vmName --priority 101 --port 1194

# PREPARING THE VM
apt-get update -y
apt-get upgrade -y
apt-get install apache2 -y

# INSTALLING OPENVPN
wget https://raw.githubusercontent.com/angristan/openvpn-install/master/openvpn-install.sh
chmod +x openvpn-install.sh
./openvpn-install.sh

mv myownvpn.ovpn /var/www/html/myownvpn.ovpn

# STATS
apt install vnstat -y
vnstat -h -l

# CONNECT WITH OPENVPN CLIENT