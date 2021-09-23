var demoPrefix = 'demo20210924'

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
