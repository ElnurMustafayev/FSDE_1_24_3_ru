using WebApiApp.Mocks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapPost("/api/test", () =>
{
    return Results.Ok(ProductsMock.Value);
});

app.MapOpenApi();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();