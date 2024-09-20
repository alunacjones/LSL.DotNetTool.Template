using CommandLineParser.DependencyInjection.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace LSL.DotNetTool.Cli.Infrastructure;

public static class HostExtensions
{
    public static async Task<int> RunCliAsync(this IHost host)
    {
        var args = host.Services.GetRequiredService<IOptions<CommandLineOptions>>().Value.Arguments;
        var consoleWriter = host.Services.GetRequiredService<IOptions<ConsoleOptions>>().Value.TextWriter;

        return await host
            .Services
            .GetRequiredService<ICommandLineParser<int>>()
            .ParseArgumentsAsync(
                args,
                c => c.HelpWriter = consoleWriter);
    }
}