using System.Globalization;
using Kujira.Api;
using Kujira.Gui;
using Kujira.Gui.Services;
using Kujira.Shared;
using Microsoft.AspNetCore.Components.Authorization;
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
    //BaseAddress = new Uri("https://192.168.1.82:5001") // Die IP-Adresse des API-Servers
    //BaseAddress = new Uri("https://r49nk34w-7229.euw.devtunnels.ms") // Öffentliche URL der API
});

// MudBlazor Services
builder.Services.AddMudServices();

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();


// Other services
builder.Services.AddSingleton<LoadingService>();


// RestEase Service for IKujiraBackendApi
builder.Services.AddSingleton<IKujiraBackendApi>(provider => RestClient.For<IKujiraBackendApi>(new HttpClient
{
    //BaseAddress = new Uri("https://r49nk34w-7229.euw.devtunnels.ms") // Öffentliche URL der API
    BaseAddress = new Uri("https://localhost:7229")
    //BaseAddress = new Uri("https://192.168.1.82:5001")
}));

builder.Services.AddTransient<MudLocalizer, DictionaryMudLocalizer>();

var culture = new CultureInfo("de-DE");
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;


await builder.Build().RunAsync();