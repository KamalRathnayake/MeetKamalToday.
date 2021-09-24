// DEFINING VARIABLES
var demoPrefix = 'demo20210924'
var loc = resourceGroup().location

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
          'name': 'FUNCTIONS_EXTENSION_VERSION'
          'value': '~3'
        }
        {
          'name': 'FUNCTIONS_WORKER_RUNTIME'
          'value': 'dotnet'
        }
    }
  }

  dependsOn: [
    hostingPlan
    storageAccountForFunctions
  ]
}
