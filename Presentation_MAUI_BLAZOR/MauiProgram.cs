using Business.Interfaces;
using Business.Services;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Business.Models;

namespace Presentation_MAUI_BLAZOR
{
    public static class MauiProgram
    {
        /* Installera dessa paket i DATAlagret
         * install-package Microsoft.Entityframeworkcore.design
         * install-package Microsoft.Entityframeworkcore.tools
         * install-package Microsoft.Entityframeworkcore.sqlserver
         * 
         * Installera även Design paketet i presentationslagret
         */

        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

            builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HBGROCA\Desktop\Github\NET-WIN24-Uppgift-4\Data\Databases\LocalDB.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True"));
            builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
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
