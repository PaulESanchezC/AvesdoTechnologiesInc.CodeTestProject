namespace Models.OrderStatusModels;

public class OrderStatus
{
    public static string InProgress = "in progress";
    public static string Processed = "processed";
    public static string Canceled = "canceled";
    public static string Returned = "returned";
    public string Other { get; set; }
}