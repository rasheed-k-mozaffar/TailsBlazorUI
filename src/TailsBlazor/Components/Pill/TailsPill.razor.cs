using Microsoft.AspNetCore.Components;

namespace TailsBlazor.Components.Pill;

public partial class TailsPill
{
    /// <summary>
    /// The content to display inside the Pill.
    /// </summary>
    [Parameter] 
    public RenderFragment ChildContent {get; set; }
    
    /// <summary>
    /// Sets the variation of the Pill. The default is Solid. Available other values are Outlined and Text.
    /// </summary>
    [Parameter]
    public Variation Variation { get; set; } = Variation.Solid;
    
    /// <summary>
    /// Sets the color of the Pill. The default is Primary. You can specify any color from the Tails color palette.
    /// </summary>
    [Parameter]
    public string Color { get; set; } = Colors.Primary;

    /// <summary>
    /// Sets the size of the text. The default is Medium. Available sizes are Small, Medium and Large.
    /// </summary>
    [Parameter] 
    public Size Size { get; set; } = Size.Medium;
    
    private string _classes => new ClassBuilder()
        .AddClass(GetPillClass())
        .Build();

    private string GetPillClass()
    {
        var builder = new ClassBuilder();
        
        builder = Variation switch
        {
            Variation.Solid => builder.AddClass($"pill-solid-{Color.GetColorClass()}"),
            Variation.Outlined => builder.AddClass($"pill-outlined-{Color.GetColorClass()}"),
            Variation.Text => builder.AddClass($"pill-text-{Color.GetColorClass()}"),
            _ => builder.AddClass($"pill-solid-{Color.GetColorClass()}"),
        };

        builder.AddClass($"pill-text-{Size.GetSizeClass()}");
        return builder.Build();
    }
}