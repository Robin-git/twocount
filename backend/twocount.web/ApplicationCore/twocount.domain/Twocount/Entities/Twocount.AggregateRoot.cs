using CSharpFunctionalExtensions;
using twocount.domain.Core;
using twocount.domain.ValueObjects;

namespace twocount.domain.Twocount.Entities;

public class Twocount : IAggregateRoot
{
    public Guid Id { get; init; } = Guid.NewGuid();
    
    public TwocountUsers Users { get; private set; }
    
    private readonly List<Expense> _expenses = new();
    public IEnumerable<Expense> Expenses => _expenses;

    public Twocount(TwocountUsers users)
    {
        Users = users;
    }

    public Result AddExpense(Guid userId, decimal value)
    {
        if (!UserIncludedInThis(userId))
        {
            return Result.Failure("User not included in this Twocount");
        }

        var expense = new Expense
        {
            UserId = userId,
            Amount = new Amount(value),
        };
        _expenses.Add(expense);

        return Result.Success();
    }

    private bool UserIncludedInThis(Guid userId) => userId == Users.User1 || userId == Users.User2;
}