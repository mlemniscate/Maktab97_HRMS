namespace Domain.Exception;

public class FromDateBiggerThenToDateException : DomainException
{
    public override string Message => "FromDate must not be bigger then ToDate";
}