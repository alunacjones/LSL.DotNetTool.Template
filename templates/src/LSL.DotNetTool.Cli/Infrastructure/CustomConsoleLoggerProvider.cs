using Microsoft.Extensions.Logging;

namespace LSL.DotNetTool.Cli.Infrastructure;

public class CustomConsoleLoggerProvider : ILoggerProvider
{
    private readonly IConsole _console;

    public CustomConsoleLoggerProvider(IConsole console) => _console = console;

    public ILogger CreateLogger(string categoryName) => new CustomConsoleLogger(_console);

    public void Dispose() => GC.SuppressFinalize(this);
}
