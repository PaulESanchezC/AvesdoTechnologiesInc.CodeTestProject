namespace Models.OrderTypeModels;

public class OrderType
{
    public static string PhonedIn = "phoned in";
    public static string FranchiseWebsite = "franchise website service";
    public static string ExternalDeliveryService = "external delivery service";
    public string Other { get; set; }
}