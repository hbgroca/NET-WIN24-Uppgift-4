using Business.Interfaces;
using Business.Services;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Presentation_MAUI_BLAZOR
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            JsonSerializerOptions options = new JsonSerializerOptions 
            { 
                // Clean up json file
                WriteIndented = true,
                // Prevent infinite loop when collecting db data where JOIN can cause trubble
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles,
            };

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

            builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HBGROCA\Desktop\Github\NET-WIN24-Uppgift-4\Data\Databases\LocalDB.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True"));
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<IStatusRepository, StatusRepository>();
            builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
            builder.Services.AddScoped<IServiceRepositrory, ServiceRepository>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            builder.Services.AddScoped<ICustomerServices, CustomerServices>();
            builder.Services.AddScoped<IStatusServices, StatusServices>();
            builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();
            builder.Services.AddScoped<IProjectServices, ProjectServices>();
            builder.Services.AddScoped<IServicesService, ServicesService>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
