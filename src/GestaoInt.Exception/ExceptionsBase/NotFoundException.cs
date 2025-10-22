using System.Net;

namespace GestaoInt.Exception.ExceptionsBase;

public class NotFoundException : GestaoIntException
{
    public NotFoundException(string message) : base(message)
    {
    }

    public override int StatusCode => (int)HttpStatusCode.NotFound;

    public override List<string> GetErrors()
    {
        return [Message];
    }
}