using App_Web_Blazor_MAUI_Fluent.Shared.Services;

namespace App_Web_Blazor_MAUI_Fluent.Services;

public class FormFactor : IFormFactor
{
    public string GetFormFactor()
    {
        return DeviceInfo.Idiom.ToString();
    }

    public string GetPlatform()
    {
        return DeviceInfo.Platform.ToString() + " - " + DeviceInfo.VersionString;
    }
}
