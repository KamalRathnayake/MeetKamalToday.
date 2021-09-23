var location = 'eastus'

module storageModule 'storage.bicep'={
  name: 'storageDeploy'
  params: {
    storageAccountName: '20210921demost'
    location: location
  }
}

output storageEndpoint object = storageModule.outputs.storageEndpoint
