$grp="ModulesDemoRG"

az group create --name $grp
az group deployment create --resource-group $grp --template-file .\mydeployment.bicep --mode Complete

az group delete --resource-group $grp --yes