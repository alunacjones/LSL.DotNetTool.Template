namespace LSL.DotNetTool.Cli.Infrastructure;

public class DefaultConsole : IConsole
{
    private readonly TextWriter _writer;

    public DefaultConsole(TextWriter writer) => _writer = writer;

    public IConsole Write(string text, bool includeNewLine, IEnumerable<object> args)
    {
        IConsole Execute(Action action)
        {
            action();
            return this;
        }

        return (includeNewLine, args) switch
        {
            (true, _) when args.Any() => Execute(() => _writer.WriteLine(text, args.ToArray())),
            (true, _) => Execute(() => Execute(() => _writer.WriteLine(text))),
            (false, _) when args.Any() => Execute(() => _writer.Write(text, args.ToArray())),
            (false, _) => Execute(() => _writer.Write(text))
        };
    }
}