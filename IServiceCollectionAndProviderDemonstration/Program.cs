using Microsoft.Extensions.DependencyInjection;

IServiceCollection collection = new ServiceCollection();
collection.AddScoped<IDataAccess, DataAccess>();
collection.AddScoped<IBusiness, Business>();
collection.AddScoped<UserInterface>();

IServiceProvider provider = collection.BuildServiceProvider();

UserInterface ui = provider.GetService<UserInterface>();

ui.Signup();

public class UserInterface
{
    private IBusiness _business;

    public UserInterface(IBusiness business)
    {
        _business = business;
    }

    public void Signup()
    {
        Console.Write("Enter User Name:");
        string _userName = Console.ReadLine();
        Console.Write("Enter Password:");
        string _password = Console.ReadLine();
        _business.Signup(_userName, _password);
    }
}

public interface IBusiness
{
    public void Signup(string userName, string password);
}

public class Business : IBusiness
{
    private IDataAccess _access;

    public Business(IDataAccess access)
    {
        _access = access;
    }
    public void Signup(string userName, string password)
    {
        _access.Signup(userName, password);
    }
}

public interface IDataAccess
{
    public void Signup(string userName, string password);
}

public class DataAccess : IDataAccess
{
    public void Signup(string userName, string password)
    {
        // Use EF to write data into SQL Server
    }
}