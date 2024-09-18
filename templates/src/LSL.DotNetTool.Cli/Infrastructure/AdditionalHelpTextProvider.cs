using CommandLine;
using CommandLineParser.DependencyInjection.Interfaces;

namespace LSL.DotNetTool.Cli.Infrastructure;

public class AdditionalHelpTextProvider : IExecuteParsingFailure<int>
{
    public int Execute(string[] args, IEnumerable<Error> errors)
    {
        Console.WriteLine("NOTE: a global --verbose flag can be used to provide debug logging");
        return 1;
    }
}
