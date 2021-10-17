$grp="AutoFailoverGroupsDemo"
$serverName="myprimaryserver20211015"
$databaseName="mydatabase"
$databaseName2="mydatabase2"

# CREATING RESOURCE GROUP
az group create --name $grp --location southeastasia

# CREATING SQL SERVER
az sql server create -l southeastasia -g $grp -n $serverName -u kamal -p Hello@12345#

# CREATING THE DATABASES
az sql db create --resource-group $grp --server $serverName --name $databaseName --edition Standard --zone-redundant false --backup-storage-redundancy Local
az sql db create --resource-group $grp --server $serverName --name $databaseName2 --edition Standard --zone-redundant false --backup-storage-redundancy Local

# ADDING A FIREWALL RULE TO CONNECT
az sql server firewall-rule create --name allowingall --server $serverName --resource-group $grp --start-ip-address 0.0.0.0 --end-ip-address 255.255.255.255

# DISPLAYING INFORMATION
az sql server show --name $serverName --resource-group $grp --output json --query '[fullyQualifiedDomainName, administratorLogin]'



# SAMPLE DATA
CREATE TABLE Customers(Id INT IDENTITY PRIMARY KEY, Name NVARCHAR(255))
INSERT INTO Customers(Name) VALUES ('Ann')
SELECT * FROM Customers

INSERT INTO Customers(Name) VALUES ('Bob')


$secondaryServerName = 'secondarydatabase20211015'
$fg = 'failovergroup202110'

Switch-AzSqlDatabaseFailoverGroup -ResourceGroupName $grp -ServerName $secondaryServerName -FailoverGroupName $fg