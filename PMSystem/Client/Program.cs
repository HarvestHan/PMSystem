global using Blazored.LocalStorage;
global using Microsoft.AspNetCore.Components.Authorization;
global using Microsoft.AspNetCore.Components.Web;
global using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
global using MudBlazor;
global using MudBlazor.Services;
global using PMSystem.Client;
global using PMSystem.Client.Services.AuthService;
global using PMSystem.Client.Services.RoleService;
global using PMSystem.Client.Services.UserService;

global using PMSystem.Client.Services.WarehouseService;
global using PMSystem.Client.Services.PartsService;
global using PMSystem.Client.Services.InboundListService;
global using PMSystem.Client.Services.OutboundListService;
global using PMSystem.Client.Services.CheckListService;
global using PMSystem.Client.Services.StorageInfoService;
global using PMSystem.Client.Services.TransferListService;

global using PMSystem.Client.Util;

global using PMSystem.Shared.Models;

using AutoMapper;
using System.Reflection;
using PMSystem.Client.Profiles;

using MudBlazor.Extensions;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices(config => {
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopCenter;
    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 3000;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});

AutoMapper.IConfigurationProvider mapperConfig = new MapperConfiguration(cfg =>
{
    //反射
    foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
    {
        //添加服务Service
        if (!type.IsInterface && !type.IsAbstract && type.ToString().EndsWith("Service"))
        {
            var interfaceTypes = type.GetInterfaces();
            foreach (var interfaceType in interfaceTypes)
            {
                builder.Services.AddScoped(interfaceType, type);
            }
        }
        //AutoMapper
        if (type.Name.Contains("Profile"))
            cfg.AddProfile(type);
    }
});

builder.Services.AddBootstrapBlazor();
builder.Services.AddSingleton(mapperConfig);
builder.Services.AddScoped<IMapper, Mapper>();

// use this to add MudServices and the MudBlazor.Extensions
builder.Services.AddMudServicesWithExtensions();
// or this to add only the MudBlazor.Extensions
builder.Services.AddMudExtensions();

builder.Services.AddScoped(sp => new HttpClient
{ 
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
    Timeout = TimeSpan.FromSeconds(10),
});
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<AuthenticationStateProvider,CustomAuthStateProvider>();
builder.Services.AddBootstrapBlazor();

await builder.Build().RunAsync();
