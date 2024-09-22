using CommandLine;
using CommandLineParser.DependencyInjection.Interfaces;
using FluentAssertions;
using FluentAssertions.Execution;
using LSL.AbstractConsole;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LSL.DotNetTool.Cli.Tests.Handlers;

public class DefaultHandlingTests : BaseCliTest
{
    [TestCase(new string[] { "--help" }, null)]
    [TestCase(new string[] { "help" }, null)]
    public async Task GivenACallWithTheHelpOption_ItShouldOutputTheHelpText(string[] args, string dummy)
    {
        // Arrange
        var host = BuildTestHost(args);

        // Act
        var (result, output) = await host.RunTestCliAsync();

        // Assert
        using var _ = new AssertionScope();

        result.Should().Be(0);
        output.Should().Contain("help");
    }

    [TestCase(new string[] { "--version" }, null)]
    [TestCase(new string[] { "version" }, null)]
    public async Task GivenACallWithTheVersionOption_ItShouldOutputTheVersionText(string[] args, string dummy)
    {
        // Arrange
        var host = BuildTestHost(args);

        // Act
        var (result, output) = await host.RunTestCliAsync();

        // Assert
        using var _ = new AssertionScope();

        result.Should().Be(0);
        output.Should().MatchRegex(@"\d+\.\d+\.\d+");
    }

    [TestCase(new string[] { "test", "--verbose" }, 
        """
        a message with more
        and again
        [CRT] log
        [DBG] log
        [ERR] log
        [INF] log
        [WRN] log

        """)
    ]
    [TestCase(new string[] { "test" }, 
        """
        a message with more
        and again

        """)
    ]    
    public async Task GivenACallWithATestVerb_ItShouldOutputTheTheExpectedResult(string[] args, string expectedOutput)
    {
        // Arrange
        var host = BuildTestHost(
            args,
            s =>
            {
                s.AddSingleton<ICommandLineOptions, Test>();
                s.AddSingleton<IExecuteCommandLineOptionsAsync<Test, int>, TestHandler>();
            });

        // Act
        var (result, output) = await host.RunTestCliAsync();

        // Assert
        using var _ = new AssertionScope();

        result.Should().Be(0);
        output.Should().Be(expectedOutput);
    }    


    [Verb("test")]
    public class Test : ICommandLineOptions
    {
        [Option('n', "name")]
        public string Name { get; set; } = default!;
    }

    public class TestHandler(ILogger<TestHandler> logger, IConsole console) : IExecuteCommandLineOptionsAsync<Test, int>
    {
        public Task<int> ExecuteAsync(Test options)
        {
            console.Write("a")
                .Write(" {0}", "message")
                .WriteLine(" with {0}", "more")
                .WriteLine("and again");

            logger.LogCritical("log");
            logger.LogDebug("log");
            logger.LogError("log");
            logger.LogInformation("log");
            logger.LogTrace("log");
            logger.LogWarning("log");

            return Task.FromResult(0);
        }
    }    
}