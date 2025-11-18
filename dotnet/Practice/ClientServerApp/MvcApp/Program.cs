using Microsoft.Extensions.Options;
using MvcApp.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddOptions<WebApiOptions>()
    .Configure((options) =>
    {
        System.Console.WriteLine("Options");
        var baseAddress = builder.Configuration["HttpClient:BaseAddress"];

        ArgumentNullException.ThrowIfNullOrWhiteSpace(baseAddress);

        options.BaseAddress = baseAddress;
    });

builder.Services.AddHttpClient("WebApi", (serviceProvider, httpClient) =>
{
    var scope = serviceProvider.CreateScope();

    var options = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<WebApiOptions>>();
    httpClient.BaseAddress = new Uri(options.Value.BaseAddress);
    System.Console.WriteLine("HttpClient");
});

var app = builder.Build();

app.UseExceptionHandler("/Home/Error");

app.UseRouting();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();