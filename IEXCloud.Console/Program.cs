using System;
using System.Threading.Tasks;
using IEXCloud.Client;

namespace IEXCloud.Console
{
    public class Program
    {
        private static EnvironmentSettings EnvironmentSettings { get; set; } = null!;

        public static async Task Main()
        {
            EnvironmentSettings = new EnvironmentSettings();
            var client = new IEXCloudClient(EnvironmentSettings.Token);    
            var mappings = await client.RefDataIsin("NL0000852564");
            System.Console.WriteLine("MAPPINGS:");
            System.Console.WriteLine("============");
            foreach (var mapping in mappings)
            {
                System.Console.WriteLine($"=>  {mapping.Symbol}, {mapping.Exchange}, {mapping.Symbol}, {mapping.Region}");
            }
        }
    }

    public class EnvironmentSettings
    {
        private const string IEXCloudToken = "IEXCLOUD_TOKEN";

        public EnvironmentSettings()
        {
            var token = Environment.GetEnvironmentVariable(IEXCloudToken);
            if (token != null)
            {
                Token = token;
            }
            else
            {
                throw new InvalidOperationException("environment token is null");
            }
        }

        public string Token { get; }
    }
}