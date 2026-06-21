
```
dotnet \
    new \
        webapi \
            --output App_REST_WebAPI_Minimal

dotnet \
    new \
        webapiaot \
            --output App_REST_WebAPI_Minimal_AOT

dotnet \
    new \
        webapi \
            --use-controllers \
            --output App_REST_WebAPI_Minimal_MVC_Controllers

dotnet \
    new \
        odata-webapi \
            --output App_OData_WebAPI

```

```shell
dotnet \
    new \
        web \
            --output App_API_REST_Minimal
dotnet \
    new \
        webapi \
            --output App_API_REST_WebAPI_MVC
dotnet \
    new \
        webapiaot \
            --output App_API_REST_WebAPI_MVC_AOT
dotnet \
    new \
        odata-webapi \
            --output App_API_OData_WebAPI_MVC
```



```shell
dotnet new list api 

```
These templates matched your input: 'api'

Template Name                       Short Name         Language
----------------------------------  -----------------  --------
API Controller                      apicontroller      [C#]    
ASP.NET Core Web API                webapi             [C#],F# 
ASP.NET Core Web API (native AOT)   webapiaot          [C#]    
ASP.NET OData Core Web API          odata-webapi       [C#]    
Aspire Starter App (FastAPI/React)  aspire-py-starter  Python  
```

## ASP.net async Web APIs


*   Asynchronous APIs with .NET

    *   https://www.youtube.com/watch?v=LCbR58sCmvQ

        *   https://github.com/binarythistle/S06E02---Asynchronous-APIs-

        *   https://learn.microsoft.com/en-us/azure/architecture/patterns/asynchronous-request-reply
    
