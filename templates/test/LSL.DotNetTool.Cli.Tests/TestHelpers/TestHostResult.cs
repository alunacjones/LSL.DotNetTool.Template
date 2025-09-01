namespace LSL.DotNetTool.Cli.Tests.TestHelpers;

public record TestHostResult(int Result, string Output, IServiceProvider ServiceProvider)
{
    public void Deconstruct(out int result, out string output)
    {
        result = Result;
        output = Output;
    }
}