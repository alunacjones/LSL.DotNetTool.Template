using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LSL.DotNetTool.Cli.Infrastructure;

public static class HostBuilderFactory
{
    public static IHostBuilder Create(string[] args)
    {
        var builder = Host.CreateDefaultBuilder();

        builder.ConfigureServices(services =>
        {
            var (isVerbose, filteredArguments) = ArgumentsPreprocessor.ProcessArguments(args);

            services
                .Configure<CommandLineOptions>(c => c.Arguments = filteredArguments)
                .AddSingleton<IConsole, DefaultConsole>()
                .AddScoped<CustomConsoleLogger>()
                .AddSingleton<ILoggerProvider>(s =>
                {
                    var options = s.GetRequiredService<IOptions<ConsoleOptions>>();
                    var console = s.GetRequiredService<IConsole>();
                    return new CustomConsoleLoggerProvider(options, console);
                })
                .AddCommandLineParser(typeof(Program).Assembly)
                .AddCliLogging(isVerbose);
        });

        return builder;
    }
}