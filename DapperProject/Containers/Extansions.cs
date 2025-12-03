using DapperProject.Context;
using DapperProject.Repositories;

namespace DapperProject.Containers
{
    public static class Extansions
    {
        public static void ContainerDependency(this IServiceCollection services)
        {
            services.AddScoped<DapperContext>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }
    }
}
