namespace FoodSimpleWebApi;

public static class Program {
    public static void Main(string[] args) {
        CreateWebApplication(args).Build().Run();
    }

    private static IHostBuilder CreateWebApplication(string[] args) {
        return Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(
                webBuilder => webBuilder.UseStartup<Startup>());
    }
}