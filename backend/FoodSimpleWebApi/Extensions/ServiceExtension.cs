using FoodSimpleWebApi.Services;

namespace FoodSimpleWebApi.Extensions;

public static class ServiceExtension
{

    public static void RegisterCustomServices(this IServiceCollection services)
    {
        services.AddScoped<UserServices>();
        services.AddScoped<RecipeServices>();
        services.AddScoped<ProductServices>();
    }
}