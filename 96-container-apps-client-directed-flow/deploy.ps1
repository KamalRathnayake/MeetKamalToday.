$grp = "ClientDirectedFlowDemoRG"
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

# creating the frontend
az containerapp create `
    --name auth-demo-app `
    --resource-group $grp `
    --environment $environment `
    --image kamalrathnayake/authdemoapp:latest `
    --target-port 80 `
    --ingress 'external' `
    --min-replicas 0 `
    --max-replicas 5

az group delete --resource-group $grp --yes


