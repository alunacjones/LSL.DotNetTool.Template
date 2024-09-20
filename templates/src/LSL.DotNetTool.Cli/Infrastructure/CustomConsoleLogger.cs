using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Logging;

namespace LSL.DotNetTool.Cli.Infrastructure;

public class CustomConsoleLogger : ILogger
{
    private readonly IConsole _console;

    public CustomConsoleLogger(IConsole console)
    {
        _console = console;
    }

    [ExcludeFromCodeCoverage]
    public IDisposable? BeginScope<TState>(TState state) where TState : notnull => default!;

    [ExcludeFromCodeCoverage]
    public bool IsEnabled(LogLevel logLevel) => true;

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        _console.Write($"[{LogLevelToShortCode(logLevel)}] ");
        _console.WriteLine($"{formatter(state, exception)}");
    }

    private static string LogLevelToShortCode(LogLevel logLevel) => logLevel switch
    {
        LogLevel.Debug => "DBG",
        LogLevel.Information => "INF",
        LogLevel.Warning => "WRN",
        LogLevel.Error => "ERR",
        LogLevel.Critical => "CRT",
        _ => ""
    };
}