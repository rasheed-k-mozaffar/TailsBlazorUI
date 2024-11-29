namespace TailsBlazor;

public partial class TailsAlert : TailsAlertBase
{
    private string _classes => new ClassBuilder()
        .AddClass(GetAlertClass())
        .AddClass(Class)
        .Build();
}