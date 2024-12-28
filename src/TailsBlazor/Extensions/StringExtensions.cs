using System;

namespace TailsBlazor.Extensions;

public static class StringExtensions
{
    public static string GetColorClass(this string color)
    {
        return color switch
        {
            Colors.Primary => "primary",
            Colors.Secondary => "secondary",
            Colors.Success => "success",
            Colors.Error => "error",
            Colors.Warning => "warning",
            Colors.Info => "info",
            Colors.Neutral => "neutral",
            _ => "primary"
        };
    }

    public static string GetSizeClass(this Size size)
    {
        return size switch
        {
            Size.ExtraSmall => "xs",
            Size.Small => "sm",
            Size.Medium => "md",
            Size.Large => "lg",
            Size.ExtraLarge => "xl",
            _ => "md"
        };
    }
}
