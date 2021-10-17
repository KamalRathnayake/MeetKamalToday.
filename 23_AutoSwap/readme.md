```bash
$loc = 'southeastasia'
$grp = 'AutoSwapDemoRG'
$pln = 'AutoSwapDemoPlan'

az group create --name $grp --location $loc
az appservice plan create --name $pln --resource-group $grp --location $loc --sku S1
az webapp create --name AutoSwapDemoApplication --plan $pln --resource-group $grp
```