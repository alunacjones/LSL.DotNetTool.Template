namespace LSL.DotNetTool.Cli.Infrastructure;

public class AdditionalHelpTextProvider : IExecuteParsingFailure<int>
{
    private readonly IConsole _console;

    public AdditionalHelpTextProvider(IConsole console)
    {
        _console = console;
    }

    public int Execute(string[] args, IEnumerable<Error> errors)
    {
        _console.WriteLine("NOTE: a global --verbose flag can be used to provide debug logging");
        return 0;
    }
}
