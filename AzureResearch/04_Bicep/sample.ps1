$grp="S2RG"

az group create --name $grp 
az group deployment create --resource-group $grp --template-file .\deploy.bicep --mode Complete
