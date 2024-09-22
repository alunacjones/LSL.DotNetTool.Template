namespace LSL.DotNetTool.Cli.Tests.TestHelpers;

public static class LineEndingNormalisingExtensions
{
    /// <summary>
    /// Ensures that line endings are in line with <c>Environment.NewLine</c>
    /// </summary>
    /// <remarks>
    /// C# multi-line string constants that use triple quotes seem to just add <c>\n</c> as line endings. This ensures we are consistent with <c>Environment.NewLine</c>
    /// </remarks>
    /// <param name="value">The source string</param>
    /// <returns>The normalised string</returns>
    public static string NormaliseLineEndings(this string value) => value.ReplaceLineEndings(Environment.NewLine);
}