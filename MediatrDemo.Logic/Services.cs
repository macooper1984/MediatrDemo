using FluentValidation;
using MediatR;
using MediatrDemo.Logic.Pipelines;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MediatrDemo.Logic
{
    public static class Services
    {
        public static void RegisterLogicServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(CorrelationPipeline<,>));
            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ConnectionPipeline<,>));
            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingPipeline<,>));
            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipeline<,>));

            serviceCollection.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
