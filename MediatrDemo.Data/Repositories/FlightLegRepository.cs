using Dapper;
using MediatrDemo.Domain.Services;
using MediatrDemo.Logic.Commands.Flights;
using MediatrDemo.Logic.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatrDemo.Data.Repositories
{
    public class FlightLegRepository : IFlightLegRepository
    {
        public async Task<int> CreateAsync(CreateFlightLegCommand request)
        {
            const string sql =
                @"INSERT INTO `FlightLegs`
                    (`FlightBookingId`, `Reference`, `FromIata`, `ToIata`, `DepartureTime`, `ArrivalTime`)
                VALUES
                    (@FlightBookingId, @Reference, @FromIata, @ToIata, @DepartureTime, @ArrivalTime);";

            var result = await ConnectionService.Connection.ExecuteScalarAsync<int>(sql, request, ConnectionService.Transaction);

            return result;
        }

        public async Task<List<CreateFlightLegCommand>> GetByIdAsync(int flightBookingId)
        {
            const string sql = @"SELECT * FROM FlightLegs WHERE FlightBookingId = @FlightBookingId";

            var results = await ConnectionService.Connection.QueryAsync<CreateFlightLegCommand>(sql, new
            {
                FlightBookingId = flightBookingId
            },
            ConnectionService.Transaction);

            return results.ToList();
        }
    }
}
