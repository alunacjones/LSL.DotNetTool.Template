using LSL.AbstractConsole.ServiceProvider;
using LSL.DotNetTool.Cli.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LSL.DotNetTool.Cli.Tests.TestHelpers;

public abstract class BaseCliTest
{
    protected static IHost BuildTestHost(
        string[] args,
        Action<IServiceCollection>? servicesConfigurator = null)
    {
        var writer = new StringWriter();

        return HostBuilderFactory.Create(args)
            .ConfigureServices((context, services) =>
            {
                services.Configure<ConsoleOptions>(s =>
                {
                    s.TextWriter = writer;
                });

                servicesConfigurator?.Invoke(services);
            })
            .Build();
    }
}