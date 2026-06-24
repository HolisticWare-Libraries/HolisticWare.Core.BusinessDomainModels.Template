using Microsoft.FluentUI.AspNetCore.Components;
using App_Web_Blazor_MAUI_Fluent.Web.Components;
using App_Web_Blazor_MAUI_Fluent.Shared.Services;
using App_Web_Blazor_MAUI_Fluent.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddFluentUIComponents();

// Add device-specific services used by the App_Web_Blazor_MAUI_Fluent.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(App_Web_Blazor_MAUI_Fluent.Shared._Imports).Assembly);

app.Run();
