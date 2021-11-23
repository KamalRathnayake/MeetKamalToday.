$loc = 'southeastasia'
$grp = 'TrafficManagerDemo'
$pln = 'sea-plan'
$appname = 'app-in-sea'

az group create --name $grp --location $loc
az appservice plan create --name $pln --resource-group $grp --location $loc --sku S1
az webapp create --name $appname --plan $pln --resource-group $grp

$loc = 'australiaeast'
$pln = 'au-plan'
$appname = 'app-in-australia'

az appservice plan create --name $pln --resource-group $grp --location $loc --sku S1
az webapp create --name $appname --plan $pln --resource-group $grp

