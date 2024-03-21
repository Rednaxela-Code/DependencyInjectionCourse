using System.Xml.Serialization;

public class UserInterface
{
    private string _userName;
    private string _password;

    private IBusiness _business;

    public UserInterface()
    {
        _business = new Business();
    }

    private void GetData()
    {
        Console.Write("Enter User Name:");
        _userName = Console.ReadLine();
        Console.Write("Enter Password:");
        _password = Console.ReadLine();
    }

    public void Signup()
    {
        GetData();
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

    public Business()
    {
        _access = new DataAccess();
    }
    public void Signup(string userName, string password)
    {
        _access.Signup(userName, password);
    }
}

public interface IDataAccess
{
    public void Signup(string userName, string password)
}

public class DataAccess : IDataAccess
{
    public void Signup(string userName, string password)
    {
        // Use EF to write data into SQL Server
    }
}