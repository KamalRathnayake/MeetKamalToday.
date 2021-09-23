param suffix string = 'loops'
var regions = ['eastus'
               'eastus2'
               'southcentralus'
               'westus2'
               'westus3'
               'australiaeast'
               'southeastasia'
               'northeurope'
               'uksouth'
               'westus'
               ]

resource storageAccount 'Microsoft.Storage/storageAccounts@2019-06-01' = [for (region, i) in regions: {
  name: '${suffix}${region}${i}'
  location: region
  sku: {
    name: 'Standard_LRS'
  }
  kind: 'StorageV2'
  properties: {
    accessTier: 'Hot'
  }
}]
