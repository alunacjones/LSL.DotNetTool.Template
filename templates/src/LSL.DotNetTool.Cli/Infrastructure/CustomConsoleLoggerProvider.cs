using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LSL.DotNetTool.Cli.Infrastructure;

public class CustomConsoleLoggerProvider : ILoggerProvider
{
    private readonly IOptions<ConsoleOptions> _options;
    private readonly IConsole _console;

    public CustomConsoleLoggerProvider(IOptions<ConsoleOptions> options, IConsole console)
    {
        _options = options;
        _console = console;
    }

    public ILogger CreateLogger(string categoryName) => new CustomConsoleLogger(_console);

    public void Dispose() => GC.SuppressFinalize(this);
}
