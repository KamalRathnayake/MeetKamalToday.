```$grp="EnvEastUSRG"
$loc = 'eastus'
$pln = 'appservicehatest'
$serverName="primaryserver20220217"
$databaseName="UsersDb"
$backendapp1 = "hademo-webapp-eastus"
$backendapp2 = "hademo-webapp-westus"

# CREATING PRIMARY RESOURCES
az group create --name $grp --location $loc --tags Type=Demo

az sql server create -l $loc -g $grp -n $serverName -u kamal -p Hello@12345#
az sql server firewall-rule create --name allowingall --server $serverName --resource-group $grp --start-ip-address 0.0.0.0 --end-ip-address 255.255.255.255
az sql db create --resource-group $grp --server $serverName --name $databaseName --edition Standard --zone-redundant false --backup-storage-redundancy Local

az appservice plan create --name $pln --resource-group $grp --location $loc --sku S1
az webapp create --name $backendapp1 --plan $pln --resource-group $grp

# CREATING SECONDARY RESOURCES
$loc='westus'
$grp="EnvWestUSRG"
$serverName="secondaryserver20220217"
az group create --name $grp --location $loc --tags Type=Demo

az sql server create -l $loc -g $grp -n $serverName -u kamal -p Hello@12345#
az sql server firewall-rule create --name allowingall --server $serverName --resource-group $grp --start-ip-address 0.0.0.0 --end-ip-address 255.255.255.255

az appservice plan create --name $pln --resource-group $grp --location $loc --sku S1
az webapp create --name $backendapp2 --plan $pln --resource-group $grp


# CREATING RESOURCE GROUP FOR LOAD BALANCER
$grp="LoadBalancerRG"
$frontDoorName="fdoor20220218"

az group create --name $grp --location $loc --tags Type=Demo

# SETTING DB CONFIGURATION
az webapp config appsettings set -g EnvEastUSRG -n $backendapp1 --settings DatabaseServer=usersdb-fg.database.windows.net
az webapp config appsettings set -g EnvWestUSRG -n $backendapp2 --settings DatabaseServer=usersdb-fg.database.windows.net
az webapp config appsettings set -g EnvEastUSRG -n $backendapp1 --settings Region="EastUS-Primary"
az webapp config appsettings set -g EnvWestUSRG -n $backendapp2 --settings Region="WestUS-Secondary"
```
