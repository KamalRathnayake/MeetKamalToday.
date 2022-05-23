# Setting up
# * Variables
# * Resource groups
$grp = "BatchDemo1"
$loc="southeastasia"
$id = "202251"
$storageAccountName = "storage$id"
$batchAccountName = "videoencoder$id"

az group create --name $grp --location $loc 

# Storage Account
# * For Storing
# -> Applications
# -> Inputs
# -> Outputs
az storage account create --name $storageAccountName --resource-group $grp --sku Standard_LRS --location $loc

# Batch Account
# * Creating account
# * Signing into the account 
az batch account create --name $batchAccountName --storage-account $storageAccountName --resource-group $grp --location $loc

az batch account login --name $batchAccountName --resource-group $grp --shared-key-auth

# Creating the Pool
# -> Represents the compute cluster
# -> Going with Windows Server VMs
$poolName = "mypool1"
az batch pool create --id $poolName --vm-size standard_d2s_v3 --target-dedicated-nodes 2 --image MicrosoftWindowsServer:WindowsServer:2019-Datacenter:latest --node-agent-sku-id "batch.node.windows amd64"

az batch pool show --pool-id $poolName --query "allocationState"

# Creating Jobs
# A job can contain multiple tasks
az batch job create --id myjob --pool-id $poolName

$taskIds = 1, 2, 3, 4

foreach($i in $taskIds){
    az batch task create --task-id mytask$i --job-id myjob --command-line "cmd /c 'echo $i'"
}

# Displaying Tasks
az batch task show --job-id myjob --task-id mytask1

az batch task file list --job-id myjob --task-id mytask1 --output table

# Don't forget to;
# Clean up the resources after experimenting!
az group delete --resource-group $grp