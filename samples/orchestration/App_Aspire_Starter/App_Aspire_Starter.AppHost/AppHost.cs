var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.App_Aspire_Starter_ApiService>("apiservice")
    .WithHttpHealthCheck("/health");

builder.AddProject<Projects.App_Aspire_Starter_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
