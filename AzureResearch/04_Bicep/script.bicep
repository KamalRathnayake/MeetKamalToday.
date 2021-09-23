var year = 20210922
var suffix = 'prod${year}'
var loc = 'southeastasia'
var regions = ['eastus'
'eastus2'
'westus'
'westeurope'
'eastasia'
'southeastasia'
'japaneast'
'japanwest'
'northcentralus'
'southcentralus'
'centralus'
'northeurope'
'brazilsouth'
'australiaeast'
'australiasoutheast'
'southindia'
'centralindia'
'westindia'
'canadaeast'
'norwayeast'
]


// resource storageAccounts 'Microsoft.Storage/storageAccounts@2019-06-01' = [for i in range(0,20): {
//   name: '${suffix}storage${i}'
//   location: 'eastus'
//   sku: {
//     name: 'Standard_LRS'
//   }
//   kind: 'StorageV2'
//   properties: {
//     accessTier: 'Hot'
//   }
// }]

resource storageAccounts 'Microsoft.Storage/storageAccounts@2019-06-01' = [for i in regions:{
  name: '2133st${i}'
  location: i
  sku: {
    name: 'Standard_LRS'
  }
  kind: 'StorageV2'
  properties: {
    accessTier: 'Hot'
  }
}]

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

resource appPlan 'Microsoft.Web/serverfarms@2021-01-15' = {
  location: loc
  name:'sampleplan'
  sku:{
    name:'F1'
  }
}

resource appService 'Microsoft.Web/sites@2021-01-15' = {
  name: '${suffix}myapp'
  dependsOn: [
    appPlan
  ]
  location: loc
  properties: {
    serverFarmId:appPlan.id
  }
}

output hostname string = '${appService.name}.azurewebsites.net'
