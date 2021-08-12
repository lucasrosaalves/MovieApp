using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.Api;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Text;

namespace MovieApp.Tests.IntegrationTests.Server
{
    public static class IntegrationServer
    {
        private static readonly Lazy<TestServer> _lazy = new Lazy<TestServer>(() => Build());
        private static TestServer _instance => _lazy.Value;

        public static HttpClient CreateHttpClient()
        {
            return _instance.CreateClient();
        }

        public static IServiceProvider GetScopedProvider()
        {
            var testServer = IntegrationServer._instance;
            var scope = testServer.Services.GetService<IServiceScopeFactory>().CreateScope();
            return scope.ServiceProvider;
        }

        public static StringContent ConvertObjectToContent(object value)
        {
            return new StringContent(
                JsonConvert.SerializeObject(value),
                Encoding.UTF8, "application/json");
        }

        public static T DeserializeObject<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

        private static TestServer Build()
        {
            var hostBuilder = CreateHostBuilder();
            return new TestServer(hostBuilder);
        }

        private static IWebHostBuilder CreateHostBuilder()
        {
            var path = Assembly.GetAssembly(typeof(IntegrationServer)).Location;

            return new WebHostBuilder()
                .UseContentRoot(Path.GetDirectoryName(path))
                .ConfigureAppConfiguration(cb =>
                {
                    cb
                    .AddJsonFile("appsettings.json", optional: false)
                    .AddJsonFile("appsettings.QualityAssurance.json", optional: true)
                    .AddEnvironmentVariables();
                })
              .UseStartup<Startup>();
        }
    }
}
