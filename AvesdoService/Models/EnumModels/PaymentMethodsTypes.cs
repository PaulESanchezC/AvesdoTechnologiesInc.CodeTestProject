namespace Models.EnumModels;

public class PaymentMethodsTypes
{
    public string Value { get; private set; }
    public PaymentMethodsTypes(string value)
    {
        Value = value;
    }

    public static string Card => new("Card");
    public static string ApplePay => new("ApplePay");
    public static string GooglePay => new("GooglePay");
    public static string Other => new("Other");

    public static List<string> PaymentMethodsList => new() { Card, ApplePay, GooglePay, Other };

}