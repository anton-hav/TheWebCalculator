using System.Reflection;
using System.Text;
using Serilog;
using Serilog.Events;
using TheWebCalculator.Core.Abstractions;
using WebCalculator.Business.ServicesImplementations;

namespace TheWebCalculator;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add Serilog as Logger
        builder.Host.UseSerilog((ctx, lc) => lc
            .WriteTo.Console()
            .WriteTo.File(GetPathToLogFile(),
                LogEventLevel.Information));

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        // Add business service
        builder.Services.AddScoped<ICalculatorService, CalculatorService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            "default",
            "{controller=Home}/{action=Index}/{id?}");


        app.Run();
    }

    private static string GetPathToLogFile()
    {
        var sb = new StringBuilder();
        sb.Append(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        sb.Append(@"\logs\");
        sb.Append($"{DateTime.Now:yyyyMMddhhmmss}");
        sb.Append("data.log");
        return sb.ToString();
    }
}