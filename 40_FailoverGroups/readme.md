$grp="AutoFailoverGroupsDemo"
$serverName="myprimaryserver20211028"
$secondaryServerName="mysecondaryserver20211028"
$databaseName="mydatabase"
$databaseName2="mydatabase2"

# CREATING RESOURCE GROUP
az group create --name $grp --location southeastasia

# CREATING SQL SERVER - SOUTEASTASIA
az sql server create -l southeastasia -g $grp -n $serverName -u kamal -p Hello@12345#
az sql server firewall-rule create --name allowingall --server $serverName --resource-group $grp --start-ip-address 0.0.0.0 --end-ip-address 255.255.255.255

# CREATING SQL SERVER - EASTUS
az sql server create -l eastus -g $grp -n $secondaryServerName -u kamal -p Hello@12345#
az sql server firewall-rule create --name allowingall --server $secondaryServerName --resource-group $grp --start-ip-address 0.0.0.0 --end-ip-address 255.255.255.255

# CREATING THE DATABASES - SOUTEASTASIA
az sql db create --resource-group $grp --server $serverName --name $databaseName --edition Standard --zone-redundant false --backup-storage-redundancy Local
az sql db create --resource-group $grp --server $serverName --name $databaseName2 --edition Standard --zone-redundant false --backup-storage-redundancy Local

# DISPLAYING INFORMATION
az sql server show --name $serverName --resource-group $grp --output json --query '[fullyQualifiedDomainName, administratorLogin]'



# SAMPLE DATA
CREATE TABLE Customers(Id INT IDENTITY PRIMARY KEY, Name NVARCHAR(255))
INSERT INTO Customers(Name) VALUES ('Ann')
INSERT INTO Customers(Name) VALUES ('Bob')

SELECT * FROM Customers