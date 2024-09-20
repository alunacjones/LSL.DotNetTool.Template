using LSL.AbstractConsole;
using LSL.AbstractConsole.ServiceProvider;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
                .AddSingleton<IConsole, DefaultConsole>(s => new DefaultConsole(s.GetRequiredService<IOptions<ConsoleOptions>>().Value.TextWriter))                
                .AddCommandLineParser(typeof(Program).Assembly)
                .AddCliLogging(isVerbose);
        });

        return builder;
    }
}