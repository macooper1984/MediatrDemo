using MediatR;
using MediatrDemo.Domain;
using MySql.Data.MySqlClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrDemo.Logic.Pipelines
{
    public class ConnectionPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (ConnectionService.HasConnection == false)
            {
                using (var connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        ConnectionService.Connection = connection;
                        ConnectionService.Transaction = transaction;

                        try
                        {
                            var result = await next.Invoke();
                            await transaction.CommitAsync();

                            return result;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                            await transaction.RollbackAsync();
                            throw;
                        }
                    }
                }
            }
            else
            {
                var result = await next.Invoke();
                return result;
            }
        }

        private static string connectionString;

        public static string ConnectionString
        {
            get
            {
                if (connectionString == null)
                {
                    var builder = new MySqlConnectionStringBuilder
                    {
                        Server = "127.0.0.1",
                        Port = 3311,
                        UserID = "otb",
                        Password = "OtbOtb",
                        Database = "AdminDotNet"
                    };

                    connectionString = builder.ToString();
                }

                return connectionString;
            }
        }
    }
}
