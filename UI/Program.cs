using Business.Controllers;
using Business.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UI.Controllers;
using UI.Interfaces;

namespace UI
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.Services.GetRequiredService<IOrchestratorApplication>().Initialize();
        }        
        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddScoped<IOrchestratorApplication,OrchestratorApplication>();
                    services.AddScoped<IInitialOptions,InitialOptions>();
                    services.AddScoped<ICreateEndpoint,CreateEndpoint>();
                    services.AddScoped<ICreateEndpointBusiness,CreateEndpointBusiness>();
                    services.AddScoped<ICheckEndpoint,CheckEndpoint>();
                    services.AddScoped<IActionConfirmation,ActionConfirmation>();
                    services.AddScoped<IReadEndpoint,ReadEndpoint>();
                    services.AddScoped<IReadEndpointBusiness,ReadEndpointBusiness>();
                    services.AddScoped<IReadEndpointBusiness,ReadEndpointBusiness>();
                    services.AddScoped<IIndexEndpoint,IndexEndpoint>();
                    services.AddScoped<IIndexEndpointBusiness,IndexEndpointBusiness>();
                    services.AddScoped<IDeleteEndpoint, DeleteEndpoint>();
                    services.AddScoped<IDeleteEndpointBusiness, DeleteEndpointBusiness>();
                    services.AddScoped<IUpdateEndpoint, UpdateEndpoint>();
                    services.AddScoped<IUpdateEndpointBusiness, UpdateEndpointBusiness>();
                });
        }
    }
}
