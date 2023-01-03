using normativo.ulf.fe.HttpRepository;
using Shared.DataTransferObjects;
using Microsoft.AspNetCore.Components;

namespace normativo.ulf.fe.Pages
{
    public partial class ProductDetails
	{
		public ViewLogNormativoDto ViewLogNormativo { get; set; } = new ViewLogNormativoDto();

		[Inject]
		public IViewLogNormativoHttpRepository? ProductRepo { get; set; }

		[Parameter]
		public Guid ProductId { get; set; }

		protected async override Task OnInitializedAsync()
		{
			ViewLogNormativo = await ProductRepo.GetLogsNormativo(ProductId);
		}
	}
}
