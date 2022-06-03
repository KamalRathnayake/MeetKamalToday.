$grp = "ContainerSTBGProcessRG"
$loc = "eastus"
$st = "stbgproc2022527"
$queue = "myqueue"
$cne = "capps-env"

# creating resource group
az group create --name $grp `
    --location $loc

# azure storage queue configuration
az storage account create --name $st `
    --resource-group $grp `
    --location "$loc" `
    --sku Standard_LRS `
    --kind StorageV2
    
$queueConnectionString = (az storage account show-connection-string -g $grp --name $st `
        --query connectionString `
        --out json)

az storage queue create --name $queue `
    --account-name $st `
    --connection-string $queueConnectionString

# $queueConnectionString = ""
# deploy the template
az deployment group create --resource-group $grp `
    --template-file 'template-withoutscale.json' `
    --parameters queueconnection=$queueConnectionString managedEnvironments_cne_name=$cne

# send messages to the queue
for ($i = 1; $i -lt 10; $i++) {

    Write-Host "$i -> $queue"

    $message = "Queue Message - $i"

    $bytes = [System.Text.Encoding]::Unicode.GetBytes($message)
    $encoded =[Convert]::ToBase64String($bytes)

    az storage message put `
        --content $encoded `
        --queue-name $queue `
        --connection-string $queueConnectionString `
        --output none

}

1..100 | ForEach-Object -Parallel {
    $queue = $($using:queue)
    $queueConnectionString = $($using:queueConnectionString)

    Write-Host "$_ -> $queue"

    $message = "Queue Message X - $_"

    $bytes = [System.Text.Encoding]::Unicode.GetBytes($message)
    $encoded =[Convert]::ToBase64String($bytes)

    az storage message put `
        --content $encoded `
        --queue-name $queue `
        --connection-string $queueConnectionString `
        --output none

} -ThrottleLimit 10