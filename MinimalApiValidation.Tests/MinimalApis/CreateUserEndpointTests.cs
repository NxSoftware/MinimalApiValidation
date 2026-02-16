using System.Net;
using System.Net.Http.Json;
using MinimalApiValidation.MinimalApis;
using MinimalApiValidation.Tests.Fixtures;

namespace MinimalApiValidation.Tests.MinimalApis;

public class CreateUserEndpointTests : IAsyncLifetime
{
    private TestWebApplicationFactory _factory;
    private HttpClient _client;

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
    public async Task CreateUser_WithValidName_Returns200()
    {
        // Arrange
        var request = new CreateUserRequest { Name = "John Doe" };

        // Act
        var response = await _client.PostAsJsonAsync("/users", request);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task CreateUser_WithMissingName_Returns400()
    {
        // Arrange
        var request = new { };

        // Act
        var response = await _client.PostAsJsonAsync("/users", request);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task CreateUser_WithShortName_Returns400()
    {
        // Arrange
        var request = new CreateUserRequest { Name = "Jo" };

        // Act
        var response = await _client.PostAsJsonAsync("/users", request);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}

