# CREATNG THE APP SERVICE ON AZURE
$loc = 'southeastasia'
$grp = '07PublishDirectlyDemoRG'
$pln = '07Demo-SEA'
$appname = 'directlypublishingdemo'

az group create --name $grp --location $loc
az appservice plan create --name $pln --resource-group $grp --location $loc --sku S1
az webapp create --name $appname --plan $pln --resource-group $grp
az webapp deployment user set --user-name kamal1 --password kamal12345


# CREATING THE .NET APP
mkdir CoolApp
cd CoolApp
dotnet new mvc --framework netcoreapp3.1 --no-restore

# PUBLISHING IT
git init
git add .
git commit -m initial


# PUBLISHING DOTNET APP TO AZURE
az webapp deployment source config-local-git --name $appname --resource-group $grp
$url=$(az webapp deployment source config-local-git --name $appname --resource-group $grp --output json --query url)

git remote add azure1 $url
git push azure1 master

az group delete --resource-group $grp --yes
