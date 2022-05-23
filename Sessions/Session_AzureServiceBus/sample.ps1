az group create --name ServiceBusDemoRG --location southeastasia 
az group deployment create --resource-group ServiceBusDemoRG --template-file .\servicebus_session.bicep --mode Complete
