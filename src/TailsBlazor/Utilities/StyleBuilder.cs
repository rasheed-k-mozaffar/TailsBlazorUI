using System;
using System.Text;

namespace TailsBlazor;

/// <summary>
/// The <see cref="ClassBuilder"/> is used to dynamically construct a string of CSS classes
/// </summary>
public class StyleBuilder
{
    private readonly StringBuilder _stylesBuilder = new StringBuilder();

    /// <summary>
    /// Adds a CSS styling rule and the value associated with it. The can be conditionally appended based on a provided condition.
    /// </summary>
    /// <param name="name">The name of the CSS styling property</param>
    /// <param name="value">The value of the CSS property</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public StyleBuilder AddStyle(string name, string value, bool condition = true)
    {
        if (!condition) return this;

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Style name cannot be null or whitespace.", nameof(name));
        }

        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Style value cannot null or whitespace.", nameof(value));
        }
        _stylesBuilder.Append($"{name}: {value};");
        return this;
    }

    public StyleBuilder AddStyle(string? styles)
    {
        if (string.IsNullOrWhiteSpace(styles)) return this;

        _stylesBuilder.Append(styles);
        _stylesBuilder.Append(";");
        return this;
    }

    /// <summary>
    /// Returns a string of all the added CSS styles.
    /// </summary>
    /// <returns></returns>
    public string Build()
    {
        return _stylesBuilder.ToString();
    }
}
