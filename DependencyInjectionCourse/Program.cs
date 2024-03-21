using System.Xml.Serialization;

public class UserInterface
{
    private string _userName;
    private string _password;

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

        var biz = new Business();
        biz.Signup(_userName, _password);
    }
}

public class Business
{
    public void Signup(string userName, string password)
    {
        var da = new DataAccess();
        da.Signup(userName, password);
    }
}

public class DataAccess
{
    //Henk doet dit
    public void Signup(string userName, string password)
    {
        // Use EF to write data into SQL Server
    }
}