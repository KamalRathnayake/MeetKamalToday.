$grp = "ContainerRevisionsARMDemo"
$loc = "eastus"

# creating resource group
az group create --name $grp `
                --location $loc

# deploy the template
az deployment group create --resource-group $grp `
                           --template-file 'template.json'