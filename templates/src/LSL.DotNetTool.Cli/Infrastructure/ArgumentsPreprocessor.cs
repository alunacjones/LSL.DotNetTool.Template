namespace LSL.DotNetTool.Cli.Infrastructure;

/// <summary>
/// Provides a helper to consume the <c>--verbose</c> flag external to <c>CommandLineParser</c>
/// </summary>
/// <remarks>This is used as we need to setup logging more eagerly than parsing the command line options</remarks>
public static class ArgumentsPreprocessor
{
    public static (bool IsVerbose, string[] FilteredArguments) ProcessArguments(string[] args)
    {       
        var filteredResult = args.Aggregate(
            new { IsVerbose = false, FilteredArgs = new List<string>() },
            (agg, i) =>
            {
                if (i == "--verbose")
                {
                    return new 
                    {
                        IsVerbose = true,
                        agg.FilteredArgs,
                    };
                }

                agg.FilteredArgs.Add(i);

                return agg;
            });

        return (filteredResult.IsVerbose, filteredResult.FilteredArgs.ToArray());
    }
}
