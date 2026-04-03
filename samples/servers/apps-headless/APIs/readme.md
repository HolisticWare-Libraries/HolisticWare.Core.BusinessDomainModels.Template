

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