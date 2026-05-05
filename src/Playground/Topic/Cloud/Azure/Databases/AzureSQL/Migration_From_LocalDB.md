# Migration from Local SQL Server to Azure SQL Database

## Objective
Move an existing on-premise/local SQL Server database to Azure SQL Database with minimal downtime and data loss.

---

## Architecture

Local DB → Migration Tool → Azure SQL Logical Server → Azure SQL Database

---

## Key Components

- SQL Logical Server → manages authentication, firewall, connections
- SQL Database → actual data storage
- Migration Tool → moves schema + data

---

## Step 1: Prepare Azure SQL

1. Create Azure SQL Logical Server
2. Configure:
   - Server admin login
   - Firewall rules (allow your IP or Azure services)

3. Create Azure SQL Database

---

## Step 2: Assess Compatibility

Use:
- Data Migration Assistant (DMA)

Check:
- Unsupported features (SQL Agent, cross-database queries, etc.)
- Compatibility issues

---

## Step 3: Choose Migration Approach

### Option 1: BACPAC (Simple, Small DB)

- Export local DB → .bacpac
- Import into Azure SQL

✔ Easy  
❌ Not for large DBs  

---

### Option 2: Azure Database Migration Service (DMS)

✔ Online/offline migration  
✔ Supports large databases  

Use for:
- Production systems  
- Minimal downtime  

---

### Option 3: SQL Scripts (Manual)

- Generate schema scripts
- Insert data manually

✔ Full control  
❌ Time-consuming  

---

## Step 4: Perform Migration

### Using BACPAC

1. Export from SSMS:
   Tasks → Export Data-tier Application

2. Import into Azure:
   SSMS → Import BACPAC

---

## Step 5: Update Application

Change connection string:

```csharp
Server=tcp:<server>.database.windows.net;
Database=<db>;
User Id=<user>;
Password=<password>;
Encrypt=True;