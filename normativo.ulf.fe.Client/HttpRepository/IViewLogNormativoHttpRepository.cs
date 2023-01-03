using normativo.ulf.fe.Features;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;


namespace normativo.ulf.fe.HttpRepository
{
    public interface IViewLogNormativoHttpRepository
	{
		Task<PagingResponse<ViewLogNormativoDto>> GetLogsNormativo(ViewLogNormativoParameters viewLogNormativoParameters);
		//Task<Product> GetProduct(Guid id);
	}
}
