using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrDemo.Logic.Pipelines
{
    public class ValidationPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationPipeline(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                foreach (var validator in validators)
                {
                    var result = validator.Validate(context);

                    if (result.Errors.Any())
                    {
                        throw new ValidationException(result.Errors.First().ErrorMessage);
                    }
                }
            }
            return await next();
        }
    }
}
