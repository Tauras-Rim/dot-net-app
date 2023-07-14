using dot_net_example.Services.Classes;
using dot_net_example.Services.Interfaces;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace dot_net_example.Services
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCustomerService(this IServiceCollection services)
        {
            return services.AddScoped<ICustomerService, CustomerService>();
        }

        public static IServiceCollection AddBookService(this IServiceCollection services)
        {
            return services.AddScoped<IBookService, BookService>();
        }
    }
}
