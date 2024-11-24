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
            Colors.Error => "danger",
            Colors.Warning => "warning",
            Colors.Info => "info",
            Colors.Neutral => "neutral",
            _ => "primary"
        };
    }
}
