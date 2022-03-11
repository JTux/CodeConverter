using CodeConverter.Classes;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace CodeConverter.Pages;

public partial class Converter
{
    [Inject] private IJSRuntime jsRuntime { get; set; }
    [CascadingParameter] public ConverterData Data { get; set; } = new();

    public string? Input { get; set; }

    public string PreTagClasses
    {
        get
        {
            List<string> classes = new();

            if (Data.IsTerminal)
                classes.Add("terminal");

            if (Data.IsCopyable)
                classes.Add("copyable");

            if (Data.HasLineNumbers)
                classes.Add("line-numbers");

            return string.Join(' ', classes);
        }
    }

    public string CodeTagClasses
    {
        get
        {
            List<string> classes = new();

            classes.Add(Data.Language);

            if (Data.IsCodeTag)
            {
                if (Data.IsTerminal)
                    classes.Add("terminal");

            }
            if (Data.IsCopyable)
                classes.Add("copyable");

            if (Data.MatchBraces)
                classes.Add("match-braces");

            return string.Join(' ', classes);
        }
    }

    public string Output
    {
        get
        {
            if (string.IsNullOrWhiteSpace(Input))
                return "";

            var content = Input.Replace("<", "&lt;");
            content = content.Replace(">", "&gt;");

            return Data.IsCodeTag ? GetCodeTag(content) : GetPreTag(content);
        }
    }

    private string GetPreTag(string body)
    {
        string preTagData = "";

        if (string.IsNullOrEmpty(PreTagClasses) == false)
            preTagData += $" class=\"{PreTagClasses}\"";

        if (Data.HasLineNumbers)
            preTagData += $" data-start=\"{Data.StartingLineNumber}\"";

        // if (Data.HasHighlight)
        //     preTagData += $" data-line=\"{Data.HighlightedLines}\"";

        return $"<pre{preTagData}><code class=\"{CodeTagClasses}\">{body}</code></pre>";
    }

    private string GetCodeTag(string body)
    {
        return $"<code class=\"{CodeTagClasses}\">{body}</code>";
    }

    private MarkupString PreviewOutput => new MarkupString(Output);

    private async void CopyOutput() => await jsRuntime.InvokeVoidAsync("navigator.clipboard.writeText", Output);

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await jsRuntime.InvokeVoidAsync("window.Prism.highlightAll");
    }

    private void Clear()
    {
        Input = "";
    }
}