namespace App_Web_Blazor_MAUI_Fluent;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new MainPage()) { Title = "App_Web_Blazor_MAUI_Fluent" };
    }
}
