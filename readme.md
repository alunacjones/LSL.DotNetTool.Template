[![Build status](https://img.shields.io/appveyor/ci/alunacjones/lsl-dotnettool-template.svg)](https://ci.appveyor.com/project/alunacjones/lsl-dotnettool-template)
[![NuGet](https://img.shields.io/nuget/v/LSL.DotNetTool.Template.svg)](https://www.nuget.org/packages/LSL.DotNetTool.Template/)

# LSL.DotNetTool.Template

A template to quickly create a dotnet tool with dependency injection

## Installation

Use the following to install the template:

`dotnet new install LSL.DotNetTool.Template`

Once installed a new template called `lsl.dotnettool` will be availble to create a skeleton CLI.

## Available Parameters

| Parameter Name | Short Parameter Name | Description                                                                  |Required?|
| -------------- | -------------------- | ---------------------------------------------------------------------------- | - |
| includeExample | in                   | Creates an example verb, its handler and a unit test for the handler (Ping) |No|
| commandName | c | Set the command name for your tool. |Yes|

> **NOTE** it is advised to try running the template with examples included to see how everything is structured and to see an example of unit testing your handlers. (`dotnet new lsl.dotnettool --includeExample -n MyTest --commandName MyCommand`)

## Further Information

### 3rd Party libraries

A generated tool depends on the following packages:

|Package|URLs|
|-|-|
|CommandLineParser|[NuGet](https://www.nuget.org/packages/commandlineparser), [Documentation](https://github.com/commandlineparser/commandline/blob/master/README.md) |
|CommandLineParser.DependencyInjection | [Nuget](https://www.nuget.org/packages/CommandLineParser.DependencyInjection), [Documentation](https://github.com/JaronrH/CommandLineParser.DependencyInjection)

It is advised to read their documentation to familiarise yourself with the key concepts involved in using the libraries.

### Configuring your Service Collection

The generated tool has a file `src/<YourSolution>.Cli/Infrastructure/HostBuilderFactory.cs` which is where any configuration of services and the default host should be placed.

### Folder Strucure
The generated solution is structured as follows:

```
├── src
│   ├── <YourSolution>.Cli
│   |   ├── Handlers 
│   |   ├── Infastructure 
│   |   ├── Options
├── test
|   ├── <YourSolution>.Cli.Tests
|   |   ├── Handlers
|   |   ├── TestHelpers
```

### Conventions

* It is advised to add all `Option` classes to the `src/<YourSolution>.Cli/Options` folder.
* It is advised to add all `Handler` classes to the `src/<YourSolution>.Cli/Handlers` folder.

Adding classes to the above folders will automatically include any new options and handlers at runtime.

Use an `IConsole` to write any messages to the console. This abstraction allows for easier testing.

### Unit Testing

All tests for `Handler` classes should be placed under the `test/<YourSolution>.Cli.Tests/Handlers` folder.

A base class is available to start off your testing of your CLI. Once again it is worth generating a CLI with the `--includeExample` option to see an example of unit testing a handler.
