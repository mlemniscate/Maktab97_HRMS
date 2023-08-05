namespace Domain.Exception;

public class NationalCodeIsExistException : DomainException
{
    public override string Message => "NationalCode is exist";
}