

```shell
dotnet \
    workload \
        install \
            maui-android \
            maui-ios \
            maui-maccatalyst \

```



```shell
dotnet \
    new \
        maui \
            --output App_MAUI
        
dotnet \
    new \
        maui \
            --output App_MAUIApp

dotnet \
    new \
        comet \
            --output App_MAUI_Comet

dotnet \
    new \
        maui-multihead \
            --output App_MAUI_MultiHead

dotnet \
    new \
        maui-multiproject \
            --output App_MAUI_MultiProject

dotnet \
    new \
        enterprisemaui \
            --output App_MAUI_Enterprise

dotnet \
    new \
        maui-micro \
            --output App_MAUI_Micro


```


```
Template Name                      Short Name                                          Language 
---------------------------------  --------------------------------------------------  -------- 
.NET MAUI App                      maui                                                [C#]     
.NET MAUI App                      mauiapp                                             [C#],F#  
.NET MAUI Blazor Hybrid App        maui-blazor                                         [C#]     
.NET MAUI Class Library            mauilib                                             [C#]     
.NET MAUI Class Library            mauiclasslib                                        [C#]     
.NET MAUI Comet App                comet                                               [C#]     
.NET MAUI ContentPage (C#)         maui-page-csharp                                    [C#]     
.NET MAUI ContentPage (Razor)      maui-page-razor                                     [C#]     
.NET MAUI ContentPage (XAML)       maui-page-xaml                                      [C#]     
.NET MAUI ContentView (C#)         maui-view-csharp                                    [C#]     
.NET MAUI ContentView (Razor)      maui-view-razor                                     [C#]     
.NET MAUI ContentView (XAML)       maui-view-xaml                                      [C#]     
.NET MAUI Multi-Project App        maui-multihead                                      [C#]     
.NET MAUI Multi-Project App        maui-multiproject                                   [C#]     
.NET MAUI ResourceDictionary (...  maui-dict-xaml                                      [C#]     
.NET MAUI ShellPage (Razor)        maui-shell-razor                                    [C#]     
.NET MAUI UraniumContentPage (...  uraniumcontentpage                                  [C#]     
Blank .NET MAUI template           blankmaui                                           [C#]     
Custom MAUI repro app sample t...  hw-maui-sample-repro                                [C#]     
Custom template for Aspire and...  hw-aspire-clients-maui,hw-aspire-clients-maui-bret  [C#]     
DevExpress v25.2 MAUI Mobile A...  dx.maui                                             [C#]     
Enterprise Project Maui Templa...  enterprisemaui                                      [C#]     
Fabulous Maui.Controls Blank       fabulous-mauicontrols                               F#       
Fluent .NET MAUI Blazor Hybrid...  fluentmaui-blazor-web                               [C#]     
Fun.SunUI.MAUIApp                  sun-maui                                            F#       
Maui Micro Project Template        maui-micro                                                   
MauiReactor based app              maui-reactor-startup                                [C#]     
MauiReactor based app with Xam...  maui-reactor-startup-sample-xaml                    [C#]     
MauiReactor based app with Xam...  maui-reactor-startup-xaml                           [C#]     
Shared Class Library (Xamarin....  sharedclasslib                                      [C#]     
Shiny MAUI Application             shinymaui                                           [C#]     
Uno Platform Maui Embedding Cl...  unomauilib                                          [C#]     
Uranium UI MAUI App Template       uraniumui-app                                       [C#]     
Uranium UI MAUI Blank Template     uraniumui-blank-app                                 [C#]     

```