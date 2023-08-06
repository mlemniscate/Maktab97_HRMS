namespace Domain.Exception;

public class LeaveNotAllowedException : DomainException
{
    public override string Message => "This employee leaves finished and cannot use another leave.";
}