using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace MinimalApiValidation.MinimalApis;

public sealed class UpdateUserRequestAsParameters
{
    public sealed class RequestBody
    {
        [Required]
        [MinLength(3)]
        public string Name { get; init; }
    }

    [FromRoute]
    public Guid UserId { get; init; }
        
    [FromBody]
    public RequestBody Body { get; init; }
}

public static class UpdateUserAsParametersEndpoint
{ 
    public static WebApplication MapUpdateUserAsParametersEndpoint(this WebApplication app)
    {
        app.MapPut("/users/asparams/{userId:guid}", (
                [AsParameters] UpdateUserRequestAsParameters request,
                CancellationToken cancellationToken) =>
            {
                return TypedResults.Ok();
            })
            .WithTags("Minimal APIs");

        return app;
    }
}