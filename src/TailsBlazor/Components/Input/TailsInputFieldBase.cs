using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;

namespace TailsBlazor;

public class TailsInputFieldBase<T> : TailsComponentBase
{
    private const string BaseClass = "input-field";
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

    protected string? FormattedValue
    {
        get => FieldType == FieldType.Date && Value is DateTime dateValue
            ? dateValue.ToString("yyyy-MM-dd")
            : Value?.ToString();
        set
        {
            if (FieldType == FieldType.Date && typeof(T) == typeof(DateTime))
            {
                if (DateTime.TryParse(value, out var dateValue))
                {
                    if (!EqualityComparer<T>.Default.Equals(Value, (T)(object)dateValue))
                    {
                        Value = (T)(object)dateValue;
                    }
                }
            }
            else
            {
                if (!EqualityComparer<T>.Default.Equals(Value, (T)(object)value))
                {
                    Value = (T)(object)value;
                }
            }
        }
    }

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

    protected bool ShouldDeferValueChanged { get; set; }

    protected override void OnInitialized()
    {
        if (For is not null)
            FieldIdentifier = FieldIdentifier.Create(For);
    }

    protected virtual async Task HandleInput(ChangeEventArgs e)
    {
        if (e.Value is string stringValue && FieldType == FieldType.Date && typeof(T) == typeof(DateTime))
        {
            if (DateTime.TryParse(stringValue, out var dateValue))
            {
                Value = (T)(object)dateValue;

                if (Immediate)
                {
                    await ValueChanged.InvokeAsync(Value);
                    EditContext?.NotifyFieldChanged(FieldIdentifier);
                }
                else
                {
                    ShouldDeferValueChanged = true;
                }

                // If the input was triggered by a date picker, mimic blur behavior
                await HandleBlur();
            }
        }
        else if (e.Value is T newValue)
        {
            Value = newValue;

            if (Immediate)
            {
                await ValueChanged.InvokeAsync(newValue);
                EditContext?.NotifyFieldChanged(FieldIdentifier);
            }
            else
            {
                ShouldDeferValueChanged = true;
            }
        }
    }

    protected async Task HandleBlur()
    {
        if (ShouldDeferValueChanged)
        {
            ShouldDeferValueChanged = false;
            await ValueChanged.InvokeAsync(Value);
            EditContext?.NotifyFieldChanged(FieldIdentifier);
        }

        await OnBlur.InvokeAsync(); // Trigger any custom blur logic
    }

    protected virtual string GetFieldClass()
    {
        if (Disabled)
            return $"input-field-{Variation.ToString().ToLower()}-disabled {BaseClass}-{Size.ToString().ToLower()}";

        var variationClass = string.Format(StyleClass, BaseClass, Variation.ToString().ToLower(), Color.GetColorClass());
        return $"{variationClass} {BaseClass}-{Size.ToString().ToLower()}";
    }
}

