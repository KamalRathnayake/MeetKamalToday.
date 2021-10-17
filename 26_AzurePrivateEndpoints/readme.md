$grp="PrivateEndpointsTestRG"
$location="southeastasia"
$vmName="AppServerVM"
$serverName="myprimaryserver20210815"
$databaseName="mydatabase"

# CREATE RESOURCE GROUP
az group create --name $grp --location $location

# CREATING VM
az vm create --resource-group $grp --name $vmName --image Win2019Datacenter --admin-username kamal --admin-password Hello@12345$

# CREATING SQL SERVER
az sql server create -l southeastasia -g $grp -n $serverName -u kamal -p Hello@12345#

# CREATING THE DATABASE
az sql db create --resource-group $grp --server $serverName --name $databaseName --edition Standard --zone-redundant false --backup-storage-redundancy Local

# ADDING A FIREWALL RULE TO CONNECT
az sql server firewall-rule create --name allowingall --server $serverName --resource-group $grp --start-ip-address 0.0.0.0 --end-ip-address 255.255.255.255
