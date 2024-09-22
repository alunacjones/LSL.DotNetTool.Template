namespace LSL.DotNetTool.Cli.Tests.Handlers;

public class PingHandlerTests : BaseCliTest
{
    [TestCase(new string[] { "ping"}, 
        """
        Pong

        """)]
    [TestCase(new string[] { "ping", "aha" }, 
        """
        aha

        """)]
    [TestCase(new string[] { "--verbose", "ping" }, 
        """
        [INF] Executing ping
        Pong

        """)]
    [TestCase(new string[] { "ping", "aha", "--verbose" }, 
        """
        [INF] Executing ping
        aha
        
        """)]
    public async Task Given_ValidArguments_ItShouldReturnTheExpectedResult(string[] args, string expectedOutput)
    {
        // Arrange
        var sut = BuildTestHostRunner(args);
        
        // Act
        var (result, output) = await sut();        

        // Assert
        using var _ = new AssertionScope();

        result.Should().Be(0);
        output.Should().Be(expectedOutput.NormaliseLineEndings());
    }
}