using System.Net;
using System.Net.Http.Json;
using MinimalApiValidation.Tests.Fixtures;

namespace MinimalApiValidation.Tests.ImmediateValidationsEndpoints;

public class UpdateUserAsParametersEndpointTests : IAsyncLifetime
{
    private TestWebApplicationFactory _factory;
    private HttpClient _client;
    private static readonly Guid TestUserId = Guid.Parse("C547DEF2-56FD-4910-9C2E-6D507F66697A");

    public Task InitializeAsync()
    {
        _factory = new TestWebApplicationFactory();
        _client = _factory.CreateClient();
        return Task.CompletedTask;
    }

    public Task DisposeAsync()
    {
        _client?.Dispose();
        _factory?.Dispose();
        return Task.CompletedTask;
    }

    [Fact]
    public async Task UpdateUserAsParameters_WithValidName_Returns200()
    {
        // Arrange
        var request = new { name = "John Doe" };

        // Act
        var response = await _client.PutAsJsonAsync($"/iv/users/asparams/{TestUserId}", request);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task UpdateUserAsParameters_WithMissingName_Returns400()
    {
        // Arrange
        var request = new { };

        // Act
        var response = await _client.PutAsJsonAsync($"/iv/users/asparams/{TestUserId}", request);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task UpdateUserAsParameters_WithShortName_Returns400()
    {
        // Arrange
        var request = new { name = "Jo" };

        // Act
        var response = await _client.PutAsJsonAsync($"/iv/users/asparams/{TestUserId}", request);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}

