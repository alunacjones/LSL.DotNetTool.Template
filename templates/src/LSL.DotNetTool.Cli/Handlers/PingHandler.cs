using LSL.DotNetTool.Cli.Infrastructure;
using LSL.DotNetTool.Cli.Options;
using Microsoft.Extensions.Logging;

namespace LSL.DotNetTool.Cli.Handlers;

public class PingHandler : IAsyncHandler<Ping>
{
    private readonly ILogger<PingHandler> _logger;

    public PingHandler(ILogger<PingHandler> logger)
    {
        _logger = logger;
    }

    public Task<int> ExecuteAsync(Ping options)
    {
        _logger.LogInformation("Executing ping");
        Console.WriteLine(options.PongValue);
        return Task.FromResult(0);
    }
}