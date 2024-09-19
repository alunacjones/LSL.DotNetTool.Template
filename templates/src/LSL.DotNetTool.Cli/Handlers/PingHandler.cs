using Microsoft.Extensions.Logging;

namespace LSL.DotNetTool.Cli.Handlers;

public class PingHandler : IAsyncHandler<Ping>
{
    private readonly ILogger<PingHandler> _logger;
    private readonly IConsole _console;

    public PingHandler(ILogger<PingHandler> logger, IConsole console)
    {
        _logger = logger;
        _console = console;
    }

    public Task<int> ExecuteAsync(Ping options)
    {
        _logger.LogInformation("Executing ping");
        _console.WriteLine(options.PongValue);
        return Task.FromResult(0);
    }
}