using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Web.SharedComponents.Components;

/// <summary>
/// App header.
/// </summary>
public partial class AppHeader : ComponentBase
{
    /// <summary>
    /// Theme.
    /// </summary>
    [Inject]
    private MudTheme Theme { get; set; } = null!;

    [Parameter]
    public string LogoutPath { get; set; }

    [Parameter]
    public bool IsAuthenticated { get; set; }
}
