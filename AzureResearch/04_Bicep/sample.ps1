$grp="S2RG"

az group create --name $grp --tags CreatedBy=kamalr@99x.io
az group deployment create --resource-group $grp --template-file .\deploy.bicep --mode Complete
