using Syncfusion.Blazor;
using GraphTimedMeasurements;
using GraphTimedMeasurements.Components;
using GraphTimedMeasurements;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddSignalR();
builder.Services.AddSingleton<ITremorService, TremorService>();
var app = builder.Build();
//Register Syncfusion license https://help.syncfusion.com/common/essential-studio/licensing/how-to-generate
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(builder.Configuration.GetValue<string>("SyncFusionLicenseKey"));

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.MapHub<ChartHub>("/charthub", options => options.ApplicationMaxBufferSize=0);
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
