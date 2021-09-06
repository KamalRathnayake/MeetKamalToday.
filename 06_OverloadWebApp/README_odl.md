```bash
$loc = "southeastasia"
$grp = "06OverloadTestRG"
$pln = "06OLTEST-SEA"
$appname = "mysampleapp202109"

az group create --name $grp --location $loc
az appservice plan create --name 03TFPlan --resource-group $grp --location $loc --sku S1
az webapp create --name $appname --plan 03TFPlan --resource-group $grp
az webapp deployment user set --user-name kamal1 --password kamal12345
```

# CREATING DOTNET APPLICATION
```bash
mkdir PrimesApp
cd PrimesApp
dotnet new webapi --framework netcoreapp3.1 --no-restore
```

```csharp


```
```bash
git init
git add .
git commit -m initial


# PUBLISHING DOTNET APP TO AZURE
az webapp deployment source config-local-git --name $appname --resource-group $grp
$url=$(az webapp deployment source config-local-git --name $appname --resource-group $grp --output json --query url)

git remote add azure1 $url
git push azure1 master
```