namespace LSL.DotNetTool.Cli.Infrastructure;

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
