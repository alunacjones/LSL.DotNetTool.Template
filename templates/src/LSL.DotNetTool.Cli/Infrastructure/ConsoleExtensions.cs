namespace LSL.DotNetTool.Cli.Infrastructure;

public static class ConsoleExtensions
{
    private static readonly IEnumerable<object> _emptyArgs = Enumerable.Empty<object>();

    public static IConsole Write(this IConsole console, string text, params object[] args) => console.Write(text, false, args);
    public static IConsole Write(this IConsole console, string text) => console.Write(text, false, _emptyArgs);
    public static IConsole WriteLine(this IConsole console, string text) => console.Write(text, true, _emptyArgs);
    public static IConsole WriteLine(this IConsole console, string text, params object[] args) => console.Write(text, true, args);
}