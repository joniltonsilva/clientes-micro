using Clientes.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace Clientes.API
{
    public class Startup
    {
        private IWebHostEnvironment _env;
        private IConfiguration _configuration;
        private string ClientesSpecificOrigins = "_ClientesSpecificOrigins";

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = $"API de Clientes", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: ClientesSpecificOrigins, policy => policy.WithOrigins("http://localhost:3000")
                                                                                 .AllowAnyHeader()
                                                                                 .AllowAnyMethod());
            });

            NativeInjectorBootstrap.ConfigureServices(services, _configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", $"API de Clientes v1 - {_env.EnvironmentName}"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(ClientesSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
