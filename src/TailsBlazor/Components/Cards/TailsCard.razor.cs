using Microsoft.AspNetCore.Components;

namespace TailsBlazor;

public partial class TailsCard : TailsComponentBase
{
    private string _classes => new ClassBuilder()
        .AddClass(GetCardClass())
        .AddClass(Class)
        .Build();
    
    private string GetCardClass()
    {
        var builder = new ClassBuilder();
        builder.AddClass("card-base");
        builder.AddClass($"card-shadow-{Shadow.GetShadowClass()}");
        builder.AddClass($"card-border-radius-{BorderRadius}");
        return builder.Build();
    }
    
    /// <summary>
    /// The content to display inside the Pill.
    /// </summary>
    [Parameter] 
    public RenderFragment ChildContent {get; set; }
    
    /// <summary>
    /// The Content to display in the Card Header
    /// </summary>
    [Parameter] public RenderFragment CardHeader { get; set; }
    
    /// <summary>
    /// The Content to display in the Card Body
    /// </summary>
    [Parameter] public RenderFragment CardBody { get; set; }

    /// <summary>
    ///  The Content to display in the Card Footer
    /// </summary>
    [Parameter] public RenderFragment CardFooter { get; set; }

    /// <summary>
    /// Sets the size of the Shadow. The default is Medium. Available sizes are ExtraSmall, Small, Medium and Large and ExtraLarge.
    /// </summary>
    [Parameter] public Shadow Shadow { get; set; } = Shadow.Medium;

    /// <summary>
    /// Sets the value for the border radius. The default is 2. Available sizes are 1, 2, 3 and 4.
    /// </summary>
    /// 
    [Parameter]
    public int BorderRadius { get; set; } = 4;

}