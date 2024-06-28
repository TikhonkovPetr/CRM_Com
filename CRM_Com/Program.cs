using CRM_Com;
using CRM_Com.Services;
using CRM_Com.Services.Contracts;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;
using Microsoft.Extensions.Caching.Memory;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7050/") });
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPersonService,PersonService>();
builder.Services.AddScoped<ICompanyService,CompanyService>();
builder.Services.AddScoped<IClientService,ClientService>();
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<ITransactionService,TransactionService>();
builder.Services.AddScoped<IHistoryService,HistoryService>();
builder.Services.AddScoped<IWorkTaskService, WorkTaskService>();
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
