using Blazored.LocalStorage;
using DigiDish.HttpRepository;
using DigiDish.HttpRepository.Contracts;
using DigiDish_V2.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();
var apiBaseAddress = new Uri("https://localhost:7295/");

builder.Services.AddHttpClient<IUserHttpRepository, UserHttpRepository>(client =>
{
    client.BaseAddress = apiBaseAddress;
});

builder.Services.AddHttpClient<IMeasureHttpRepository, MeasureHttpRepository>(client =>
{
    client.BaseAddress = apiBaseAddress;
});

builder.Services.AddHttpClient<IProductHttpRepository, ProductHttpRepository>(client =>
{
    client.BaseAddress = apiBaseAddress;
});

builder.Services.AddHttpClient<IUserHttpRepository, UserHttpRepository>(client =>
{
    client.BaseAddress = apiBaseAddress;
});

builder.Services.AddHttpClient<IRecipeHttpRepository, RecipeHttpRepository>(client =>
{
    client.BaseAddress = apiBaseAddress;
});

builder.Services.AddHttpClient<IShoppingListHttpRepository, ShoppingListHttpRepository>(client =>
{
    client.BaseAddress = apiBaseAddress;
});
builder.Services.AddScoped<UserState>();
await builder.Build().RunAsync();
