namespace GestaoInt.Exception.ExceptionsBase;

public abstract class GestaoIntException: SystemException
{
    protected GestaoIntException(string message): base(message)
    {

    }

    public abstract int StatusCode { get; }
    public abstract List<string> GetErrors();
}
