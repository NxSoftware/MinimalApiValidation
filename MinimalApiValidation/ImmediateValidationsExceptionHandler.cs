using Immediate.Validations.Shared;
using Microsoft.AspNetCore.Diagnostics;

namespace MinimalApiValidation;

internal sealed class ImmediateValidationsExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        if (exception is not ValidationException validationException)
        {
            return false;
        }

        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        
        // Doesn't matter about the body for this demonstration, as long as the status code is correct.
        await httpContext.Response.WriteAsJsonAsync(new
        {
            Title = "Validation Failed"
        }, cancellationToken);

        return true;
    }
}