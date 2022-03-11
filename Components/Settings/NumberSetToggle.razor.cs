using Microsoft.AspNetCore.Components;

namespace CodeConverter.Components.Settings;

public partial class NumberSetToggle
{
    private int startingNumber;

    private string ButtonClasses => IsActive ? "ln ln-active" : "ln";
    private string InputClasses => IsActive ? "ln-input ln-input-active" : "ln-input";

    [Parameter] public string? Label { get; set; }
    [Parameter] public string ActiveClass { get; set; } = "btn-success";
    [Parameter] public string InactiveClass { get; set; } = "btn-primary";
    [Parameter] public bool IsActive { get; set; }

    [Parameter]
    public int Number
    {
        get => startingNumber;
        set => startingNumber = value > 0 ? value : 1;
    }

    [Parameter] public EventCallback<bool> IsActiveChanged { get; set; }
    [Parameter] public EventCallback<int> NumberChanged { get; set; }

    private Task ToggleIsActiveAsync()
    {
        IsActive = !IsActive;
        return IsActiveChanged.InvokeAsync(IsActive);
    }

    private async Task OnValueChangedAsync(ChangeEventArgs args)
    {
        int newNumber = 1;
        int.TryParse(args.Value?.ToString(), out newNumber);
        await NumberChanged.InvokeAsync(newNumber);
    }
}