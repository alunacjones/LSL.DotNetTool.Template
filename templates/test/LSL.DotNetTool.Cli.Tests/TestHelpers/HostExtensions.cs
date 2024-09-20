using LSL.DotNetTool.Cli.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace LSL.DotNetTool.Cli.Tests.TestHelpers;

public static class HostExtensions
{
    public static async Task<(int Result, string Output)> RunTestCliAsync(this IHost host)
    {
        var result = await host.RunCliAsync();
        var writer = host.Services.GetRequiredService<IOptions<ConsoleOptions>>().Value.TextWriter;
        writer.Flush();

        return (result, writer.ToString()!);
    }
}