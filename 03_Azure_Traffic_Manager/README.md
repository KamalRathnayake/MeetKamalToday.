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

# Creating a VM
Creating the Resource Group

`az group create --location westus --resource-group 03TrafficManager`

Creating the VM in West US

`az vm create --resource-group 03TrafficManager --name VM_WEST_US --image win2016datacenter --admin-username kamal --admin-password Hello@12345#`


`az vm create --resource-group 03TrafficManager --name VM_WEST_US --image windows10preview --admin-username kamal --admin-password Hello@12345#`

# Creating Traffic Manager Profile