namespace CodeConverter.Classes;

public class ConverterData
{
    public string Language { get; set; } = "language-text";
    public bool IsCodeTag { get; set; } = false;
    public bool IsCopyable { get; set; } = false;
    public bool HasLineNumbers { get; set; } = false;
    public int StartingLineNumber { get; set; } = 1;
    public bool MatchBraces { get; set; } = false;

    public SelectItem[] Languages { get; set; } = new SelectItem[0];
}