using MinimalApiValidation;
using MinimalApiValidation.MinimalApis;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add global exception handler for Immediate Validations exceptions.
// This will catch any ValidationException thrown by the validation
// handlers and return a 400 Bad Request response.
builder.Services.AddExceptionHandler<ImmediateValidationsExceptionHandler>();

builder.Services.AddOpenApi();

// Immediate.Handlers / Apis
builder.Services.AddMinimalApiValidationBehaviors();
builder.Services.AddMinimalApiValidationHandlers();

// Minimal API Validation
builder.Services.AddValidation();

var app = builder.Build();

app.UseExceptionHandler("/Error");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

// Map all endpoints
app.MapCreateUserEndpoint()
    .MapUpdateUserEndpoint()
    .MapUpdateUserAsParametersEndpoint()
    .MapMinimalApiValidationEndpoints();

app.Run();