# What is Azure SQL Geo-Replication?
    - Why? the use cases
    - How it works underneath?
      - How the data is transferred
      - The latency
      - Limits
    - Enabling geo-replication for your database


## Creating a database
`$grp="SampleSQLRG"`

`$serverName="myserver20210801"`

`$databaseName="mydb1"`

`az group create --name $grp --location southeastasia`

`az sql server create -l southeastasia -g $grp -n $serverName -u kamal -p Hello@12345#`

`az sql db create --resource-group $grp --server $serverName --name $databaseName --edition Standard --zone-redundant false --backup-storage-redundancy Local`
