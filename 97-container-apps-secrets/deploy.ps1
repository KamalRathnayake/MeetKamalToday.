$grp = "SecretsDemoRG"
$loc = "eastus"
$environment = "cne"

# creating resource group
az group create --name $grp `
    --location $loc

# creating environment
az containerapp env create --name $environment `
--resource-group $grp `
--internal-only false `
--location $loc

# creating the users app
az containerapp create `
--name secrets-demo-app `
--resource-group $grp `
--environment $environment `
--image kamalrathnayake/secretsdemo:latest `
--target-port 80 `
--ingress 'external' `
--secrets key1=123456 key2="Another secret"

# restarting a revision
az containerapp revision restart -n secrets-demo-app -g $grp --revision secrets-demo-app--v2

az group delete --resource-group $grp --yes