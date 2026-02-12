using System.ComponentModel.DataAnnotations;
using Immediate.Apis.Shared;
using Immediate.Handlers.Shared;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MinimalApiValidation.ImmediateEndpoints;

public sealed class ImmediateCreateUserRequest
{
    [Required]
    [MinLength(3)]
    public string Name { get; init; }
}

[Handler]
[MapPost("/immediate/users")]
public sealed partial class CreateUserEndpoint
{
    private ValueTask<Ok> HandleAsync(ImmediateCreateUserRequest request, CancellationToken cancellationToken)
    {
        return new ValueTask<Ok>(TypedResults.Ok());
    }


    // app.MapPost("/users", (CreateUserRequest request) => TypedResults.Ok());
    // app.MapPut("/users/{userId:guid}", (Guid userId, UpdateUserRequest request) => TypedResults.Ok());
    // app.MapPut("/users/asparams/{userId:guid}", ([AsParameters] UpdateUserRequestAsParameters request) => TypedResults.Ok());
}