az group create --name ServiceBusDemoRG --location southeastasia --tags CreatedBy=kamalr@99x.io
az group deployment create --resource-group ServiceBusDemoRG --template-file .\servicebus_session.bicep --mode Complete
