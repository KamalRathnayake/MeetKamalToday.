$grp = "MIDemo"
$loc = "eastus"
$environment = "cne-rev"
$kv = "demo-vault-" + (Get-random)

# creating resource group
az group create --name $grp `
    --location $loc

# creating a key vault
az keyvault create --name $kv `
    --location $loc `
    --resource-group $grp `

# writing a secret
az keyvault secret set --name MySecret `
    --vault-name $kv `
    --value 'Hello from Key Vault!'

# creating user assigned managed identity
az identity create --name capp-user --resource-group $grp
$identityClientId = (az identity show --resource-group $grp --name capp-user --output json --query "clientId")
$identityResourceId = (az identity show --resource-group $grp --name capp-user --output json --query "id")

# creating environment
az containerapp env create --name $environment `
    --resource-group $grp `
    --internal-only false `
    --location $loc

# creating the frontend
az containerapp create `
    --name mi-sample-3 `
    --resource-group $grp `
    --environment $environment `
    --image kamalrathnayake/midemoweb:latest `
    --target-port 80 `
    --ingress 'external' `
    --min-replicas 0 `
    --max-replicas 5 `
    --env-vars KEY_VAULT_NAME=$kv AZURE_CLIENT_ID=$identityClientId

# assigning the user assigned identity
az containerapp identity assign --resource-group $grp --name mi-sample-3 `
    --user-assigned $identityResourceId

az keyvault set-policy --name $kv --spn $identityClientId --secret-permissions 'get'

az containerapp delete --name mi-sample `
--resource-group $grp `
--yes

az group delete --resource-group $grp --yes --no-wait