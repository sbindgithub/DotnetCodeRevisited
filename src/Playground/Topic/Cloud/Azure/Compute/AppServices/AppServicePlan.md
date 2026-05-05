# App Service Plan

## What it is
Defines compute resources (CPU, RAM) for App Services.

## Key Concept
- You pay for the plan, not the app
- Multiple apps can share one plan

## Pricing Tiers
- Free / Shared → Dev/Test
- Basic / Standard → Small apps
- Premium → Production (autoscale, VNET)

## Scaling
- Scale Up → Increase CPU/RAM
- Scale Out → Increase instances

## Critical Behavior
If multiple apps share same plan:
- High load in one app affects others

## When to Use Separate Plan
- High traffic app
- Different scaling requirements
- Isolation needed