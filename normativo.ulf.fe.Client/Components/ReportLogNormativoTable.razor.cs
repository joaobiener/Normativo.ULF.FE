using Shared.DataTransferObjects;
using Microsoft.AspNetCore.Components;

namespace normativo.ulf.fe.Components
{
    public partial class ReportLogNormativoTable
	{
		[Parameter]
		public List<ViewLogNormativoDto>? viewLogsNormativos { get; set; }
	}
}
