
$grp="VMEastUSRG"
$location="eastus"
$vmName="AppServerVM"
$dbVMName="DBServerVM"

# az vm image list --publisher Microsoft --all

# CREATE RESOURCE GROUP
az group create --name $grp --location $location --tags CreatedBy=kamalr@99x.io

# CREATING VM
az vm create --resource-group $grp --name $vmName --location $location --image Win2019Datacenter --admin-username kamal --admin-password Hello@12345#
az vm create --resource-group $grp --name --location=$location $dbVMName --image Win2019Datacenter --admin-username kamal --admin-password Hello@12345#

az vm open-port --port 80 --resource-group myResourceGroup --name myVM