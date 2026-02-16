using System.ComponentModel.DataAnnotations;
using Immediate.Apis.Shared;
using Immediate.Handlers.Shared;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Validation;

namespace MinimalApiValidation.ImmediateEndpoints;

#pragma warning disable ASP0029 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
[ValidatableType]
#pragma warning restore ASP0029 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
public sealed class ImmediateRequestBody
{
    [Required]
    [MinLength(3)]
    public string Name { get; init; }
}

#pragma warning disable ASP0029 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
[ValidatableType]
#pragma warning restore ASP0029 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
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