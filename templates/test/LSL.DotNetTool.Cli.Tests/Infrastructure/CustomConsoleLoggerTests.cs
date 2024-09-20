using FluentAssertions;
using LSL.DotNetTool.Cli.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;

namespace LSL.DotNetTool.Cli.Tests.Infrastructure;

public class CustomConsoleLoggerTests
{
    [Test]
    public void GivenCallsToTheLogger_ThenItShouldProduceTheExpectedLogs()
    {
        // Arrange
        using var writer = new StringWriter();

        var host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddSingleton<IConsole, DefaultConsole>()
                    .AddSingleton<LoggingTesting>()
                    .Configure<ConsoleOptions>(o => o.TextWriter = writer)
                    .AddLogging(l =>
                    {
                        l.ClearProviders();

                        l.Services
                            .AddSingleton<ILoggerProvider>(
                                s => new CustomConsoleLoggerProvider(s.GetRequiredService<IConsole>())
                            );
                        
                        LoggerProviderOptions.RegisterProviderOptions<ConsoleOptions, CustomConsoleLogger>(l.Services);
                        l.SetMinimumLevel(LogLevel.Trace);
                    });

            })
            .Build();

        // Act
        var test = host.Services.GetRequiredService<LoggingTesting>();
        test.LogAllLevels();

        // Assert
        writer.ToString().Should().Be(
            """
            [CRT] als
            [DBG] als
            [ERR] als
            [INF] als
            [] als
            [WRN] als

            """
        );
    }

    public class LoggingTesting(ILogger<LoggingTesting> logger)
    {
        public void LogAllLevels()
        {
            const string message = "als";

            logger.LogCritical(message);
            logger.LogDebug(message);
            logger.LogError(message);
            logger.LogInformation(message);
            logger.LogTrace(message);
            logger.LogWarning(message);
        }
    }
}