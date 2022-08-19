namespace twocount.infrastructure.Identity.Exceptions;

[Serializable]
public class CannotLoginException : Exception
{
    public CannotLoginException() : base($"Invalid Username or password")
    {
    }
}