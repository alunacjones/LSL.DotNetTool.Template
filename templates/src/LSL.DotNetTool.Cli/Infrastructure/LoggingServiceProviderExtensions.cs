using LSL.AbstractConsole.ServiceProvider;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;

namespace LSL.DotNetTool.Cli.Infrastructure;

public static class LoggingServiceProviderExtensions
{
    public static IServiceCollection AddCliLogging(this IServiceCollection source, bool isVerbose)
    {        
        return source.AddLogging(c => 
        {
            c.ClearProviders();

            if (isVerbose)
            {
                c.Services.AddSingleton<ILoggerProvider, CustomConsoleLoggerProvider>();
                LoggerProviderOptions.RegisterProviderOptions<ConsoleOptions, CustomConsoleLogger>(c.Services);
                c.SetMinimumLevel(LogLevel.Debug);
            }
        });
    }
}