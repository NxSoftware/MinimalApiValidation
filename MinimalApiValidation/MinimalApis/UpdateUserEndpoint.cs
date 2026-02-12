using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace MinimalApiValidation.MinimalApis;

public sealed class UpdateUserRequest
{
    [Required] 
    [MinLength(3)]
    public string Name { get; init; }
}

public static class UpdateUserEndpoint
{
    public static WebApplication MapUpdateUserEndpoint(this WebApplication app)
    {
        app.MapPut("/users/{userId:guid}", (
                [FromRoute] Guid userId,
                [FromBody] UpdateUserRequest request,
                CancellationToken cancellationToken) =>
            {
                return TypedResults.Ok();
            })
            .WithTags("Minimal APIs");

        return app;
    }
}