# Setting Up
# -> az provider register --namespace Microsoft.EventGrid
# -> az provider show --namespace Microsoft.EventGrid --query "registrationState"
$id = "31243"
# $subscription = "890342c8-3d37-47d8-a8c9-0cb7cbcd23cf"
$subscription = "b9efc495-e78a-4681-a691-460cfe70a5be"

$loc = "eastus"
$grp = "LatencyDemo$id"
$topicname = "eveluatelatencyevent$id"
$eventreceiver = "receivername$id"
$cache = "cachestore$id"

# RG
az group create --name $grp --location $loc 

# Event Grid
az eventgrid topic create --name $topicname -l $loc -g $grp --no-wait

# Cache
az redis create --location $loc --name $cache --resource-group $grp --sku Basic --vm-size c0
$redisKey = (az redis list-keys --name $cache --resource-group $grp --query "primaryKey")

# Database
$serverName="latencytestdbs$id"
$databaseName="latencytestdb$id"

az sql server create -l $loc -g $grp -n $serverName -u kamal -p Hello@12345#
az sql db create --resource-group $grp --server $serverName --name $databaseName --edition Basic --zone-redundant false --backup-storage-redundancy Local  --no-wait
az sql server firewall-rule create --name allowingall --server $serverName --resource-group $grp --start-ip-address 0.0.0.0 --end-ip-address 255.255.255.255

# Creating a Function App in each region.
# Regions - "eastus", "westus", "southindia", "uaenorth"
# In each region
# -> Creating Storage
# -> Function App
# -> Subscribing
$regions = "eastus", "westus", "southindia", "uaenorth"

foreach($region in $regions){
    Write-Host "[$region] creating resources..." -ForegroundColor yellow
    $storageAccountName = "ltst$id$region"
    $functionAppName = "lttstapp$id-$region"

    az storage account create --name $storageAccountName --location $region --resource-group $grp
    az functionapp create --name $functionAppName --storage-account $storageAccountName --consumption-plan-location $region --resource-group $grp --deployment-source-url https://github.com/KamalRathnayake/LatencyTest.git --deployment-source-branch main --functions-version 4 --runtime dotnet

    az functionapp config appsettings set --name $functionAppName --resource-group $grp --settings "connection_string=Server=tcp:$serverName.database.windows.net,1433;Initial Catalog=$databaseName;Persist Security Info=False;User ID=kamal;Password=Hello@12345#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
    az functionapp config appsettings set --name $functionAppName --resource-group $grp --settings "resource_region=$loc"
    az functionapp config appsettings set --name $functionAppName --resource-group $grp --settings "host_region=$region"
    az functionapp config appsettings set --name $functionAppName --resource-group $grp --settings "redis_host=$cache.redis.cache.windows.net"
    az functionapp config appsettings set --name $functionAppName --resource-group $grp --settings "redis_key=$redisKey"

    $endpoint="https://$functionAppName.azurewebsites.net/api/endpoint"
    $resourceId = "/subscriptions/$subscription/resourceGroups/$grp/providers/Microsoft.EventGrid/topics/$topicname" 

    az eventgrid event-subscription create --source-resource-id $resourceId --name "sub-$functionAppName" --endpoint $endpoint

    Write-Host "[$region] completed..." -ForegroundColor yellow
}

# Creating Event Grid Subscriptions

$endpoint="https://$eventreceiver.azurewebsites.net/api/updates"
$resourceId = "/subscriptions/$subscription/resourceGroups/$grp/providers/Microsoft.EventGrid/topics/$topicname" 

az eventgrid event-subscription create --source-resource-id $resourceId --name demoViewerSub --endpoint $endpoint


# Function apps

$storageAccountName = "latencyteststorage121212"
$grp = "latencyrg"
$loc = "eastus"
$functionAppName = "latencytestappeastus121214"

az storage account create --name $storageAccountName --resource-group $grp
az functionapp create --name $functionAppName --storage-account $storageAccountName --consumption-plan-location $loc --resource-group $grp --deployment-source-url https://github.com/KamalRathnayake/LatencyTest.git --deployment-source-branch main --functions-version 4 --runtime dotnet

az functionapp config appsettings set --name $functionAppName --resource-group $grp --settings "connection_string=Server=tcp:latencytest1212.database.windows.net,1433;Initial Catalog=latencytest1212;Persist Security Info=False;User ID=kamal;Password=Hello@12345#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
az functionapp config appsettings set --name $functionAppName --resource-group $grp --settings "resource_region=eastus"
az functionapp config appsettings set --name $functionAppName --resource-group $grp --settings "host_region=eastus"
az functionapp config appsettings set --name $functionAppName --resource-group $grp --settings "redis_host=latencytest121212.redis.cache.windows.net"
az functionapp config appsettings set --name $functionAppName --resource-group $grp --settings "redis_key=8IdDXZ121bYNUpe8ZJLfu52iMjdMcHVFCAzCaOFcxDA="


az functionapp deployment source config --branch master --manual-integration --name $functionAppName --repo-url https://github.com/KamalRathnayake/LatencyTest.git --resource-group $grp

# Sending events

$endpoint=$(az eventgrid topic show --name $topicname -g $grp --query "endpoint" --output tsv)
$key=$(az eventgrid topic key list --name $topicname -g $grp --query "key1" --output tsv)

$event='[ {"id": "123", "eventType": "recordInserted", "subject": "myapp/vehicles/motorcycles", "eventTime": "2022-04-28T12:12:12", "data":{ "make": "Ducati", "model": "Monster"},"dataVersion": "1.0"} ]'

curl -X POST -H "aeg-sas-key: $key" -d "$event" $endpoint

az group delete --name $grp