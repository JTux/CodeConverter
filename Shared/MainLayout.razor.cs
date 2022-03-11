using CodeConverter.Classes;

namespace CodeConverter.Shared;

public partial class MainLayout
{
    private string language = "language-text";
    private bool isCodeTag = false;
    private bool isCopyable = false;
    private bool hasLineNumbers = false;
    private int startingLineNumber = 1;
    private bool matchBraces = false;

    private SelectItem[] Languages =
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
    };

    private bool IsTerminal => language == "terminal-text";

    private void ResetSettings()
    {
        isCodeTag = false;
        isCopyable = false;
        hasLineNumbers = false;
        startingLineNumber = 1;
        matchBraces = false;
    }
}