
$grp="SBSessionsTestRG"
$location="southeastasia"
$serverName="sampledbserver20211201"
$databaseName="sampledb"
$storageAccountName="funcappstorage20211201"
$funcapp="consumer20211201"
$sbNamespaceName="sessionsdemo"

# CREATE RESOURCE GROUP
az group create --name $grp --location $location --tags CreatedBy=kamalr@99x.io

# CREATING SQL SERVER
az sql server create -l southeastasia -g $grp -n $serverName -u kamal -p Hello@12345#
az sql db create --resource-group $grp --server $serverName --name $databaseName --edition Standard --zone-redundant false --backup-storage-redundancy Local
az sql server firewall-rule create --name allowingall --server $serverName --resource-group $grp --start-ip-address 0.0.0.0 --end-ip-address 255.255.255.255
az sql server show --name $serverName --resource-group $grp --output json --query '[fullyQualifiedDomainName, administratorLogin]'

# CREATING SERVICE BUS
az servicebus namespace create --resource-group $grp --name $sbNamespaceName --location $location --sku Basic

# FUNCTION APP
az storage account create --name $storageAccountName --resource-group $grp
az functionapp create --name $funcapp --resource-group $grp --consumption-plan-location westus --os-type Windows --runtime dotnet --storage $storageAccountName

#SQL
CREATE TABLE SessionMessages(Id INT PRIMARY KEY IDENTITY, InputId INT);
CREATE TABLE Messages(Id INT PRIMARY KEY IDENTITY, InputId INT);


SELECT count(*) FROM SessionMessages
SELECT count(*) FROM Messages

DROP TABLE SessionMessages
DROP TABLE Messages


SELECT count(*) FROM SessionMessages WHERE Id = InputId
SELECT * FROM Messages WHERE Id <> InputId