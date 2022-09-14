using MediatR;
using MediatrDemo.Domain;
using MySql.Data.MySqlClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrDemo.Logic.Pipelines
{
    public class CorrelationPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (CorrelationService.HasTraceId == false)
            {
                CorrelationService.TraceId = Guid.NewGuid();
            }

            return await next.Invoke();
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
