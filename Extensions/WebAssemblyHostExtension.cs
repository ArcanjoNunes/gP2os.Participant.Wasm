using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace gP2os.Participants.Extensions;

public static class WebAssemblyHostExtension
{
    public async static Task SetDefaultCulture(this WebAssemblyHost host)
    {
        var jsInterop = host.Services.GetRequiredService<IJSRuntime>();
        
        var result = await jsInterop.InvokeAsync<string>("gP2osCulture.get") ?? "pt";
        if (result.Length > 2) { result = result[..2]; }
        
        CultureInfo culture = new(result);
        
        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;
    }
}
