using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.OData;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using App_OData_WebAPI;

// Learn more about configuring OData at https://learn.microsoft.com/odata/webapi-8/getting-started
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddOData(opt =>
{
    opt.AddRouteComponents("odata", EdmModelBuilder.GetEdmModel())
           .EnableQueryFeatures(100);

        opt.RouteOptions.EnableControllerNameCaseInsensitive = true;
        opt.RouteOptions.EnableActionNameCaseInsensitive = true;
        opt.RouteOptions.EnablePropertyNameCaseInsensitive = true;
    opt.RouteOptions.EnableNonParenthesisForEmptyParameterFunction = true;
});


var app = builder.Build();


app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseODataRouteDebug();
}

app.UseRouting();

app.MapControllers();

app.Run();
