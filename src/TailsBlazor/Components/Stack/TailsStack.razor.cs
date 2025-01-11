using Microsoft.AspNetCore.Components;

namespace TailsBlazor;

public partial class TailsStack : TailsComponentBase
{
    /// <summary>
    /// The content to display in the stack.
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// The amount of spacing to add between the stack items. The space is applied vertically or horizontally depending on the orientation.
    /// </summary>
    [Parameter] public int Spacing { get; set; } = 4;

    /// <summary>
    /// The orientation of the stack items. By default, the stack items are oriented vertically.
    /// </summary>
    [Parameter] public Orientation Orientation { get; set; } = Orientation.Vertical;

    /// <summary>
    /// The alignment of the stack items along the main axis.
    /// </summary>
    [Parameter] public Justify Justify { get; set; } = Justify.Start;

    /// <summary>
    /// The alignment of the stack items along the cross axis.
    /// </summary>
    [Parameter] public Align Align { get; set; } = Align.Start;

    /// <summary>
    /// The width in percentage that the stack should take up. Defaults to 100% of the parent container.
    /// </summary>
    [Parameter] public double Width { get; set; } = 100;

    private string _classes => new ClassBuilder()
        .AddClass(Class)
        .AddClass("tails-stack-vertical", Orientation == Orientation.Vertical)
        .AddClass("tails-stack-horizontal", Orientation == Orientation.Horizontal)
        .AddClass($"tails-stack-v-gap-{Spacing}", Orientation == Orientation.Vertical)
        .AddClass($"tails-stack-h-gap-{Spacing}", Orientation == Orientation.Horizontal)
        .AddClass("justify-start", Justify == Justify.Start)
        .AddClass("justify-center", Justify == Justify.Center)
        .AddClass("justify-end", Justify == Justify.End)
        .AddClass("justify-between", Justify == Justify.SpaceBetween)
        .AddClass("justify-around", Justify == Justify.SpaceAround)
        .AddClass("items-start", Align == Align.Start)
        .AddClass("items-center", Align == Align.Center)
        .AddClass("items-end", Align == Align.End)
        .AddClass("items-stretch", Align == Align.Stretch)
        .AddClass("items-baseline", Align == Align.Baseline)
        .AddClass("w-full")
        .Build();

    private string _styles => new StyleBuilder()
        .AddStyle(Style)
        .AddStyle("width", $"{Width}%")
        .Build();
}
