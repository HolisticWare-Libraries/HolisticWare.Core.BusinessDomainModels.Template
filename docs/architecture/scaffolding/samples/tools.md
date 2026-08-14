
## MAUI DevFlow

*   dotnet tool install -g Microsoft.Maui.Cli --prerelease

```xml
<PackageReference Include="Microsoft.Maui.DevFlow.Agent" />
<PackageReference Include="Microsoft.Maui.DevFlow.Blazor" />  <!-- If using Blazor Hybrid -->
```

```shell
dotnet \
  add \
    package \
      --project samples/clients/maui/App_MAUI/App_MAUI.csproj \
        Microsoft.Maui.DevFlow.Agent
dotnet \
  add \
    package \
      --project samples/clients/maui/App_MAUI/App_MAUI.csproj \
        Microsoft.Maui.DevFlow.Blazor
```

## AIloha

*   https://ailoha.dev/

```shell
curl -fsSL https://ailoha.dev/install.sh | bash
```

## XamlMcp


*   https://www.rahultr.dev/xamlmcp/#install

*   https://github.com/trrahul/XamlMcp

```shell
dotnet \
    tool \
        install \
            --global \
            XamlMcp.Server --version 1.0.0-preview.2
```

```shell
dotnet \
  add \
    package \
      --project samples/clients/maui/App_MAUI/App_MAUI.csproj \
        XamlMcp.Avalonia --version 1.0.0-preview.2
dotnet \
  add \
    package \
      --project samples/clients/maui/App_MAUI/App_MAUI.csproj \
        XamlMcp.Wpf --version 1.0.0-preview.2
dotnet \
  add \
    package \
      --project samples/clients/maui/App_MAUI/App_MAUI.csproj \
        XamlMcp.WinUI --version 1.0.0-preview.2
dotnet \
  add \
    package samples/clients/maui/App_MAUI/App_MAUI.csproj \
      --project \
        XamlMcp.Maui --version 1.0.0-preview.2
```