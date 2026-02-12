using MinimalApiValidation;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

// Immediate.Handlers / Apis
builder.Services.AddMinimalApiValidationBehaviors();
builder.Services.AddMinimalApiValidationHandlers();

builder.Services.AddValidation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapEndpoints();
app.MapMinimalApiValidationEndpoints();

app.Run();