using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace MinimalApiValidation.MinimalApis;

public sealed class CreateUserRequest
{
    [Required]
    [MinLength(3)]
    public string Name { get; init; }
}

public static class CreateUserEndpoint
{
    public static WebApplication MapCreateUserEndpoint(this WebApplication app)
    {
        app.MapPost("/users", (
                [FromBody] CreateUserRequest request,
                CancellationToken cancellationToken) =>
            {
                return TypedResults.Ok();
            })
            .WithTags("Minimal APIs");

        return app;
    }
}