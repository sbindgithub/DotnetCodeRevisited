# Isolation Levels

## Levels
- Read Uncommitted → Dirty reads
- Read Committed → Default
- Repeatable Read → No non-repeatable reads
- Serializable → Strictest, locks range
- Snapshot → Row versioning

## Trade-off
Consistency vs Performance

## Interview Insight
Most systems use Read Committed or Snapshot.
Serializable is rarely used due to locking overhead.