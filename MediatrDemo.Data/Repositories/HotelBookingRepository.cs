using Dapper;
using MediatrDemo.Domain;
using MediatrDemo.Logic.Commands.Hotels;
using MediatrDemo.Logic.Repositories;
using System.Threading.Tasks;

namespace MediatrDemo.Data.Repositories
{
    public class HotelBookingRepository : IHotelBookingRepository
    {
        public async Task<int> CreateAsync(CreateHotelBookingCommand request)
        {
            const string sql =
                @"INSERT INTO `HotelBookings`
                    (`OrderId`, `HotelName`, `RoomType`, `NumberOfBeds`, `TotalCost`)
                VALUES
                    (@OrderId, @HotelName, @RoomType, @NumberOfBeds, @TotalCost);
                SELECT LAST_INSERT_ID();";

            var result = await ConnectionService.Connection.ExecuteScalarAsync<int>(sql, request, ConnectionService.Transaction);

            return result;
        }
    }
}
