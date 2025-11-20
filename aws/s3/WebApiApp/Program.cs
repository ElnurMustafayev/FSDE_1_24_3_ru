using Amazon;
using Amazon.S3;
using Microsoft.Extensions.Options;
using WebApiApp.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();

builder.Services.AddOptions<S3Options>()
    .Configure(options =>
    {
        options.Region = "us-east-1";
        options.Bucket = "stepit-test-bucket";
    });

builder.Services.AddSingleton<IAmazonS3>((serviceProvider) =>
{
    var options = serviceProvider.GetRequiredService<IOptions<S3Options>>().Value;
    var config = new AmazonS3Config()
    {
        RegionEndpoint = RegionEndpoint.GetBySystemName(options.Region),
    };

    return new AmazonS3Client(config);
});

var app = builder.Build();

app.MapOpenApi();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();