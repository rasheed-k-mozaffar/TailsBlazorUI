using Microsoft.AspNetCore.Components;

namespace TailsBlazor;

public class TailsButtonBase : ComponentBase
{
    [Parameter] public RenderFragment ChildContent { get; set; }
    
    [Parameter] public EventCallback OnClick { get; set; }
    
    [Parameter] public Dictionary<string, object>? UserAttributes { get; set; }
    
    [Parameter] public bool Disabled { get; set; }
    
    [Parameter] public string? Class { get; set; }
    
    [Parameter] public string? Style { get; set; }
}