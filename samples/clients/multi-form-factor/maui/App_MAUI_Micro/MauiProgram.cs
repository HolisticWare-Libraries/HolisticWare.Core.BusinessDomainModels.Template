using App_MAUI_Micro.ViewModels;
using App_MAUI_Micro.Views;
using Microsoft.Extensions.Logging;

namespace App_MAUI_Micro;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiMicroMvvm<AppShell>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.MapView<MainPage, MainViewModel>()
            .AddSingleton(SemanticScreenReader.Default);


        return builder.Build();
    }
}
