using CodeConverter.Classes;

namespace CodeConverter.Shared;

public partial class MainLayout
{
    private ConverterData data = new()
    {
        Language = "language-text",
        StartingLineNumber = 1,
        Languages = new SelectItem[]
        {
            new("Plain Text", "language-text"),
            new("Terminal", "terminal-text"),
            new("C#", "language-csharp"),
            new("CSS", "language-css"),
            new("HTML", "language-html"),
            new("JavaScript", "language-javascript"),
            new("JSX", "language-jsx"),
            new("Markdown", "language-markdown"),
            new("Razor", "language-cshtml"),
            new("SQL", "language-sql"),
            new("TSX", "language-tsx"),
            new("TypeScript", "language-typescript")
        }
    };

    private bool IsTerminal => data.Language == "terminal-text";

    private void ResetSettings()
    {
        data.IsCodeTag = false;
        data.IsCopyable = false;
        data.HasLineNumbers = false;
        data.StartingLineNumber = 1;
        data.MatchBraces = false;
    }
}