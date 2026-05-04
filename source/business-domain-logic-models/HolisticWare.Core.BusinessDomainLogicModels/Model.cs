namespace HolisticWare.Core.BusinessDomainLogicModels;

public partial class 
                                        Model
{
    public
        string?
                                        Name
    {
        get;
        set;
    }

    public
        System.DateTime?
                                        TimeStamp
    {
        get;
        set;
    }

    public
        double
                                        Age
                                        (
                                            DateTime begin
                                        )
    {
        DateTime end = DateTime.Now;
        TimeSpan a = end - begin;

        return a.TotalDays / 365.2425;
    }    
}
