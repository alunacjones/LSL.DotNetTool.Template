namespace LSL.DotNetTool.Cli.Handlers;

public class PingHandler(ILogger<PingHandler> logger, IConsole console) : IAsyncHandler<Ping>
{
    public Task<int> ExecuteAsync(Ping options)
    {
        logger.LogInformation("Executing ping");
        console.WriteLine(options.PongValue);
        return Task.FromResult(0);
    }
}