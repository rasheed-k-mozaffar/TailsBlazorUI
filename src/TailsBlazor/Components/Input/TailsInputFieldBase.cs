using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Components.Forms;

namespace TailsBlazor;

public class TailsInputFieldBase<T> : TailsComponentBase
{
    private const string BaseClass = "input-field";
    private const string DisabledClass = "{0}-{1}-disabled";
    private const string StyleClass = "{0}-{1}-{2}";

    protected FieldIdentifier FieldIdentifier;
    protected bool IsInvalid => EditContext?.GetValidationMessages(FieldIdentifier).Any() ?? false;
    protected string Classes => new ClassBuilder()
        .AddClass(GetFieldClass())
        .AddClass(GlobalConstantClassNames.InputFieldInvalid, IsInvalid)
        .Build();

    /// <summary>
    /// The value of the input field.
    /// </summary>
    [Parameter] public T? Value { get; set; }

    /// <summary>
    /// The callback which is called when the value of the input field changes.
    /// </summary>
    [Parameter] public EventCallback<T> ValueChanged { get; set; }

    /// <summary>
    /// An expression that identifies the value of the input field.
    /// </summary>
    [Parameter] public Expression<Func<T>>? ValueExpression { get; set; }

    /// <summary>
    /// The callback which is called when the input field gets focus.
    /// </summary>
    [Parameter] public EventCallback OnFocus { get; set; }

    /// <summary>
    /// The callback which is called when the input field loses focus.
    /// </summary>
    [Parameter] public EventCallback OnBlur { get; set; }

    /// <summary>
    /// The variation of the input field. Default is outlined. Available options are Solid, Outlined, and Text.
    /// </summary>
    [Parameter] public Variation Variation { get; set; } = Variation.Outlined;

    /// <summary>
    /// The type of the input field. Default is text. Available options are Text, Password, Email, Number, and Phone.
    /// </summary>
    [Parameter] public FieldType FieldType { get; set; } = FieldType.Text;

    /// <summary>
    /// The size of the input field. Default is standard. Available options are Small, Standard, and Large.
    /// </summary>
    [Parameter] public InputSize Size { get; set; } = InputSize.Standard;

    /// <summary>
    /// The accents color of the input field.
    /// </summary>
    [Parameter] public string Color { get; set; } = Colors.Primary;

    /// <summary>
    /// The placeholder text of the input field.
    /// </summary>
    [Parameter] public string? Placeholder { get; set; }

    /// <summary>
    /// Determines whether the input field is disabled or not.
    /// </summary>
    [Parameter] public bool Disabled { get; set; }

    /// <summary>
    /// Determines whether the input field is read-only or not.
    /// </summary>
    [Parameter] public bool ReadOnly { get; set; }

    /// <summary>
    /// Makes the validation state of the component immediate or not. Default is true. If set to false, the validation state will be updated only when the input field loses focus.
    /// </summary>
    [Parameter] public bool Immediate { get; set; }

    /// <summary>
    /// An expression that identifies the property to validate for the input field.
    /// </summary>
    [Parameter] public Expression<Func<T>>? For { get; set; }

    /// <summary>
    /// The EditContext of the input field.
    /// </summary>
    [CascadingParameter] public EditContext? EditContext { get; set; }

    protected override void OnInitialized()
    {
        if (For is not null)
            FieldIdentifier = FieldIdentifier.Create(For);
    }
    protected async Task HandleInput(ChangeEventArgs e)
    {
        if (e.Value is T newValue)
        {
            Value = newValue;
            await ValueChanged.InvokeAsync(newValue);
            if (Immediate)
                EditContext?.NotifyFieldChanged(FieldIdentifier);
        }
    }

    protected virtual string GetFieldClass()
    {
        if (Disabled)
            return $"input-field-{Variation.ToString().ToLower()}-disabled {BaseClass}-{Size.ToString().ToLower()}";

        var variationClass = string.Format(StyleClass, BaseClass, Variation.ToString().ToLower(), Color.GetColorClass());
        return $"{variationClass} {BaseClass}-{Size.ToString().ToLower()}";
    }
}

