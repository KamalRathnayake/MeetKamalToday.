## Create Storage 2

```bash
$grp="StorageGroup"
$location="southeastasia"
$storageAccountName="samplestorage202108153"

# CREATING RESOURCE GROUP
az group create --name $grp --location $location

# CREATING STORAGE ACCOUNT
az storage account create --name $storageAccountName --resource-group $grp --location $location

# LISTING CREDENTIALS
# az storage account keys list -g $grp -n $storageAccountName
az storage account show-connection-string -g $grp -n $storageAccountName

az group delete --resource-group $grp --yes
```

## Create Storage with a Container

```bash
$grp="StorageGroup"
$location="southeastasia"
$storageAccountName="samplestorage202108153"
$containerName="first-container"

# CREATING RESOURCE GROUP
az group create --name $grp --location $location

# CREATING STORAGE ACCOUNT
az storage account create --name $storageAccountName --resource-group $grp --location $location

# LISTING CREDENTIALS
# az storage account keys list -g $grp -n $storageAccountName
az storage account show-connection-string -g $grp -n $storageAccountName

# CREATING CONTAINER
az storage container create --name $containerName --account-name $storageAccountName

az group delete --resource-group $grp --yes
```

## Create Web Application

```bash
$loc = 'southeastasia'
$grp = '03TrafficManager'
$pln = '03TF-SEA'

az group create --name $grp --location $loc
az appservice plan create --name 03TFPlan --resource-group $grp --location $loc --sku Free
az webapp create --name seasiaapp2021 --plan 03TFPlan --resource-group $grp
```

## Create Function App
```bash
$storageAccountName="funcappstorage2021"
$loc = 'southeastasia'
$grp="StorageGroup"
az group create --name $grp --location $loc
az storage account create --name $storageAccountName --resource-group $grp
az functionapp create --name apibackend2021 --resource-group $grp --consumption-plan-location westus --os-type Windows --runtime dotnet --storage funcappstorage2021
```

## Creating a VM (Ubuntu)

```bash
az vm create --resource-group $grp --location westus --name VM_WEST_US --image ubuntults --admin-username kamal --admin-password Hello@12345#
az vm create --resource-group $grp --name VM_WEST_US --image ubuntults --admin-username kamal --admin-password Hello@12345#
```
## Creating SQL Server Db

```bash
# DEFINING VARIABLES
$grp="SampleSQLRG"
$serverName="myserver20210801"
$databaseName="mydb1"

# CREATING RESOURCE GROUP
az group create --name $grp --location southeastasia

# CREATING SQL SERVER
az sql server create -l southeastasia -g $grp -n $serverName -u kamal -p Hello@12345#

# CREATING THE DATABASE
az sql db create --resource-group $grp --server $serverName --name $databaseName --edition Standard --zone-redundant false --backup-storage-redundancy Local
```

## Networks Subnets & VMS

```bash

$grp="VirtualNetworksTestRG"
$location="southeastasia"
$vnetName="myfirstvnet"
$subnetName="myfirstsubnet"
$subnetName2="myfirstsubnet2"
$nsgName="firstsecuritygroup"
$vmName="MY_VM_1"
$vmName2="MY_VM_2"

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

az group delete --resource-group $grp --yes
```

## Networks Subnets VMS & NSGS (NOT COMPLETE)

```bash

$grp="VirtualNetworksTestRG"
$location="southeastasia"
$vnetName="myfirstvnet"
$subnetName="myfirstsubnet"
$subnetName2="myfirstsubnet2"
$nsgName="firstsecuritygroup"
$vmName="MY_VM_1"
$vmName2="MY_VM_2"

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

# CREATING NSG TO DISALLOW TRAFFIC
az network nsg rule create -g $grp --nsg-name MyNsg -n MyNsgRule --priority 4096 --source-address-prefixes "*" --source-port-ranges "*" --destination-address-prefixes "*" --destination-port-ranges "*" --access Deny --protocol Tcp --description "Deny f"

az group delete --resource-group $grp --yes
```

## EVENT HUBS

```bash
$grp="EventHubsDemoRG"
$location="southeastasia"
$namespaceName="MyEventHub202108"
$eventHubName="TrafficFromSL"

# CREATE RESOURCE GROUP
az group create --name $grp --location $location

# CREATING THE NAMESPACE
az eventhubs namespace create --resource-group $grp --name $namespaceName --location $location --sku Standard --enable-auto-inflate --maximum-throughput-units 1

# CREATING EVENTHUB
az eventhubs eventhub create --resource-group $grp --namespace-name $namespaceName --name $eventHubName --message-retention 4 --partition-count 15

az group delete --resource-group $grp --yes
```

## Creating AppInsights
```bash

$grp="InsightsDemoRG"
$location="southeastasia"
$name="MyInsights"

# CREATE RESOURCE GROUP
az group create --name $grp --location $location

# CREATING APP INSIGHTS
az monitor app-insights component create --app $name --location $location --resource-group $grp

az group delete --resource-group $grp --yes
```


## Automatically Setting App Settings

```bash
$loc = 'southeastasia'
$appname='seasiaapp20210825'
$grp = '05AzureCDNRG'
$pln = '05cdntestplan'
$cdnprofile = '05CDNProfile'

az group create --name $grp --location $loc
az appservice plan create --name 03TFPlan --resource-group $grp --location $loc --sku Free
az webapp create --name $appname --plan 03TFPlan --resource-group $grp

$storageAccountName="samplestorage202108153"
$containerName="first-container"

az storage account create --name $storageAccountName --resource-group $grp --location $loc

$conString=(az storage account show-connection-string -g $grp -n $storageAccountName -o json --query connectionString)

az webapp config appsettings set -g $grp -n $appname --settings StorageConnectionString=$conString
```

## Web App Deployment Source Settings
```bash
$app="sampleapp202109"
$grp="samplegrouprg"
az webapp deployment source config --branch main --manual-integration --name $app --repo-url https://github.com/KamalRathnayake/delete_dotnetmvc.git --resource-group $grp
az webapp deployment source sync --name $app --resource-group $grp
az webapp show --name $app --resource-group $grp
az webapp deployment slot create --name $app --slot staging2 --resource-group $grp
az webapp deployment github-actions add --repo https://github.com/KamalRathnayake/delete_dotnetmvc.git --name $app --resource-group $grp --login-with-github

```