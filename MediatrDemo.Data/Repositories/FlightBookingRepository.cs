using Dapper;
using MediatrDemo.Domain;
using MediatrDemo.Logic.Commands.Flights;
using MediatrDemo.Logic.Repositories;
using System.Threading.Tasks;

namespace MediatrDemo.Data.Repositories
{
    public class FlightBookingRepository : IFlightBookingRepository
    {
        public async Task<int> CreateAsync(CreateFlightBookingCommand request)
        {
            const string sql =
                @"INSERT INTO `FlightBookings`
                    (`Reference`, `OrderId`, `AirlineName`, `TotalCost`) 
                VALUES
                    (@Reference, @OrderId, @AirlineName, @TotalCost);

                SELECT LAST_INSERT_ID();";

            var result = await ConnectionService.Connection.ExecuteScalarAsync<int>(sql, request, ConnectionService.Transaction);

            return result;
        }
    }
}
