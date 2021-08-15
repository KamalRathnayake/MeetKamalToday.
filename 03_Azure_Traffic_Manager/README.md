# What is Azure Traffic Manager?
    - DNS based routing
    - Routing methods
    - Types of endpoints
      - Pass cloud services
      - Web Apps
      - Web App Slots
      - PublicIPAddresses
      - Outside of Azure Endpoints
    - Traffic View
    - Disaster recovery


# Creating WebApp

Creating the web app in Asia

```bash
$loc = 'southeastasia'
$grp = '03TrafficManager'
$pln = '03TF-SEA'

az group create --name $grp --location $loc
az appservice plan create --name 03TFPlan --resource-group $grp --location $loc --sku Free
az webapp create --name seasiaapp2021 --plan 03TFPlan --resource-group $grp
```

# Creating the the web app in West US

```bash
$loc = 'westus'
$pln = '03TF-WUS'

az appservice plan create --name 03TFPlanWUS --resource-group $grp --location $loc --sku Free
az webapp create --name westusapp2021 --plan 03TFPlanWUS --resource-group $grp
```

# Creating a VM

```bash
az vm create --resource-group $grp --location westus --name VM_WEST_US --image ubuntults --admin-username kamal --admin-password Hello@12345#
```

# Creating Traffic Manager Profile