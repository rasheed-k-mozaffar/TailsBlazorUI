using Microsoft.AspNetCore.Components;

namespace TailsBlazor;

public class TailsComponentBase : ComponentBase
{
    /// <summary>
    /// The CSS or Tailwind classes to apply on the component
    /// </summary>
    [Parameter]
    public string? Class { get; set; }

    /// <summary>
    /// The CSS inline styles to apply on the component
    /// </summary>
    [Parameter] 
    public string? Style { get; set; }
    
    /// <summary>
    /// The HTML attributes to apply on the component 
    /// </summary>
    [Parameter] 
    public Dictionary<string, object>? UserAttributes { get; set; }
}