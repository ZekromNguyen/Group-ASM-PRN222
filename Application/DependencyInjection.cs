
using Application.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<MemberManagement>();
            services.AddScoped<ProductManagement>();
            services.AddScoped<OrderManagement>();  
            
            return services;
        }
    }
}