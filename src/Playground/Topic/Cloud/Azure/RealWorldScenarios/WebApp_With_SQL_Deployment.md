# Web App with Azure SQL Deployment

## Architecture

Client → App Service → Azure SQL Database

## Components

- Resource Group → groups all resources
- App Service Plan → provides compute
- App Service → hosts API
- SQL Logical Server → manages DB access
- SQL Database → stores data

## Flow

1. Client sends request
2. App Service processes request
3. Queries SQL Database
4. Returns response

## Failure Scenarios

### DB Slow
- API response time increases
- Fix: indexing, scaling DB

### App Service Overload
- High CPU → slow responses
- Fix: scale out instances

### Connection Failure
- Firewall misconfiguration
- Fix: allow Azure services / use private endpoint

## Improvements

- Add Redis Cache → reduce DB load
- Add Service Bus → async processing
- Add Application Insights → monitoring

## Security

- Use Managed Identity
- Store secrets in Key Vault
- Restrict DB access via firewall