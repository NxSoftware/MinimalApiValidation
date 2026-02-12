using Immediate.Apis.Shared;
using Immediate.Handlers.Shared;
using Immediate.Validations.Shared;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MinimalApiValidation.ImmediateValidationsEndpoints;

[Validate]
public sealed partial class ImmediateValidationsRequestBody : IValidationTarget<ImmediateValidationsRequestBody>
{
    [Immediate.Validations.Shared.MinLength(3)]
    public string Name { get; init; }
}

public sealed class ImmediateValidationsUpdateUserRequestAsParameters
{
    [FromRoute]
    public Guid UserId { get; init; }
        
    [FromBody]
    public ImmediateValidationsRequestBody Body { get; init; }
}

[Handler]
[MapPut("/iv/users/asparams/{userId:guid}")]
public sealed partial class UpdateUserValidationsEndpointAsParameters
{
    internal static void CustomizeEndpoint(RouteHandlerBuilder endpoint) => endpoint
        .WithTags("Immediate Validations");

    private ValueTask<Ok> HandleAsync([AsParameters] ImmediateValidationsUpdateUserRequestAsParameters request, CancellationToken token)
    {
        return new ValueTask<Ok>(TypedResults.Ok());
    }
}