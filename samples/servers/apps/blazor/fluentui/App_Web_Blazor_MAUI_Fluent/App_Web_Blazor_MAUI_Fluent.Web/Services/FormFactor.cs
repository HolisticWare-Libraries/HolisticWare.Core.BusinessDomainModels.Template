using App_Web_Blazor_MAUI_Fluent.Shared.Services;

namespace App_Web_Blazor_MAUI_Fluent.Web.Services;

public class FormFactor : IFormFactor
{
    public string GetFormFactor()
    {
        return "Web";
    }

    public string GetPlatform()
    {
        return Environment.OSVersion.ToString();
    }
}
