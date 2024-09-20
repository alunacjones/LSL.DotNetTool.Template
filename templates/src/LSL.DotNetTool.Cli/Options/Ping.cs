using CommandLine;
using CommandLineParser.DependencyInjection.Interfaces;

namespace LSL.DotNetTool.Cli.Options;

[Verb("ping")]
public class Ping : ICommandLineOptions
{
    [Value(0, Required = false)]
    public string PongValue { get; set; } = "Pong";
}