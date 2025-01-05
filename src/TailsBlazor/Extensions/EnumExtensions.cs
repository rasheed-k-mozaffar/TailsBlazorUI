namespace TailsBlazor;

internal static class EnumExtensions
{
    /// <summary>
    /// Returns the color class based on the color string.
    /// </summary>
    /// <param name="color"></param>
    /// <returns></returns>
    public static string GetColorClass(this string color)
    {
        return color switch
        {
            Colors.Primary => "primary",
            Colors.Secondary => "secondary",
            Colors.Tertiary => "tertiary",
            Colors.Success => "success",
            Colors.Error => "danger",
            Colors.Warning => "warning",
            Colors.Info => "info",
            Colors.Neutral => "neutral",
            _ => "primary"
        };
    }

    /// <summary>
    /// Returns the button type based on the ButtonType enum.
    /// </summary>
    /// <param name="buttonType"></param>
    /// <returns></returns>
    public static string GetButtonType(this ButtonType buttonType)
    {
        return buttonType switch
        {
            ButtonType.Button => "button",
            ButtonType.Submit => "submit",
            ButtonType.Reset => "reset",
            _ => "button"
        };
    }

    /// <summary>
    /// Returns the input field type based on the FieldType enum.
    /// </summary>
    /// <param name="fieldType"></param>
    /// <returns></returns>
    public static string GetFieldType(this FieldType fieldType)
    {
        return fieldType switch
        {
            FieldType.Text => "text",
            FieldType.Password => "password",
            FieldType.Email => "email",
            FieldType.Number => "number",
            FieldType.Phone => "tel",
            FieldType.Date => "date",
            FieldType.Time => "time",
            _ => "text"
        };
    }
}
