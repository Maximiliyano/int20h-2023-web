using FoodSimpleWebApi.Services;

namespace FoodSimpleWebApi.Extensions;

<<<<<<< HEAD
public static class ServiceExtension {

    public static void RegisterCustomServices(this IServiceCollection services) {
=======
public static class ServiceExtension
{
    public static void RegisterCustomServices(this IServiceCollection services)
    {
>>>>>>> 1f754b1 (complete services)
        services.AddScoped<UserServices>();
        services.AddScoped<RecipeServices>();
        services.AddScoped<ProductServices>();
    }
}