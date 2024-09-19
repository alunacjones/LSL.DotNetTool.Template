using CommandLine;
using CommandLineParser.DependencyInjection.Interfaces;
using FluentAssertions;
using FluentAssertions.Execution;
using LSL.DotNetTool.Cli.Infrastructure;
using LSL.DotNetTool.Cli.Tests.TestHelpers;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace LSL.DotNetTool.Cli.Tests.Handlers;

public class PingHandlerTests : BaseCliTest
{
    [TestCase(new string[0], "Pong\r\n")]
    [TestCase(new string[] { "aha" }, "aha\r\n")]
    [TestCase(new string[] { "ping", "aha" }, "aha\r\n")]
    [TestCase(new string[] { "--verbose" }, "[INF] Executing ping\r\nPong\r\n")]
    [TestCase(new string[] { "aha", "--verbose" }, "[INF] Executing ping\r\naha\r\n")]
    [TestCase(new string[] { "ping", "aha", "--verbose" }, "[INF] Executing ping\r\naha\r\n")]
    public async Task Given_ValidArguments_ItShouldReturnTheExpectedResult(string[] args, string expectedOutput)
    {
        // Arrange
        using var writer = new StringWriter();

        // Act
        var result = await HostBuilderFactory.Create(args)
            .ConfigureServices((context, services) =>
            {
                // Setup any mocks here
                services.Configure<ConsoleOptions>(s => 
                {
                    s.TextWriter = writer;
                });
            })
            .Build()
            .RunAsync();

        // Assert
        using var _ = new AssertionScope();

        result.Should().Be(0);

        writer.ToString().Should().Be(expectedOutput);
    }

    [Verb("test")]
    public class Test : ICommandLineOptions
    {
        [Option('n', "name")]
        public string Name { get; set; } = default!;
    }

    public class TestHandler : IExecuteCommandLineOptionsAsync<Test, int>
    {
        public Task<int> ExecuteAsync(Test options)
        {
            return Task.FromResult(0);
        }
    }

    public class ConsoleOutput : IDisposable
    {
        private StringWriter _stringWriter;
        private TextWriter _originalOutput;

        public ConsoleOutput()
        {
            _stringWriter = new StringWriter();
            _originalOutput = Console.Out;
            Console.SetOut(_stringWriter);
        }

        public override string ToString() => _stringWriter.ToString();

        public void Dispose()
        {
            Console.SetOut(_originalOutput);
            _stringWriter.Dispose();
        }
    }
}