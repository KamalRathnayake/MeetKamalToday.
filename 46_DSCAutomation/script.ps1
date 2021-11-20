
$grp="AzureAutomationDSCRG"
$location="southeastasia"
$vmName="ServerVM"

# CREATE RESOURCE GROUP
az group create --name $grp --location $location

# CREATING VM
az vm create --resource-group $grp --name $vmName --image Win2019Datacenter --admin-username kamal --admin-password Hello@12345#
az vm open-port -g $grp -n $vmName --priority 100 --port 80

# IMPORT THE CONFIGURATION
$grp="AzureAutomationDSCRG"
Import-AzAutomationDscConfiguration -Published -ResourceGroupName $grp -SourcePath ./MyFirstConfiguration.ps1 -Force -AutomationAccountName AutomationAccount20211120