/* 
az deployment sub create --name SagaOrchestratedSample --location eastus2 --template-file main.bicep
az deployment sub what-if --name SagaOrchestratedSample --location eastus2 --template-file main.bicep
az group delete --name rg-saga-orchestrated-sample-eastus2
*/

// Scope
targetScope = 'subscription'

// Default Location
param defaultLocation string = deployment().location

// Shared Variables
var workflowName = 'saga-orchestrated-sample'
var rgDefaultName = 'rg-${workflowName}-<REGION>'

// Resource Group Variables
var rgName = replace(rgDefaultName, '<REGION>', defaultLocation)

// Service Bus Variables
var serviceBusNamespaceDefaultName = 'sbn-${workflowName}-<REGION>'
var serviceBusQueueDefaultName = 'sbq-<QUEUE>-<REGION>'
var serviceBusSku = 'Basic'
var serviceBusNamespaceName = replace(serviceBusNamespaceDefaultName, '<REGION>', defaultLocation)
var serviceBusQueuesNames = [
  replace(replace(serviceBusQueueDefaultName, '<QUEUE>', 'reply'), '<REGION>', defaultLocation)
  replace(replace(serviceBusQueueDefaultName, '<QUEUE>', 'execute-payment'), '<REGION>', defaultLocation)
]

// Service Bus Variables
var sqlServerDefaultName = 'sqls-${workflowName}-<REGION>'
var sqlServerName = replace(sqlServerDefaultName, '<REGION>', defaultLocation)
var sqlServerDatabaseDefaultName = 'sqld-${workflowName}-<REGION>'
var sqlServeDatabaserName = replace(sqlServerDatabaseDefaultName, '<REGION>', defaultLocation)
var administratorLogin = 'admindeal'
var administratorLoginPassword = 'Teste123!'

resource rg 'Microsoft.Resources/resourceGroups@2020-10-01' = {
  location: defaultLocation
  name: rgName
}

module serviceBusModule 'Modules/serviceBusModule.bicep' = {
  name: 'serviceBusModule'
  scope: rg
  params:{
    queuesNames: serviceBusQueuesNames
    namespaceName: serviceBusNamespaceName
    location: defaultLocation
    sku: serviceBusSku
  }
}

module sqlModule 'Modules/sqlDatabaseModule.bicep' = {
  name: 'sqlModule'
  scope: rg
  params:{
    sqlServerName: sqlServerName
    sqlDBName: sqlServeDatabaserName
    location: defaultLocation
    administratorLogin: administratorLogin
    administratorLoginPassword: administratorLoginPassword
  }
}
