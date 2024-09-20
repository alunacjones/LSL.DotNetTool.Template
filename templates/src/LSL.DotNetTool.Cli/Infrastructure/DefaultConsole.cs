using Microsoft.Extensions.Options;

namespace LSL.DotNetTool.Cli.Infrastructure;

public class DefaultConsole : IConsole
{
    private readonly ConsoleOptions _options;

    public DefaultConsole(IOptions<ConsoleOptions> options) => _options = options.Value;

    public IConsole Write(string text, bool includeNewLine, IEnumerable<object> args)
    {
        IConsole Execute(Action action)
        {
            action();
            return this;
        }

        return (includeNewLine, args) switch
        {
            (true, _) when args.Any() => Execute(() => _options.TextWriter.WriteLine(text, args.ToArray())),
            (true, _) => Execute(() => Execute(() => _options.TextWriter.WriteLine(text))),
            (false, _) when args.Any() => Execute(() => _options.TextWriter.Write(text, args.ToArray())),
            (false, _) => Execute(() => _options.TextWriter.Write(text))
        };
    }
}