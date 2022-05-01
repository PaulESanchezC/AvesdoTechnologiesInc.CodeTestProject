using System.Security.AccessControl;

namespace Models.EnumModels;

public class OrderTypeTypes
{
    public string Value { get; private set; }
    public OrderTypeTypes(string value)
    {
        Value = value;
    }

    public static string PhonedIn => new("Phoned in");
    public static string WebApp => new("Web app");
    public static string MobileApp => new("Mobile app");
    public static string ExternalCourier => new("External food courier service");

    public static List<string> OrderTypesList => new(){PhonedIn,WebApp,MobileApp,ExternalCourier};
}