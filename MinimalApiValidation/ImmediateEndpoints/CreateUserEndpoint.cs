using System.ComponentModel.DataAnnotations;
using Immediate.Apis.Shared;
using Immediate.Handlers.Shared;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Validation;

namespace MinimalApiValidation.ImmediateEndpoints;

#pragma warning disable ASP0029 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
[ValidatableType]
#pragma warning restore ASP0029 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
public sealed class ImmediateCreateUserRequest
{
    [Required]
    [MinLength(3)]
    public string Name { get; init; }
}

[Handler]
[MapPost("/ia/users")]
public sealed partial class CreateUserEndpoint
{
    internal static void CustomizeEndpoint(RouteHandlerBuilder endpoint) => endpoint
        .WithTags("Immediate.Apis");

    private ValueTask<Ok> HandleAsync(ImmediateCreateUserRequest request, CancellationToken cancellationToken)
    {
        return new ValueTask<Ok>(TypedResults.Ok());
    }
}