// DEFINING VARIABLES
var demoPrefix = 'demo20210924'
var loc = resourceGroup().location

// CREATING THE WEBAPP
resource appServicePlan 'Microsoft.Web/serverfarms@2021-01-15' = {
  location: loc
  name:'${demoPrefix}plan'
  sku:{
    name:'F1'
  }
}
resource appService 'Microsoft.Web/sites@2021-01-15' = {
  name: '${demoPrefix}myapp'
  dependsOn: [
    appServicePlan
  ]
  location: loc
  properties: {
    serverFarmId: appServicePlan.id
  }
}

// CREATING SERVICE BUS QUEUE
resource serviceBusNamespace 'Microsoft.ServiceBus/namespaces@2021-06-01-preview' = {
  name: '${demoPrefix}sbnamespace'
  location: loc
  sku: {
    name: 'Basic'
  }
  tags: {
    CreatedBy: 'kamalr@99x.io'
  }
}
resource serviceBusQueue 'Microsoft.ServiceBus/namespaces/queues@2021-06-01-preview'={
  name: 'the-queue'
  parent: serviceBusNamespace
}

// CREATING THE FUNCTION APP

// storage accounts must be between 3 and 24 characters in length and use numbers and lower-case letters only
var storageAccountName = '${substring(demoPrefix,0,10)}${uniqueString(resourceGroup().id)}'  

resource storageAccountForFunctions 'Microsoft.Storage/storageAccounts@2019-06-01' = {
  name: storageAccountName
  location: loc
  kind: 'StorageV2'
  sku: {
    name: 'Standard_LRS'
    tier: 'Standard'
  }
}
resource hostingPlan 'Microsoft.Web/serverfarms@2020-10-01' = {
  name: '${demoPrefix}hplan'
  location: loc
  sku: {
    name: 'F1'
    tier: 'Free'
  }
}
resource functionApp 'Microsoft.Web/sites@2020-06-01' = {
  name: '${demoPrefix}fnapp'
  location: loc
  kind: 'functionapp'
  properties: {
    httpsOnly: true
    serverFarmId: hostingPlan.id
    clientAffinityEnabled: true
    siteConfig: {
      appSettings: [
        {
          name: 'AzureWebJobsStorage'
          value: 'DefaultEndpointsProtocol=https;AccountName=${storageAccountForFunctions.name};EndpointSuffix=${environment().suffixes.storage};AccountKey=${listKeys(storageAccountForFunctions.id, storageAccountForFunctions.apiVersion).keys[0].value}'
        }
        {
          'name': 'FUNCTIONS_EXTENSION_VERSION'
          'value': '~3'
        }
        {
          'name': 'FUNCTIONS_WORKER_RUNTIME'
          'value': 'dotnet'
        }
        {
          name: 'WEBSITE_CONTENTAZUREFILECONNECTIONSTRING'
          value: 'DefaultEndpointsProtocol=https;AccountName=${storageAccount.name};EndpointSuffix=${environment().suffixes.storage};AccountKey=${listKeys(storageAccount.id, storageAccount.apiVersion).keys[0].value}'
        }
      ]
    }
  }

  dependsOn: [
    hostingPlan
    storageAccountForFunctions
  ]
}

// CREATING STORAGE ACCOUNT
resource storageAccount 'Microsoft.Storage/storageAccounts@2021-04-01' = {
  location: loc
  sku: {
    name: 'Standard_LRS'
  }
  name: '${demoPrefix}storage'
  kind: 'StorageV2'
  properties: {
    accessTier: 'Hot'
  }
}
