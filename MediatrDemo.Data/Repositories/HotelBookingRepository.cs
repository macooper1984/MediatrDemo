using Dapper;
using MediatrDemo.Domain.Services;
using MediatrDemo.Logic.Commands.Hotels;
using MediatrDemo.Logic.Repositories;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<CreateHotelBookingCommand>> GetByIdAsync(int orderId)
        {
            const string sql = @"SELECT * FROM HotelBookings WHERE OrderId = @OrderId";

            var results = await ConnectionService.Connection.QueryAsync<CreateHotelBookingCommand>(sql,
                new
                {
                    OrderId = orderId
                }, 
                ConnectionService.Transaction);

            return results.ToList();
        }
    }
}
