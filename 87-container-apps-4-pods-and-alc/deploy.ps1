$grp = "cn-arm-rg"
$loc = "eastus"

az group create -n $grp -l $loc 

az deployment group create `
     --resource-group $grp `
     --template-file '.\env.arm.json'