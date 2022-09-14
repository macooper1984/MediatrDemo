using Dapper;
using MediatrDemo.Domain;
using MediatrDemo.Logic.Commands;
using MediatrDemo.Logic.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace MediatrDemo.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public async Task<int> CreateAsync(CreateOrderCommand request)
        {
            const string sql =
                @"INSERT INTO `Orders`
                    (`Reference`,`NumberOfAdults`,`NumberOfChildren`,`TotalCost`,`Country`)
                VALUES
                    (@Reference, @NumberOfAdults, @NumberOfChildren, @TotalCost, @Country);
                SELECT LAST_INSERT_ID();";

            var result = await ConnectionService.Connection.ExecuteScalarAsync<int>(sql, request, ConnectionService.Transaction);

            return result;
        }



        public async Task<CreateOrderCommand> GetByIdAsync(int id)
        {
            const string sql = @"SELECT * FROM Orders WHERE Id = @Id";

            var result = await ConnectionService.Connection.QueryAsync<CreateOrderCommand>(sql,
                new
                {
                    Id = id
                }, 
                ConnectionService.Transaction);

            return result.FirstOrDefault();
        }

        public async Task DeleteAllAsync()
        {
            const string sql = @"DELETE FROM Orders;";

            await ConnectionService.Connection.ExecuteAsync(sql);
        }
    }
}
