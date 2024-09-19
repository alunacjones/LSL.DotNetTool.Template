using LSL.DotNetTool.Cli.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace LSL.DotNetTool.Cli.Tests.TestHelpers;

public abstract class BaseCliTest
{
    protected async Task<int> RunTest(
        string[] args,
        Action<IServiceCollection>? servicesConfigurator = null)
    {
        using var writer = new StringWriter();

        var app = HostBuilderFactory.Create(args)
            .ConfigureServices((contest, services) =>
            {
                services.Configure<ConsoleOptions>(s =>
                {
                    s.TextWriter = writer;
                });

                servicesConfigurator?.Invoke(services);
            })
            .Build();

        return await app.RunAsync();
    }
}