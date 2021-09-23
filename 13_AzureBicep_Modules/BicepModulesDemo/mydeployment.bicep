module storageModule 'storage.bicep' = {
  name: 'storageDeploy'
  params: {
    storageAccountName: 'mdemo20210921'
    location: 'eastus'
  }
}

output storageEndpoint object = storageModule.outputs.storageEndpoint
