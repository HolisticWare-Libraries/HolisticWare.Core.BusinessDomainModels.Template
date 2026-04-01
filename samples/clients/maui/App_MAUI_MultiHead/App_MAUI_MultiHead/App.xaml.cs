using Android.App;

namespace App_MAUI_MultiHead;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
