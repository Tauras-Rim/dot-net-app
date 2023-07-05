using dot_net_example.Services.Interfaces;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace dot_net_example.Services.Classes
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCustomerService(this IServiceCollection services)
        {
            return services.AddScoped<ICustomerService, CustomerService>();
        }
    }
}
