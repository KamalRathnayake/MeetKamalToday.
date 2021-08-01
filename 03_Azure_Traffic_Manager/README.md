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


`$loc = 'southeastasia'`

`$grp = '03TrafficManager'`

`$pln = '03TF-SEA'`

`az group create --name $grp --location $loc`

`az appservice plan create --name 03TFPlan --resource-group $grp --location $loc --sku Free`

`az webapp create --name seasiaapp2021 --plan 03TFPlan --resource-group $grp`

Creating the the web app in West US

`$loc = 'westus'`

`$pln = '03TF-WUS'`

`az appservice plan create --name 03TFPlanWUS --resource-group $grp --location $loc --sku Free`

`az webapp create --name westusapp2021 --plan 03TFPlanWUS --resource-group $grp`

# Creating a VM
Creating the Resource Group

`az group create --location westus --resource-group 03TrafficManager`

Creating the VM in West US

`az vm create --resource-group 03TrafficManager --name VM_WEST_US --image ubuntults --admin-username kamal --admin-password Hello@12345#`

# Creating Traffic Manager Profile