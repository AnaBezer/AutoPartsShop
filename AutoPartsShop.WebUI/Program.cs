using AutoPartsShop.WebUI;
using AutoPartsShop.WebUI.Services;
using AutoPartsShop.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7115/") });
builder.Services.AddScoped<IProductService, ProductService>();


await builder.Build().RunAsync();
