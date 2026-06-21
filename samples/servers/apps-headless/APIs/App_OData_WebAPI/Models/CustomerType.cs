using System;

namespace App_OData_WebAPI.Models
{
    [Flags]
    public enum CustomerType
    {
        None = 1,
        Premium = 2,
        VIP = 4
    }
}
