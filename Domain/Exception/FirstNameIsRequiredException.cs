namespace Domain.Exception;

public class FirstNameIsRequiredException : DomainException
{
    public override string Message => "FirstName is required";
}