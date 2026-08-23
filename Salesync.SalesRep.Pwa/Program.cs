using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Salesync.SalesRep.Pwa;
using Salesync.SalesRep.Pwa.Auth;
using Salesync.SalesRep.Pwa.Services.Api;
using Salesync.SalesRep.Pwa.Services.Api.Operations;
using Salesync.SalesRep.Pwa.Services.Api.Supervisor;
using Salesync.SalesRep.Pwa.Services.Interfaces;
using Salesync.SalesRep.Pwa.Storage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var apiBaseUrl = builder.Configuration["ApiBaseUrl"]
    ?? throw new InvalidOperationException(
        "ApiBaseUrl is missing from appsettings.json.");

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();

builder.Services.AddScoped<AuthStorageService>();

builder.Services.AddScoped<SalesyncAuthenticationStateProvider>();

builder.Services.AddScoped<AuthenticationStateProvider>(serviceProvider => serviceProvider.GetRequiredService<SalesyncAuthenticationStateProvider>());

builder.Services.AddScoped<AuthMessageHandler>();

builder.Services.AddHttpClient(
        "SalesyncApi",
        client =>
        {
            client.BaseAddress = new Uri(apiBaseUrl);
        })
    .AddHttpMessageHandler<AuthMessageHandler>();

builder.Services.AddScoped(
    serviceProvider => serviceProvider
    .GetRequiredService<IHttpClientFactory>()
    .CreateClient("SalesyncApi"));

builder.Services.AddScoped<IAuthApiService, AuthApiService>();
builder.Services.AddScoped<ISalesRepSessionApiService, SalesRepSessionApiService>();
builder.Services.AddScoped<ISalesRepCustomerApiService, SalesRepCustomerApiService>();
builder.Services.AddScoped<ISalesRepVisitApiService, SalesRepVisitApiService>();
builder.Services.AddScoped<ISalesRepInvoiceApiService, SalesRepInvoiceApiService>();
builder.Services.AddScoped<ISalesRepLoadRequestApiService, SalesRepLoadRequestApiService>();
builder.Services.AddScoped<ISalesRepUnloadRequestApiService, SalesRepUnloadRequestApiService>();
builder.Services.AddScoped<ISalesRepPaymentApiService, SalesRepPaymentApiService>();
builder.Services.AddScoped<ISalesRepRouteApiService, SalesRepRouteApiService>();
builder.Services.AddScoped<ISalesRepInvoiceReturnApiService,SalesRepInvoiceReturnApiService>();
builder.Services.AddScoped<SupervisorReportApiService>();
builder.Services.AddScoped<ProfileApiService>();

builder.Services.AddScoped<LoadRequestOperationsApiService>();
builder.Services.AddScoped<SupervisorSalesRepApiService>();

await builder.Build().RunAsync();