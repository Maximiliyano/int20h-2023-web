using FoodSimpleWebApi.Data;
using FoodSimpleWebApi.Extensions;
using Microsoft.EntityFrameworkCore;

namespace FoodSimpleWebApi;

public class Startup
{
    private readonly IConfiguration _configuration;
    
    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(
        IServiceCollection services)
    {
        var migrationAssembly = typeof(FoodSimpleDbContext).Assembly.GetName().Name;
        services.AddDbContext<FoodSimpleDbContext>(options => 
            options.UseSqlServer(_configuration.GetConnectionString("FoodSimpleDbConnection"), 
                opt => opt.MigrationsAssembly(migrationAssembly)));

        services.RegisterCustomServices();

        services.AddControllers();
        services.AddSwaggerGen();
    }

    public void Configure(
        IApplicationBuilder app, 
        IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            //app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
            // TODO remove this after complete tasks
        }

        app.UseRouting();

        app.UseEndpoints(cfg =>
        {
            cfg.MapControllers();
        });
    }
}