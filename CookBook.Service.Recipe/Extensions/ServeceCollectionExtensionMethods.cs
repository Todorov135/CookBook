namespace CookBook.Service.Recipe.Extensions
{
    using CookBook.Service.Recipe.Data;
    using Microsoft.EntityFrameworkCore;

    public static class ServeceCollectionExtensionMethods
    {
        public static IServiceCollection AddDbContextConfiguration(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlServer(config.GetConnectionString("DefaultString"));
            });

            return services;
        }
    }
}