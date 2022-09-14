using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MediatrDemo.Logic
{
    public static class Services
    {
        public static void RegisterLogicServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ConnectionPipeline<,>));
        }
    }
}
