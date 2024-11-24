namespace TailsBlazor;

public partial class TailsButton : TailsButtonBase
{
    private string _classes => new ClassBuilder()
        .AddClass(GetButtonClass())
        .AddClass(Class)
        .Build();
}