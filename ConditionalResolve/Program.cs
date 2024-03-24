using ConditionalResolve;
using Microsoft.Extensions.DependencyInjection;

var collection = new ServiceCollection();
collection.AddScoped<EuropeTaxCalculator>();
collection.AddScoped<AustralianTaxCalculator>();

collection.AddScoped<Func<UserLocations, ITaxCalculator>>(
    ServiceProvider => key =>
    {
        switch (key)
        {
            case UserLocations.Europe: return ServiceProvider.GetService<EuropeTaxCalculator>();
            case UserLocations.Australia: return ServiceProvider.GetService<AustralianTaxCalculator>();
            default: return null;
        }
    }
    );

collection.AddSingleton<Purchase>();

var provider =  collection.BuildServiceProvider();

var purchase = provider.GetService<Purchase>();
var totalCharge = purchase.CheckOut(UserLocations.Australia);

Console.WriteLine(totalCharge);
Console.WriteLine("Press a key");
Console.ReadKey();