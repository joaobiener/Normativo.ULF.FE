﻿using Microsoft.AspNetCore.Components;

namespace normativo.ulf.fe.Components
{
    public partial class Search
	{
		public string SearchTerm { get; set; }

		private Timer _timer;

		[Parameter]
		public EventCallback<string> OnSearchChanged { get; set; }

		private void SearchChanged()
		{
			if (_timer != null)
				_timer.Dispose();

			_timer = new Timer(OnTimerElapsed, null, 500, 0);
		}

		private void OnTimerElapsed(object sender)
		{
			OnSearchChanged.InvokeAsync(SearchTerm);

			_timer.Dispose();
		}
	}
}
