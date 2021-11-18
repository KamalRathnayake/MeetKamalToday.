
$grp="RedisDemoRG"
$redisName="redis20211119"
$loc="southeastasia"

az group create --name $grp --location $loc --tags CreatedBy=kamalr@99x.io

az redis create --name $redisName --resource-group $grp --location $loc --vm-size C0 --sku Basic

$key=$(az redis list-keys --name $redisName --resource-group $grp --query primaryKey --output tsv)

echo $key

echo kqaieNz7loYVrl7Tefo5i4untfz2WXv9IAzCaMDbNHU=@redis20211119.redis.cache.windows.net:6380?ssl=true

az redis show --name $redisName --resource-group $grp --query provisioningState