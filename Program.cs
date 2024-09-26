
var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddRadzenComponents();
builder.Services.AddRadzenCookieThemeService(options =>
{
    options.Name = "gP2osParticipantTheme";
    options.Duration = TimeSpan.FromDays(365);
});

builder.Services.AddLocalization();

builder.Services.AddScoped<HelperAuthToken>();
builder.Services.AddScoped<DialogService>();

builder.Services.AddSingleton<NavigationHistory>();
builder.Services.AddScoped<gP2Navigation>();

builder.Services.AddScoped<SecurityAuthState>();
builder.Services.AddScoped<AuthenticationStateProvider, UserAuthStateProvider>();

builder.Services.AddDbContextFactory<gP2ParticipantDBContext>();

builder.Services.AddHttpClient<IUserApiRepository, UserApiRepository>();
builder.Services.AddHttpClient<IParticipantApiRepository, ParticipantApiRepository>();

builder.Services.AddScoped<CheckAuthToken>();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();

var host = builder.Build();

await host.SetDefaultCulture();

await host.RunAsync();
