namespace LSL.DotNetTool.Cli.Infrastructure;

public interface IConsole
{
    IConsole Write(string text, bool includeNewLine, IEnumerable<object> args);
}
