using Microsoft.AspNetCore.Components;

namespace CodeConverter.Components.Settings;

public partial class SettingToggle
{
    [Parameter] public RenderFragment? ChildContent {get;set;}
    [Parameter] public bool IsActive { get; set; }
    [Parameter] public EventCallback<bool> IsActiveChanged { get; set; }
    [Parameter] public string ActiveClass { get; set; } = "btn-success";
    [Parameter] public string InactiveClass { get; set; } = "btn-primary";

    private Task ToggleIsActiveAsync()
    {
        IsActive = !IsActive;
        return IsActiveChanged.InvokeAsync(IsActive);
    }
}
