using System.Globalization;
using Kujira.Api;
using Kujira.Backend.User.Domain;
using Kujira.Backend.User.Persistence;
using Kujira.Gui;
using Kujira.Services;
using Kujira.Shared;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;
using RestEase;

var builder = WebAssemblyHostBuilder.CreateDefault(args);


builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Http Client
builder.Services.AddTransient(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

// MudBlazor Services
builder.Services.AddMudServices();

// Your other services
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<UserApiService>();

// RestEase Service for IKujiraBackendApi
builder.Services.AddSingleton<IKujiraBackendApi>(provider => RestClient.For<IKujiraBackendApi>(new HttpClient
{
    BaseAddress = new Uri("https://localhost:7229")
}));

builder.Services.AddTransient<MudLocalizer, DictionaryMudLocalizer>();

var culture = new CultureInfo("de-DE");
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;


await builder.Build().RunAsync();