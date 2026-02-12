using System.ComponentModel.DataAnnotations;
using Immediate.Apis.Shared;
using Immediate.Handlers.Shared;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MinimalApiValidation.ImmediateEndpoints;

public sealed class ImmediateRequestBody
{
    [Required]
    [MinLength(3)]
    public string Name { get; init; }
}

public sealed class ImmediateUpdateUserRequestAsParameters
{
    [FromRoute]
    public Guid UserId { get; init; }
        
    [FromBody]
    public ImmediateRequestBody Body { get; init; }
}

[Handler]
[MapPut("/ia/users/asparams/{userId:guid}")]
public sealed partial class UpdateUserEndpointAsParameters
{
    internal static void CustomizeEndpoint(RouteHandlerBuilder endpoint) => endpoint
        .WithTags("Immediate.Apis");

    private ValueTask<Ok> HandleAsync([AsParameters] ImmediateUpdateUserRequestAsParameters request, CancellationToken token)
    {
        return new ValueTask<Ok>(TypedResults.Ok());
    }
}