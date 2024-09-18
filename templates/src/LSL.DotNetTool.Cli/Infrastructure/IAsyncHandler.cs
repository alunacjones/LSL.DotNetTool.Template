using CommandLineParser.DependencyInjection.Interfaces;

namespace LSL.DotNetTool.Cli.Infrastructure;

public interface IAsyncHandler<T> : IExecuteCommandLineOptionsAsync<T, int>
    where T : ICommandLineOptions {}