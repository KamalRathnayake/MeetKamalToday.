# What is Azure SQL Geo-Replication?
    - Why? the use cases
    - How it works underneath?
      - How the data is transferred
      - The latency
      - Limits
    - Enabling geo-replication for your database


## Creating a database
```bash
# DEFINING VARIABLES
$grp="AzureSQLGeoReplicationDemo"
$serverName="myprimaryserver20210815"
$databaseName="mydatabase"

# CREATING RESOURCE GROUP
az group create --name $grp --location southeastasia

# CREATING SQL SERVER
az sql server create -l southeastasia -g $grp -n $serverName -u kamal -p Hello@12345#

# CREATING THE DATABASE
az sql db create --resource-group $grp --server $serverName --name $databaseName --edition Standard --zone-redundant false --backup-storage-redundancy Local

# ADDING A FIREWALL RULE TO CONNECT
az sql server firewall-rule create --name allowingall --server $serverName --resource-group $grp --start-ip-address 0.0.0.0 --end-ip-address 255.255.255.255

# DISPLAYING INFORMATION
az sql server show --name $serverName --resource-group $grp --output json --query '[fullyQualifiedDomainName, administratorLogin]'


```
## Adding Sample Data
```sql
CREATE TABLE Customers(Id INT IDENTITY PRIMARY KEY, Name NVARCHAR(255))
INSERT INTO Customers(Name) VALUES ('Ann')
INSERT INTO Customers(Name) VALUES ('Bob')
SELECT * FROM Customers
```
