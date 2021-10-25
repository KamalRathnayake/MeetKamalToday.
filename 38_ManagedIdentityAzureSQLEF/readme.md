```bash
$grp="ManagedIdentityTestRG"
$serverName="sqlserver2021102311"
$databaseName="sqldatabase"
$loc = 'southeastasia'
$appname='managedidentitydemo20211023'
$pln = '05cdntestplan'

# CREATING RESOURCE GROUP
az group create --name $grp --location southeastasia

# CREATING APP SERVICE
az appservice plan create --name $pln --resource-group $grp --location $loc --sku Free
az webapp create --name $appname --plan $pln --resource-group $grp

# CREATING SQL SERVER
az sql server create -l $loc -g $grp -n $serverName -u kamal -p Hello@12345#

# CREATING THE DATABASE
az sql db create --resource-group $grp --server $serverName --name $databaseName --edition Standard --zone-redundant false --backup-storage-redundancy Local

# ADDING A FIREWALL RULE TO CONNECT
az sql server firewall-rule create --name allowingall --server $serverName --resource-group $grp --start-ip-address 0.0.0.0 --end-ip-address 255.255.255.255

# DISPLAYING INFORMATION
az sql server show --name $serverName --resource-group $grp --output json --query '[fullyQualifiedDomainName, administratorLogin]'

#SQL
CREATE TABLE Customers(Id INT IDENTITY PRIMARY KEY, Name NVARCHAR(255))
INSERT INTO Customers(Name) VALUES ('Ann')
INSERT INTO Customers(Name) VALUES ('Bob')
SELECT * FROM Customers

create user [managedidentitydemo20211023] from external provider;
alter role db_datareader add member [managedidentitydemo20211023];
alter role db_datawriter add member [managedidentitydemo20211023];
```
