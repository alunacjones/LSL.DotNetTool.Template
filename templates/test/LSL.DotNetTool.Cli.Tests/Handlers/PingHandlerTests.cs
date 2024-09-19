using CommandLine;
using CommandLineParser.DependencyInjection.Interfaces;
using FluentAssertions;
using FluentAssertions.Execution;
using LSL.DotNetTool.Cli.Tests.TestHelpers;
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
        // Act
        var (result, output) = await RunCli(args);        

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

    public class TestHandler : IExecuteCommandLineOptionsAsync<Test, int>
    {
        public Task<int> ExecuteAsync(Test options)
        {
            return Task.FromResult(0);
        }
    }
}