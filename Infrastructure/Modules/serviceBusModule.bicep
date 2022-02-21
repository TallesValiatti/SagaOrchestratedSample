@description('Specify the name of the Service Bus namespace')
param namespaceName string

@description('Specify the location')
param location string = resourceGroup().location

@description('Specify the queues')
param queuesNames array

@allowed([
  'Basic'
  'Standard'
  'Premium'
])
@description('Specify the sku')
param sku string

resource serviceBusNamespace 'Microsoft.ServiceBus/namespaces@2017-04-01' = {
  name: namespaceName
  location: location
  sku: {
    name: sku
  }
  properties: {}
}

resource serviceBusQueue 'Microsoft.ServiceBus/namespaces/queues@2017-04-01' = [for queueName in queuesNames:  {
  parent: serviceBusNamespace
  name: queueName
  properties: {
    lockDuration: 'PT5M'
    maxSizeInMegabytes: 1024
    requiresDuplicateDetection: false
    requiresSession: false
    deadLetteringOnMessageExpiration: false
    duplicateDetectionHistoryTimeWindow: 'PT10M'
    maxDeliveryCount: 10
    enablePartitioning: false
    enableExpress: false
  }
}]
