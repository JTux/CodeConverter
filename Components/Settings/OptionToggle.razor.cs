using CodeConverter.Classes;
using Microsoft.AspNetCore.Components;

namespace CodeConverter.Components.Settings;

public partial class OptionToggle
{
    [Parameter] public SelectItem[]? Options { get; set; }
    [Parameter] public string? Value { get; set; }
    [Parameter] public EventCallback<string> ValueChanged { get; set; }

    private async Task OnValueChangedAsync(ChangeEventArgs args)
    {
        await ValueChanged.InvokeAsync(args.Value?.ToString() ?? string.Empty);
    }
}