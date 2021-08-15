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
$grp="SampleSQLRG"
$serverName="myserver20210801"
$databaseName="mydb1"

# CREATING RESOURCE GROUP
az group create --name $grp --location southeastasia

# CREATING SQL SERVER
az sql server create -l southeastasia -g $grp -n $serverName -u kamal -p Hello@12345#

# CREATING THE DATABASE
az sql db create --resource-group $grp --server $serverName --name $databaseName --edition Standard --zone-redundant false --backup-storage-redundancy Local
```
## ADDING SAMPLE DATA
```sql
CREATE TABLE Customers(Id INT IDENTITY PRIMARY KEY, Name NVARCHAR(255))
INSERT INTO Customers(Name) VALUES ('Ann')

INSERT INTO Customers(Name) VALUES ('Bob')
```
