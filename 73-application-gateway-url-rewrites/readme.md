$grp="URLRewriteDemoRG"
$loc = 'southeastasia'
$appname='URLRewriteDemo20220116'
$pln = 'URLRewriteDemo20220116Plan'

# CREATING RESOURCE GROUP
az group create --name $grp --location southeastasia

# CREATING APP SERVICE
az appservice plan create --name $pln --resource-group $grp --location $loc --sku S1
az webapp create --name $appname --plan $pln --resource-group $grp