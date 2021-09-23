$grp="ModulesDemoRG"

az group create --name $grp --tags CreatedBy=kamalr@99x.io
az group deployment create --resource-group $grp --template-file .\moduleConsumer.bicep --mode Complete

az group delete --resource-group $grp --yes