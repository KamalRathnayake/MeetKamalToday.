$loc = "eastus"
$grp = "AzureLoadTestDemo"

# CREATING THE APP SERVICE
az group create --name $grp --location $loc

$loc = "eastus"
$grp = "AzureLoadTestDemo"
$pln = "AzureLoadTestDemo-Plan"
$appname = "azureloadtestdemoapp100"

# CREATING THE APP SERVICE
az appservice plan create --name $pln --resource-group $grp --location $loc --sku S1
az webapp create --name $appname --plan $pln --resource-group $grp

# PUBLISHING USING PRIMES REPO
az webapp deployment source config --branch main --manual-integration --name $appname --repo-url https://github.com/KamalRathnayake/PrimesApp.git --resource-group $grp

# SEE THE RESULTS AT
echo "https://$appname.azurewebsites.net/primes/100000"