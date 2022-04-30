namespace Models;

public static class TinyGuidIdGenerator
{
    public static string TinyGuid(this Guid guid)
    {
        return Convert.ToBase64String(guid.ToByteArray())[0..^2]
            .Replace('+', '-')
            .Replace('/', '_');
    }
}