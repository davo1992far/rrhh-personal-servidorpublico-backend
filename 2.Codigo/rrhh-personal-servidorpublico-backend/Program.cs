using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using minedu.tecnologia.web.lib;
using Serilog;

namespace minedu.rrhh.personal.servidorpublico.backend
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? Environments.Production;
            var jsonFile = environment.Equals(Environments.Development) ? $"appsettings.{environment}.json" : "appsettings.json";

            var Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(jsonFile, false, true)
                .AddEnvironmentVariables()
                .Build();

            LogConfig.Configurar(Configuration);

            try
            {
                CreateHostBuilder(args).Build().Run();

                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "El Host terminó inesperadamente");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
            //fin: modificado para el uso de serilog
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseSerilog(); //para el uso de logging serilog
    }
}
