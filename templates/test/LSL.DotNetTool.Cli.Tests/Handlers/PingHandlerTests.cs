namespace LSL.DotNetTool.Cli.Tests.Handlers;

public class PingHandlerTests : BaseCliTest
{
    [TestCase(new string[] { "ping"}, "Pong\r\n")]
    [TestCase(new string[] { "ping", "aha" }, "aha\r\n")]
    [TestCase(new string[] { "--verbose", "ping" }, "[INF] Executing ping\r\nPong\r\n")]
    [TestCase(new string[] { "ping", "aha", "--verbose" }, "[INF] Executing ping\r\naha\r\n")]
    public async Task Given_ValidArguments_ItShouldReturnTheExpectedResult(string[] args, string expectedOutput)
    {
        // Arrange
        var host = BuildTestHost(args);

        // Act
        var (result, output) = await host.RunTestCliAsync();        

        // Assert
        using var _ = new AssertionScope();

        result.Should().Be(0);
        output.Should().Be(expectedOutput);
    }
}