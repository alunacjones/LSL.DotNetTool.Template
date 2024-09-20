using Microsoft.Extensions.Options;

namespace LSL.DotNetTool.Cli.Infrastructure;

public class DefaultConsole : IConsole
{
    private readonly ConsoleOptions _options;

    public DefaultConsole(IOptions<ConsoleOptions> options)
    {
        _options = options.Value;
    }

    public IConsole Write(string text, bool includeNewLine, IEnumerable<object> args)
    {
        if (includeNewLine)
        {
            if (args.Any())
            {
                _options.TextWriter.WriteLine(text, args.ToArray());
            }
            else
            {
                _options.TextWriter.WriteLine(text);
            }
        }
        else
        {
            if (args.Any())
            {
                _options.TextWriter.Write(text, args.ToArray());
            }
            else
            {
                _options.TextWriter.Write(text);
            }
        }

        return this;
    }
}