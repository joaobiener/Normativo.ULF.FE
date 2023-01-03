using normativo.ulf.fe;
using normativo.ulf.fe.HttpInterceptor;
using normativo.ulf.fe.HttpRepository;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Toolbelt.Blazor.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));

builder.Services.AddHttpClient("LogsNormativoAPI", (sp, cl) =>
{
	cl.BaseAddress = new Uri("https://localhost:5011/");
	cl.EnableIntercept(sp);
});

builder.Services.AddScoped(
	sp => sp.GetService<IHttpClientFactory>().CreateClient("LogsNormativoAPI"));

builder.Services.AddHttpClientInterceptor();

builder.Services.AddScoped<IViewLogNormativoHttpRepository, ViewLogNormativoHttpRepository>();

builder.Services.AddScoped<HttpInterceptorService>();

await builder.Build().RunAsync();