namespace Models.EnumModels;

public class OrderStatusTypes
{
    public string Value { get; private set; }
    public OrderStatusTypes(string value)
    {
        Value = value;
    }

    public static string Payed => new("Payed");
    public static string Preparing => new("Preparing");
    public static string OnRoute => new("On route for delivery");
    public static string Delivered => new("Order delivered");
    public static string Canceled => new("Order canceled");

    public static List<string> OrderStatusTypesList = new() { Payed, Preparing, OnRoute, Delivered,Canceled };
}
