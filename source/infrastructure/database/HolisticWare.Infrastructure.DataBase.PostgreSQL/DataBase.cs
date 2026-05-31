namespace HolisticWare.Core.Infrastructure.DataBase.PostgreSQL;

public partial class
                                        DataBase
{
    public
        string?
                                        ConnectionString
    {
        get
        {
            if (field == null)
            {
                
            }

            return "";
        }
        set;
    }
    
    public
        string?
                                        Server
    {
        get;
        set;
    } = "localhost";
    
    public
        string?
                                        Database
    {
        get;
        set;
    } = "Demo";
    
    public
        string?
                                        User
    {
        get;
        set;
    }
    
    public
        string?
                                        Password
    {
        get;
        set;
    }
}
