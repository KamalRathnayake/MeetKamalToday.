$grp = "app-arm-2-rg"
$loc = "eastus"

az group create -n $grp -l $loc

az deployment group create `
     --resource-group $grp `
     --template-file '.\smallapp.arm.json' `
     --mode 'Complete'