﻿using FluentValidation;
using MediatR;
using MediatrDemo.Logic.Pipelines;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MediatrDemo.Logic
{
    public static class Services
    {
        public static void RegisterLogicServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(CorrelationPipeline<,>));
            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingPipeline<,>));
            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingPipeline<,>));
            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipeline<,>));
            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ConnectionPipeline<,>));

            serviceCollection.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies().Where(p => !p.IsDynamic));
        }
    }
}
