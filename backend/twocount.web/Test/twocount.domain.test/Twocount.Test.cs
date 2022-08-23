using CSharpFunctionalExtensions;
using FluentAssertions;
using twocount.domain.Twocount.Entities;

namespace twocount.domain.test;

public class TwocountTest
{
    [Fact]
    public void AddExpense_ShouldPass()
    {
        var user1 = Guid.NewGuid();
        var user2 = Guid.NewGuid();
        var tc = new Twocount.Entities.Twocount(new TwocountUsers(user1, user2));
        Assert.Equal(Result.Success(), tc.AddExpense(user1, 40.0m));
        Assert.Equal(Result.Success(), tc.AddExpense(user2, 50.0m));
        Assert.Equal(Result.Success(), tc.AddExpense(user1, 10.0m));
        Assert.Equal(3, tc.Expenses.Count());
    }
    
    [Fact]
    public void AddExpense_ShouldNotPass()
    {
        var user1 = Guid.NewGuid();
        var user2 = Guid.NewGuid();
        var tc = new Twocount.Entities.Twocount(new TwocountUsers(user1, user2));
        Assert.False(tc.AddExpense(Guid.NewGuid(), 40.0m).IsSuccess);
        Assert.False(tc.AddExpense(Guid.NewGuid(), 50.0m).IsSuccess);
    }
}