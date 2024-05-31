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
                        await context.Response.WriteAsJsonAsync(new {error = result.Errors});
                        return;
                    }

                    context.Request.Body.Position = 0;
                    await originalRequestDelegate(context);
                };
            });

            return builder;
        }
    }
}
