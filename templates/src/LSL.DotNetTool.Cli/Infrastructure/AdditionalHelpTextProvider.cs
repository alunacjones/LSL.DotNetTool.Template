namespace LSL.DotNetTool.Cli.Infrastructure;

/// <summary>
/// Provides additional help text showing the <c>--verbose</c>
/// </summary>
public class AdditionalHelpTextProvider(IConsole console) : IExecuteParsingFailure<int>
{
    public int Execute(string[] args, IEnumerable<Error> errors)
    {
        if (!errors.IsVersion()) console.WriteLine("NOTE: a global --verbose flag can be used to provide debug logging");
        return 0;
    }
}
