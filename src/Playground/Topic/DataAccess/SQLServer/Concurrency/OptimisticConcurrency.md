# Optimistic Concurrency

## Approach
- No locking
- Check version before update

## Example
UPDATE Products
SET Name = @Name
WHERE Id = @Id AND RowVersion = @OldVersion

## Pros
- High scalability
- No blocking

## Cons
- Requires retry logic

## Interview Insight
Preferred for web applications due to better throughput.