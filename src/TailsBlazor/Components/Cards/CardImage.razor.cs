using Microsoft.AspNetCore.Components;

namespace TailsBlazor;

public partial class CardImage : TailsComponentBase
{
    private string _classes => new ClassBuilder()
        .AddClass(Class)
        .Build();
    
    [Parameter] public string Src { get; set; }
    
    [Parameter] public string? Alt { get; set; }

}