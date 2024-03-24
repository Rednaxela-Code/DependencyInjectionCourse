using AddKeyResolve;
using Microsoft.Extensions.DependencyInjection;

var collection = new ServiceCollection();

collection.AddKeyedSingleton<ITaxCalculator, AustralianTaxCalculator>(UserLocations.Australia);
collection.AddKeyedSingleton<ITaxCalculator, EuropeTaxCalculator>(UserLocations.Europe);

var provider = collection.BuildServiceProvider();

ITaxCalculator calculator = provider.GetKeyedService<ITaxCalculator>(UserLocations.Europe);

Console.WriteLine($"Your tax rate is {calculator.Calculate()}");
Console.ReadKey();