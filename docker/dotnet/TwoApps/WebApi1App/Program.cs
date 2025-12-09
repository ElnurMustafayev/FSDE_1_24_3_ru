var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddHttpClient("KeyWebApi", httpClientConfiguration =>
{
    var baseAddress = builder.Configuration["KeyWebApiBaseAddress"];
    ArgumentNullException.ThrowIfNullOrWhiteSpace(baseAddress);

    httpClientConfiguration.BaseAddress = new Uri(baseAddress);
});

var app = builder.Build();

app.MapOpenApi();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();