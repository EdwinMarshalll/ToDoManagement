using System.Net;
using System.Text.Json;
using ToDoManagement.Application.Exceptions;

namespace ToDoManagement.Api.Middlewares;

public class ManageExceptionsMiddleware
{
    private readonly RequestDelegate _next;

    public ManageExceptionsMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await ManageException(context, ex);
        }
    }


    private Task ManageException(HttpContext context, Exception exception)
    {
        HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";
        var result = string.Empty;

        switch (exception)
        {
            case AppNotFoundException:
                httpStatusCode = HttpStatusCode.NotFound;
                break;
            case ApplicationValidationException validationException:
                httpStatusCode = HttpStatusCode.BadRequest;
                result = JsonSerializer.Serialize(validationException.ValidationErrors);
                break;
        }

        context.Response.StatusCode = (int)httpStatusCode;

        return context.Response.WriteAsync(result); // Escribimos la respuesta hacia el cliente
    }
}

public static class ManagerExceptionsMiddlewareExtensions
{
    public static IApplicationBuilder UseManagerExceptionsMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ManageExceptionsMiddleware>();
    }
}
