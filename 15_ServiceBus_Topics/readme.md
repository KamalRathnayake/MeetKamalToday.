# CREATING THE SERVICE BUS

```bash
$grp="ServiceBusTopicsDemoRG"
$loc="southeastasia"
$sbNamespaceName="demosbns202109"

# CREATING RESOURCE GROUP
az group create --name $grp --location $location

# CREATING SERVICE BUS
az servicebus namespace create --resource-group $grp --name $sbNamespaceName --location $loc 
```