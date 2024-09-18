using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LSL.DotNetTool.Cli.Infrastructure;

public static class HostFactory
{
    public static IHostBuilder Create(string[] args)
    {
        var builder = Host.CreateDefaultBuilder();

        builder.ConfigureServices(services =>
        {
            var (isVerbose, filteredArguments) = ArgumentsPreprocessor.ProcessArguments(args);

            services
                .Configure<CommandLineOptions>(c => c.Arguments = filteredArguments)
                .AddCommandLineParser(typeof(Program).Assembly)
                .AddCliLogging(isVerbose);
        });

        return builder;
    }
}