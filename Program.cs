

namespace WeatherApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

          
            builder.Services.AddControllersWithViews();
            builder.Services.AddSingleton<WeatherService>();
            builder.Services.AddHttpClient<WeatherService>();

            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange:true)
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional:true)
                .AddEnvironmentVariables();

            var app = builder.Build();

         

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

           // app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

        


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Weather}/{action=Index}/{id?}");

            app.Run();
        }
    }
}