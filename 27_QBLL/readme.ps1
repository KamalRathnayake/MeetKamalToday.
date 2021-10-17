
$storageAccountName="funcappstorage202110"
$loc = 'southeastasia'
$grp="ThrottleSampleRG"
$sbNamespaceName = "kamalsnamespace1"
$sbQueueName = "the-queue"

# CREATING RESOURCE GROUP
az group create --name $grp --location $loc

# CREATING SERVICE BUS
az servicebus namespace create --resource-group $grp --name $sbNamespaceName --location $loc --sku Basic
az servicebus queue create --resource-group $grp --namespace-name $sbNamespaceName --name $sbQueueName
$key=(az servicebus namespace authorization-rule keys list --resource-group $grp --namespace-name $sbNamespaceName --name RootManageSharedAccessKey --output json --query primaryConnectionString)
echo $key

# THROTTLING FUNCTION APP INSTANCE LIMIT
az resource update --resource-type Microsoft.Web/sites -g $grp -n throttlesample1/config/web --set properties.functionAppScaleLimit=4