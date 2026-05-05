# Azure SQL Logical Server

## What it is
A management layer for SQL databases.

## Responsibilities
- Authentication (SQL login / Azure AD)
- Firewall rules
- Connection settings

## Important
- It does NOT store data
- Databases exist inside it

## Security
- Restrict access via firewall
- Prefer Azure AD authentication

## Common Mistake
Confusing it with actual database