using normativo.ulf.fe.Features;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http.Json;
using System.Text.Json;

namespace normativo.ulf.fe.HttpRepository
{
    public class ViewLogNormativoHttpRepository : IViewLogNormativoHttpRepository
	{
		private readonly HttpClient _client;
		private readonly NavigationManager _navManager;
		private readonly JsonSerializerOptions _options =
			new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

		public ViewLogNormativoHttpRepository(HttpClient client, NavigationManager navManager)
		{
			_client = client;
			_navManager = navManager;
		}

        //public async Task<Product> GetProduct(Guid id)
        //{
        //	var product = await _client.GetFromJsonAsync<Product>($"products/{id}");

        //	return product;
        //}

        public async Task<PagingResponse<ViewLogNormativoDto>> GetLogsNormativo(ViewLogNormativoParameters viewLogNormativoParameters)
        {
			var queryStringParam = new Dictionary<string, string>
			{
				["pageNumber"] = viewLogNormativoParameters.PageNumber.ToString(),
				["pageSize"] = viewLogNormativoParameters.PageSize.ToString(),
				["searchTerm"] = viewLogNormativoParameters.SearchTerm == null ? string.Empty : viewLogNormativoParameters.SearchTerm,
				["orderBy"] = viewLogNormativoParameters.OrderBy == null ? "" : viewLogNormativoParameters.OrderBy
			};

			var response =
				await _client.GetAsync(QueryHelpers.AddQueryString("ReportLogsNormativo", queryStringParam));

			var content = await response.Content.ReadAsStringAsync();

			var pagingResponse = new PagingResponse<ViewLogNormativoDto>
			{
				Items = JsonSerializer.Deserialize<List<ViewLogNormativoDto>>(content, _options),
				MetaData = JsonSerializer.Deserialize<MetaData>(
					response.Headers.GetValues("X-Pagination").First(), _options)
			};

			return pagingResponse;
		}
	}
}
