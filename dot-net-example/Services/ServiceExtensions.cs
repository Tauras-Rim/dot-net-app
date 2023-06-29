using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace dot_net_example.Services
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddGetService(this IServiceCollection services)
        {
            return services.AddScoped<IGetService, GetService>();
        }

        public static IServiceCollection AddPostService(this IServiceCollection services)
        {
            return services.AddScoped<IPostService, PostService>();
        }

        public static IServiceCollection AddDeleteService(this IServiceCollection services)
        {
            return services.AddScoped<IDeleteService, DeleteService>();
        }

        public static IServiceCollection AddUpdateService(this IServiceCollection services)
        {
            return services.AddScoped<IUpdateService, UpdateService>();
        }
    }
}
