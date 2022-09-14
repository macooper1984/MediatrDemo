using Dapper;
using MediatrDemo.Domain;
using MediatrDemo.Logic.Commands.Flights;
using MediatrDemo.Logic.Repositories;
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
    }
}
