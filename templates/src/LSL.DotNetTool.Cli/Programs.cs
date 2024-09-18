 using LSL.DotNetTool.Cli.Infrastructure;

return await HostBuilderFactory
    .Create(args)
    .Build()
    .RunAsync();