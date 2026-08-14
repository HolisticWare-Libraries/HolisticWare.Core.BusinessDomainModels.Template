using Foundation;
using Microsoft.Maui.Hosting;

namespace App_MAUI_Comet;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
	protected override MauiApp CreateMauiApp() => App.CreateMauiApp();
}