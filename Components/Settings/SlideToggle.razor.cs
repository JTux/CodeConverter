using Microsoft.AspNetCore.Components;

namespace CodeConverter.Components.Settings;

public partial class SlideToggle
{
    [Parameter] public string? InactiveLabel { get; set; }
    [Parameter] public string? ActiveLabel { get; set; }
    [Parameter] public string ActiveClass { get; set; } = "code-btn";
    [Parameter] public string InactiveClass { get; set; } = "code-btn code-btn-hidden";
    [Parameter] public bool IsActive { get; set; }
    [Parameter] public EventCallback<bool> IsActiveChanged { get; set; }

    private Task ToggleIsActiveAsync()
    {
        IsActive = !IsActive;
        return IsActiveChanged.InvokeAsync(IsActive);
    }
}