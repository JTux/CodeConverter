using Microsoft.AspNetCore.Components;

namespace CodeConverter.Shared;

public partial class NavMenu
{
    private bool collapseNavMenu = true;

    private string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;
    [Parameter] public RenderFragment? ChildContent { get; set; }

    private void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
    }
}