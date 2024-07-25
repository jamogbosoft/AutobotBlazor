global using AutobotBlazor.Client;
global using AutobotBlazor.Client.Service.CandidateService;
global using AutobotBlazor.Client.Service.CentreService;
global using AutobotBlazor.Client.Service.ExamService;
global using AutobotBlazor.Shared.Models;
global using Microsoft.AspNetCore.Components.Authorization;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<ICentreService, CentreService>();
builder.Services.AddScoped<IExamService, ExamService>();
builder.Services.AddScoped<ICandidateService, CandidateService>();

await builder.Build().RunAsync();
