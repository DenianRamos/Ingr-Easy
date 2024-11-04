using System.Net;
using IngrEasy.Communication.Response;
using IngrEasy.Exception.ExceptionBase;
using IngrEasy.Exception.Resources.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IngrEasy.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is IngrEasyException)
            HandlerException(context);
        else
            ThrowUnknowException(context);
    }

    private void HandlerException(ExceptionContext context)
    {
        if (context.Exception is ErrorOnValidationException exception)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Result = new BadRequestObjectResult(new ResponseErrorJson(exception.Errors));
        }
    }
    
    private void ThrowUnknowException(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Result = new ObjectResult(new ResponseErrorJson(ResourcesErrorMessage.UNKNOW_ERROR));
    }
}