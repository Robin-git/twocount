using twocount.domain.Core;
using twocount.domain.ValueObjects;

namespace twocount.domain.Twocount.Entities;

public class Expense : IAggregate
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Guid UserId { get; init; }
    public Amount Amount { get; init; } = new();
    public DateTime CreatedAt = DateTime.Now;
    public bool Refunded { get; private set; } = false;
    
    internal Expense() { }
}