 using LSL.DotNetTool.Cli.Infrastructure;

return await HostFactory
    .Create(args)
    .Build()
    .RunAsync();