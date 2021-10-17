
$loc = 'southeastasia'
$grp = 'FrontDoorDemoRG'
$pln = 'FdDemoPlan'

az group create --name $grp --location $loc
az appservice plan create --name $pln --resource-group $grp --location $loc --sku Free
az webapp create --name FDDemoApplication1 --plan $pln --resource-group $grp

az webapp create --name FDDemoApplication2 --plan $pln --resource-group $grp