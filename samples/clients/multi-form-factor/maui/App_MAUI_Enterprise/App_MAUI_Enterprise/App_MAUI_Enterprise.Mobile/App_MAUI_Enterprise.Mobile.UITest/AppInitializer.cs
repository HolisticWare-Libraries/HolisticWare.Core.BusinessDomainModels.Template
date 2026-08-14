using Xamarin.UITest;

namespace App_MAUI_Enterprise.Mobile.UITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
                return ConfigureApp.Android.StartApp();

            return ConfigureApp.iOS.StartApp();
        }
    }
}