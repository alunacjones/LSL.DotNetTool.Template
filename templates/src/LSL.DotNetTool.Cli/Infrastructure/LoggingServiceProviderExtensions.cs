using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LSL.DotNetTool.Cli.Infrastructure;

public static class LoggingServiceProviderExtensions
{
    public static IServiceCollection AddCliLogging(this IServiceCollection source, bool isVerbose)
    {
        return source.AddLogging(c => 
        {
            if (isVerbose)
            {
                c.AddSimpleConsole(c => c.SingleLine = true);
                c.SetMinimumLevel(LogLevel.Debug);
            }
        });
    }
}