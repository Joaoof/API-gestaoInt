using GestaoInt.Communication.Responses;
using GestaoInt.Exception;
using GestaoInt.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GestaoInt.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception is GestaoIntException)
            {
                HandleProjectException(context);
            }
            else
            {
                ThrowUnkowError(context);
            }
        }

        private void HandleProjectException(ExceptionContext context)
        {
            var gestaoIntException = (GestaoIntException)context.Exception;

            var errorResponse = new ResponseErrorJson(gestaoIntException.GetErrors());

            context.HttpContext.Response.StatusCode = gestaoIntException.StatusCode;
            context.Result = new ObjectResult(errorResponse);
        }

        private void ThrowUnkowError(ExceptionContext context)
        {
            var errorResponse = new ResponseErrorJson(ResourceErrorMessages.UNKNOWN_ERROR);

            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(errorResponse);
        }
    }
}
