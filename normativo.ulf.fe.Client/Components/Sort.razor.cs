﻿using Microsoft.AspNetCore.Components;

namespace normativo.ulf.fe.Components
{
    public partial class Sort
	{
		[Parameter]
		public EventCallback<string> OnSortChanged { get; set; }

		private async Task ApplySort(ChangeEventArgs eventArgs)
		{
			if (eventArgs.Value.ToString() == "-1")
				return;

			await OnSortChanged.InvokeAsync(eventArgs.Value.ToString());
		}
	}
}
