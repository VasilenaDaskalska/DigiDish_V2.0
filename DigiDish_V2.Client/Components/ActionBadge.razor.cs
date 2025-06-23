using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace DigiDish_V2.Client.Components
{
    public partial class ActionBadge
    {
        [Parameter]
        public EventCallback OnClick { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string Icon { get; set; }

        [Parameter]
        public Color IconColor { get; set; }

        [Parameter]
        public bool Outlined { get; set; }
    }
}
