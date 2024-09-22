using LSL.Tool.Logger;
using Microsoft.Extensions.DependencyInjection;

namespace LSL.DotNetTool.Cli.Infrastructure;

public static class LoggingServiceProviderExtensions
{
    /// <summary>
    /// Adds logging to the host instance using `IConsole` for all logging
    /// </summary>
    /// <param name="source"></param>
    /// <param name="isVerbose"></param>
    /// <returns></returns>
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