using FluentValidation;

namespace MinimalAPI_Second_Tirando_da_Program.AppServiceExtensions
{
    public static class ServiceValidationExtensions
    {
        public static RouteHandlerBuilder WhitValidator<TEntity>(this RouteHandlerBuilder builder) where TEntity : class
        {
            builder.Add(endpointBuilder =>
            {
                var originalRequestDelegate = endpointBuilder.RequestDelegate;

                endpointBuilder.RequestDelegate = async context =>
                {
                    var validator = context.RequestServices.GetService<IValidator<TEntity>>();
                    if (validator is null)
                    {
                        await originalRequestDelegate!(context);
                        return;
                    }
                    context.Request.EnableBuffering();

                    var model = await context.Request.ReadFromJsonAsync<TEntity>();
                    if (model is null)
                    {
                        context.Response.StatusCode = 400;
                        await context.Response.WriteAsJsonAsync(new
                        {
                            error = "Não se pode mapear um model do body"
                        });
                        return;
                    }

                    var result = await validator.ValidateAsync(model);
                    if (!result.IsValid)
                    {
                        context.Response.StatusCode = 400;
                        await context.Response.WriteAsJsonAsync(new { error = result.Errors });
                        return;
                    }

                    context.Request.Body.Position = 0;
                    await originalRequestDelegate(context);
                };
            });

            return builder;
        }



        //--==============================================================
        //--==============================================================
        /*
        public class ValidationFilter<T> : IEndpointFilter
        {
            public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
            {
                T? argToValidate = context.GetArgument<T>(0);
                IValidator<T>? validator = context.HttpContext.RequestServices.GetService<IValidator<T>>();

                if (validator is not null)
                {
                    var validationResult = await validator.ValidateAsync(argToValidate!);
                    if (!validationResult.IsValid)
                    {
                        return Results.ValidationProblem(validationResult.ToDictionary(),
                            statusCode: (int)HttpStatusCode.UnprocessableEntity);
                    }
                }

                // Otherwise invoke the next filter in the pipeline
                return await next.Invoke(context);
            }
        }
        [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
        public class ValidateAttribute : Attribute
        {
        }

        public static class ValidationFilter
        {
            public static EndpointFilterDelegate ValidationFilterFactory(EndpointFilterFactoryContext context, EndpointFilterDelegate next)
            {
                IEnumerable<ValidationDescriptor> validationDescriptors = GetValidators(context.MethodInfo, context.ApplicationServices);
                if (validationDescriptors.Any())
                {
                    return invocationContext => Validate(validationDescriptors, invocationContext, next);
                }
                // pass-thru
                return invocationContext => next(invocationContext);
            }

            private static async ValueTask<object?> Validate(IEnumerable<ValidationDescriptor> validationDescriptors, EndpointFilterInvocationContext invocationContext, EndpointFilterDelegate next)
            {
                foreach (ValidationDescriptor descriptor in validationDescriptors)
                {
                    var argument = invocationContext.Arguments[descriptor.ArgumentIndex];

                    if (argument is not null)
                    {
                        var validationResult = await descriptor.Validator.ValidateAsync(
                            new ValidationContext<object>(argument)
                        );

                        if (!validationResult.IsValid)
                        {
                            return Results.ValidationProblem(validationResult.ToDictionary(),
                                statusCode: (int)HttpStatusCode.UnprocessableEntity);
                        }
                    }
                }

                return await next.Invoke(invocationContext);
            }

            static IEnumerable<ValidationDescriptor> GetValidators(MethodInfo methodInfo, IServiceProvider serviceProvider)
            {
                ParameterInfo[] parameters = methodInfo.GetParameters();

                for (int i = 0; i < parameters.Length; i++)
                {
                    ParameterInfo parameter = parameters[i];

                    if (parameter.GetCustomAttribute<ValidateAttribute>() is not null)
                    {
                        Type validatorType = typeof(IValidator<>).MakeGenericType(parameter.ParameterType);

                        // Note that FluentValidation validators needs to be registered as singleton
                        IValidator? validator = serviceProvider.GetService(validatorType) as IValidator;

                        if (validator is not null)
                        {
                            yield return new ValidationDescriptor { ArgumentIndex = i, ArgumentType = parameter.ParameterType, Validator = validator };
                        }
                    }
                }
            }

            private class ValidationDescriptor
            {
                public required int ArgumentIndex { get; init; }
                public required Type ArgumentType { get; init; }
                public required IValidator Validator { get; init; }
            }
        }
    */
        //--==============================================================
    }
}
