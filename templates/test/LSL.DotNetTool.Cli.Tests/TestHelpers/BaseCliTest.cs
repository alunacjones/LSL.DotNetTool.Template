using LSL.DotNetTool.Cli.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace LSL.DotNetTool.Cli.Tests.TestHelpers;

public abstract class BaseCliTest
{
    protected async Task<(int result, string output)> RunCli(
        string[] args,
        Action<IServiceCollection>? servicesConfigurator = null)
    {
        using var writer = new StringWriter();

        var result =  await HostBuilderFactory.Create(args)
            .ConfigureServices((context, services) =>
            {
                services.Configure<ConsoleOptions>(s =>
                {
                    s.TextWriter = writer;
                });

                servicesConfigurator?.Invoke(services);
            })
            .Build()
            .RunAsync();

        return (result, writer.ToString());
    }
}