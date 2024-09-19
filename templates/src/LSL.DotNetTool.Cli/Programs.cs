using System.Diagnostics.CodeAnalysis;

return await HostBuilderFactory
    .Create(args)
    .Build()
    .RunAsync();

[ExcludeFromCodeCoverage]
public partial class Program { }