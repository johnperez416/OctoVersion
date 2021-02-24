using System;
using System.Linq;
using OctoVersion.Core;
using OctoVersion.Core.Configuration;

namespace OctoVersion.Tool
{
    class Program
    {
        static void Main(string[] args)
        {
            // Very hacky args parsing. The intention is to revisit this soon. Please don't copy :)
            if (args.Any(a => string.Equals(a, "--version", StringComparison.OrdinalIgnoreCase)))
            {
                var ourOwnVersion = typeof(Program).Assembly.GetName().Version;
                Console.WriteLine(ourOwnVersion);
            }
            else
            {
                var (appSettings, configuration) = ConfigurationBootstrapper.Bootstrap<AppSettings>(args);
                var runner = new OctoVersionRunner(appSettings, configuration);
                runner.Run(out _);
            }
        }
    }
}