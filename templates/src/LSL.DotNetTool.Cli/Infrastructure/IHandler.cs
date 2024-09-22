namespace LSL.DotNetTool.Cli.Infrastructure;

public interface IHandler<T> : IExecuteCommandLineOptions<T, int>
    where T : ICommandLineOptions {}