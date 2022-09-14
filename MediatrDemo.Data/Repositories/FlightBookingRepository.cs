using Dapper;
using MediatrDemo.Domain;
using MediatrDemo.Logic.Commands.Flights;
using MediatrDemo.Logic.Commands.Hotels;
using MediatrDemo.Logic.Repositories;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<CreateFlightBookingCommand>> GetByIdAsync(int orderId)
        {
            const string sql = @"SELECT * FROM FlightBookings WHERE OrderId = @OrderId";

            var results = await ConnectionService.Connection.QueryAsync<CreateFlightBookingCommand>(sql,
                new
                {
                    OrderId = orderId
                },
                ConnectionService.Transaction);

            return results.ToList();
        }
    }
}
