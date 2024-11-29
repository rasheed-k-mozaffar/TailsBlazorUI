using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TailsBlazor
{
    public class TailsAlertBase : TailsComponentBase
    {
        /// <summary>
        /// The content to display inside the Alert.
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// Sets the variation of the alert. The default is Solid. Available other values are Outline and Text.
        /// </summary>
        [Parameter]
        public Variation Variation { get; set; } = Variation.Solid;

        /// <summary>
        /// Sets the color of the Alert. The default is Primary. You can specify any color from the Tails color palette.
        /// </summary>
        [Parameter]
        public string Color { get; set; } = Colors.Primary;

        protected virtual string GetAlertClass()
        {
            return Variation switch
            {
                Variation.Solid => $"alert-solid-{Color.GetColorClass()}",
                Variation.Outlined => $"alert-outlined-{Color.GetColorClass()}",
                Variation.Text => $"alert-text-{Color.GetColorClass()}",
                _ => $"alert-solid-{Color.GetColorClass()}"
            };
        }

    }
}
