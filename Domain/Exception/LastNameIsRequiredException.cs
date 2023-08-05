namespace Domain.Exception;

public class LastNameIsRequiredException : DomainException
{
    public override string Message => "LastName is required";
}