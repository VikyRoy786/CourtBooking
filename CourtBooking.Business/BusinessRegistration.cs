using CourtBooking.Application.Contracts.IBusiness;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace CourtBooking.Business
{
    public static class BusinessRegistration
    {
        [ExcludeFromCodeCoverage]
        public static IServiceCollection AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ITennisCourtBusiness, TennisCourtBusiness> ();
            return services;

        }

    }
}
