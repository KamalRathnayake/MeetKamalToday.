param suffix string = uniqueString(resourceGroup().id)
resource storageAccount 'Microsoft.Storage/storageAccounts@2019-06-01' = {
  name: '${suffix}storage'
  location: 'eastus'
  sku: {
    name: 'Standard_LRS'
  }
  kind: 'StorageV2'
  properties: {
    accessTier: 'Hot'
  }
}
output out1 string = '123456'
