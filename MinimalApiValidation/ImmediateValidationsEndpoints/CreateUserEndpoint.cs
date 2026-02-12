using Immediate.Apis.Shared;
using Immediate.Handlers.Shared;
using Immediate.Validations.Shared;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MinimalApiValidation.ImmediateValidationsEndpoints;

[Validate]
public sealed partial class ImmediateValidationsCreateUserRequest : IValidationTarget<ImmediateValidationsCreateUserRequest>
{
    [Immediate.Validations.Shared.MinLength(3)]
    public string Name { get; init; }
}

[Handler]
[MapPost("/iv/users")]
public sealed partial class CreateUserValidationsEndpoint
{
    internal static void CustomizeEndpoint(RouteHandlerBuilder endpoint) => endpoint
        .WithTags("Immediate Validations");

    private ValueTask<Ok> HandleAsync(ImmediateValidationsCreateUserRequest request, CancellationToken cancellationToken)
    {
        return new ValueTask<Ok>(TypedResults.Ok());
    }
}