using LSL.DotNetTool.Logger;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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
                c.Services.AddDotNetToolLogger();                
                c.SetMinimumLevel(LogLevel.Debug);
            }
        });
    }
}