$grp="ServiceBusDemoRG"

az group create --name $grp --location southeastasia --tags CreatedBy=kamalr@99x.io
az group deployment create --resource-group $grp --template-file .\servicebus_session.bicep --mode Complete
