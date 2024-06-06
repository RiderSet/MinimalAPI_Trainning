namespace MinimalAPI_Second_Tirando_da_Program.AppServiceExtensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app, IWebHostEnvironment environment)
        {
            if(environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            return app;
        }

        public static IApplicationBuilder UseAppCors(this IApplicationBuilder app)
        {
            app.UseCors(p =>
            {
                p.AllowAnyOrigin();
                p.WithMethods("GET");
                p.AllowAnyHeader();
            });

            return app;
        }

        public static IApplicationBuilder UseSwaggerEndPoints(this IApplicationBuilder app) 
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => { });

            return app;
        }


    }
}
