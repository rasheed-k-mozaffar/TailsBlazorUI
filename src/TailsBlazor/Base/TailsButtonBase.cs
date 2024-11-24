using Microsoft.AspNetCore.Components;

namespace TailsBlazor;

public class TailsButtonBase : TailsComponentBase
{
    /// <summary>
    /// The content to display inside the button.
    /// </summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>
    /// The event that gets triggered when the button is clicked.
    /// </summary>
    [Parameter] public EventCallback OnClick { get; set; }

    /// <summary>
    /// The event that gets triggered when the button is focused.
    /// </summary>
    [Parameter] public EventCallback OnFocus { get; set; }

    /// <summary>
    /// The event that gets triggered when the button is focused.
    /// </summary>
    [Parameter] public EventCallback OnUnfocus { get; set; }

    /// <summary>
    /// A flag to determine whether the button is disabled or not.
    /// </summary>
    [Parameter] public bool Disabled { get; set; }

    /// <summary>
    /// Sets the type of the button. The default is Button. Available other values are Submit (submits the form the button is
    /// rendered in, and Reset (Clears the form the button is rendered in). 
    /// </summary>
    [Parameter]
    public ButtonType ButtonType { get; set; } = ButtonType.Button;

    /// <summary>
    /// Sets the variation of the button. The default is Solid. Available other values are Outline and Text.
    /// </summary>
    [Parameter]
    public Variation Variation { get; set; } = Variation.Solid;

    /// <summary>
    /// Sets the color of the button. The default is Primary. You can specify any color from the Tails color palette.
    /// </summary>
    [Parameter]
    public string Color { get; set; } = Colors.Primary;

    protected virtual string GetButtonClass()
    {
        return Variation switch
        {
            Variation.Solid => $"btn-solid-{Color.GetColorClass()}",
            Variation.Outlined => $"btn-outlined-{Color.GetColorClass()}",
            Variation.Text => $"btn-text-{Color.GetColorClass()}",
            _ => $"btn-solid-{Color.GetColorClass()}"
        };
    }
}