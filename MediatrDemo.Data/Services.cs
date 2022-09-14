using MediatrDemo.Data.Repositories;
using MediatrDemo.Logic.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MediatrDemo.Data
{
    public static class Services
    {
        public static void RegisterDataServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IOrderRepository, OrderRepository>();
            serviceCollection.AddTransient<IFlightBookingRepository, FlightBookingRepository>();
            serviceCollection.AddTransient<IFlightLegRepository, FlightLegRepository>();
            serviceCollection.AddTransient<IHotelBookingRepository, HotelBookingRepository>();
        }
    }
}
