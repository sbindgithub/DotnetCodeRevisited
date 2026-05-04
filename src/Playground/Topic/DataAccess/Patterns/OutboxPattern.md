# Outbox Pattern

## Problem
DB update succeeds, message publish fails → inconsistency

## Solution
- Save event in DB (Outbox table)
- Background job publishes events

## Benefits
- Ensures eventual consistency

## Interview Insight
Critical in microservices to guarantee reliable messaging.