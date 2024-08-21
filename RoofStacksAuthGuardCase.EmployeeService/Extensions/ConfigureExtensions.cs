using Serilog;
using Serilog.Sinks.Elasticsearch;
using System.Reflection;

namespace RoofStacksAuthGuardCase.EmployeeService.Extensions
{
    public static class ConfigureExtensions
    {
        public static void ConfigureLogging()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env}.json", optional: true)
                .Build();

            //for debugging
            //Serilog.Debugging.SelfLog.Enable(Console.Error);
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .WriteTo.Debug()
                .WriteTo.Console()
                .WriteTo.Elasticsearch(ConfigureElasticSink(config, env))
                .Enrich.WithProperty("Environment", env)
                .ReadFrom.Configuration(config)
                .CreateLogger();
        }

        static ElasticsearchSinkOptions ConfigureElasticSink(IConfigurationRoot builder, string environment)
        {
            var uri = builder["ElasticConfiguration:Uri"];
            var indexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name.ToLower().Replace(".", "-")}-{environment.ToLower()}-{DateTime.UtcNow:yyyy-MM}";

            var elasticOptions = new ElasticsearchSinkOptions(new Uri(uri))
            {
                AutoRegisterTemplate = true,
                AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv7,
                IndexFormat = indexFormat,
                TypeName = null,
                BatchAction = ElasticOpType.Create,
                NumberOfReplicas = 1,
                NumberOfShards = 2
            };

            if (!string.IsNullOrEmpty(builder["ElasticConfiguration:Password"]))
            {
                var username = builder["ElasticConfiguration:Username"];
                var password = builder["ElasticConfiguration:Password"];
                elasticOptions.ModifyConnectionSettings = x => x.BasicAuthentication(username, password);
            }

            return elasticOptions;
        }
    }
}
