using System.Text;

namespace TailsBlazor;

/// <summary>
/// The <see cref="ClassBuilder"/> is used to dynamically construct a string of CSS classes
/// </summary>
public class ClassBuilder
{
    private readonly StringBuilder _classBuilder = new();
    
    /// <summary>
    /// Adds a CSS class to the string if the condition is true. The condition defaults to True.
    /// </summary>
    /// <param name="className">The name of the CSS class to add</param>
    /// <param name="condition">The condition to control whether the class should be added or not</param>
    /// <returns>Returns the current instance of the ClassBuilder to allow method chaining.</returns>
    public ClassBuilder AddClass(string? className, bool condition = true)
    {
        if (!condition) return this;
        _classBuilder.Append(className);
        _classBuilder.Append(' ');

        return this;
    }

    /// <summary>
    /// Returns a string of all the added CSS classes.
    /// </summary>
    /// <returns></returns>
    public string Build() =>
        _classBuilder.ToString();
}