using CourtBooking.Application.Contracts.IRepository;
using CourtBooking.Application.Repository.IRepository;
using CourtBooking.Infstructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace CourtBooking.Infstructure
{
    public static class PersistenceServiceRegistration
    {
        [ExcludeFromCodeCoverage]
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var dbProvider = "MSSQL";

            switch (dbProvider)
            {
                case "MSSQL":
                    services.AddDbContext<BookingDbContext>(options =>
                         options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                                            sqlServerOptionsAction: sqlOptions =>
                                            {
                                                // sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                                                //Configuring Connection Resiliency: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency
                                                sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                                            }));
                    break;

                default:
                    break;
            }
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ITennisCourtRepository, TennisCourtRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            return services;
        }
    }
}
