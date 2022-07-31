$grp = "StorageMounts1Demo"
$loc = "eastus"

# creating the resource group
az group create --name $grp `
                --location $loc
                
# deploy the template
az deployment group create --resource-group $grp `
                           --template-file 'template.json'

az group delete --resource-group $grp --yes