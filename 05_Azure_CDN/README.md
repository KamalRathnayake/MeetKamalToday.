```bash

# CREATING A WEB APP
$loc = 'southeastasia'
$appname='seasiaapp20210825'
$grp = '05AzureCDNRG'
$pln = '05cdntestplan'
$cdnprofile = '05CDNProfile'

az group create --name $grp --location $loc
az appservice plan create --name 03TFPlan --resource-group $grp --location $loc --sku Free
az webapp create --name $appname --plan 03TFPlan --resource-group $grp
az webapp deployment user set --user-name kamal1 --password kamal12345
# az webapp deployment source config-local-git --name $appname --resource-group $grp
# $url=$(az webapp deployment source config-local-git --name $appname --resource-group $grp --output json --query url)

# CREATING DOTNET APPLICATION
mkdir webapp1
cd webapp1
dotnet new webapp --framework netcoreapp3.1
git init
git add .
git commit -m initial

az webapp deployment source config-local-git --name $appname --resource-group $grp
$url=$(az webapp deployment source config-local-git --name $appname --resource-group $grp --output json --query url)

# PUBLISHING DOTNET APP TO AZURE
git remote add azure1 $url
git push azure1 master

# CREATING CDN PROFILE
az provider register --namespace Microsoft.Cdn
az cdn profile create --name $cdnprofile --resource-group $grp --sku Standard_Microsoft

az group delete --resource-group $grp --yes
```