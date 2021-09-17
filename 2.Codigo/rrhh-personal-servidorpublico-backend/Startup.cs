using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
//using Prometheus;
using IWebHostEnvironment = Microsoft.AspNetCore.Hosting.IWebHostEnvironment;
using minedu.tecnologia.tracing.jaeger.lib;
using minedu.rrhh.personal.servidorpublico.backend.Health;
using minedu.rrhh.personal.servidorpublico.backend.Rabbit;
using minedu.tecnologia.web.lib.Middleware;
using Microsoft.AspNetCore.Http;
using minedu.rrhh.negocio.comunes.rabbitmq.lib.Transaccion;
using minedu.tecnologia.messaging.rabbitmq.lib;
using minedu.tecnologia.web.lib.Filter;

namespace minedu.rrhh.personal.servidorpublico.backend
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });
            // Register the Swagger generator, defining 1 or more Swagger documents          
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "rrhh-personal-servidorpublico-backend",
                    Description = "Datos de servidores p�blicos",
                    TermsOfService = new Uri("https://minedu.gob.pe/ayni"),
                    Contact = new OpenApiContact
                    {
                        Name = "AYNI Minedu (DITEN)",
                        Email = string.Empty,
                        Url = new Uri("https://minedu.gob.pe/ayni/contact"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT License",
                        Url = new Uri("https://minedu.gob.pe/ayni/license"),
                    }
                });
            });

            //Configuraci�n de RabbitMQ para publicar mensajes
            services.AddRabbitConsumer(Configuration);
            services.AddRabbitPublisher(Configuration);
            
            services.AddAyniHostedService();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            // Add functionality to inject IOptions<T>
            services.AddOptions();

            //Para el uso de Jaeger:
            services.AddJaegerTracing(Configuration, Constante.JaegerEntorno.IIS);

            //services.AddScoped<CustomActionFilter>(); //en el controller o método agregar [ServiceFilter(typeof(CustomActionFilter))]
            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(typeof(CustomActionFilter));
            });

            services.AddHealthChecks()
           .AddCheck<ApiHealthCheck>("Api rrhh-personal-servidorpublico-backend")
           .AddCheck("db_ayni_personal_servidorpublico Health Check", new SqlServerHealthCheck(Configuration.GetConnectionString("DefaultConnection")), HealthStatus.Unhealthy, new string[] { "db_ayni_personal_servidorpublico" })
           .AddCheck<VersionHealthCheck>("Version Health Check");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCustomExceptionMiddleware();
            app.UseRouting();

            //app.UseAuthorization();
            app.UseCors("CorsPolicy");

            //X-Xss-Protection 
            app.UseMiddleware<SecurityHeadersMiddleware>();
            
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseStaticFiles();
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "rrhh-personal-servidorpublico-backend");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapCustomHealthChecks("rrhh-personal-servidorpublico-backend service");
                endpoints.MapGet("/", async context => { await context.Response.WriteAsync($"Hola microservicio de [servidores públicos]! from {System.Environment.MachineName}"); });
            });
        }
    }
}
