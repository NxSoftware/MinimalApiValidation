using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace MinimalApiValidation;

public static class Endpoints
{
    public sealed class CreateUserRequest
    {
        [Required]
        [MinLength(3)]
        public string Name { get; init; }
    }

    public sealed class UpdateUserRequest
    {
        [Required] 
        [MinLength(3)]
        public string Name { get; init; }
    }
    
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
    
    public static void MapEndpoints(this WebApplication app)
    {
        app.MapPost("/users", (
            [FromBody] CreateUserRequest request,
            CancellationToken cancellationToken) =>
        {
            return TypedResults.Ok();
        });
        
        app.MapPut("/users/{userId:guid}", (
            [FromRoute] Guid userId,
            [FromBody] UpdateUserRequest request, 
            CancellationToken cancellationToken) =>
        {
            return TypedResults.Ok();
        });
        
        app.MapPut("/users/asparams/{userId:guid}", (
            [AsParameters] UpdateUserRequestAsParameters request,
            CancellationToken cancellationToken) =>
        {
            return TypedResults.Ok();
        });
    }
}