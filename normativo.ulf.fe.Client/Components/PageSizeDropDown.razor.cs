using Microsoft.AspNetCore.Components;

namespace normativo.ulf.fe.Components
{
    public partial class PageSizeDropDown
	{
		[Parameter]
		public EventCallback<int> SelectedPageSize { get; set; }

		private async Task OnPageSizeChange(ChangeEventArgs eventArgs)
		{
			await SelectedPageSize.InvokeAsync(Int32.Parse(eventArgs.Value.ToString()));
		}
	}
}
