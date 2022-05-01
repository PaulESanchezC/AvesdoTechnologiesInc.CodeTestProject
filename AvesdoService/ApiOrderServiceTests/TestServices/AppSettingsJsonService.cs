using Microsoft.Extensions.Configuration;

namespace ApiOrderServiceTests.TestServices;

public static class AppSettingsJsonService
{
    public static IConfigurationRoot GetIConfigurationFor(string outputPath)
    {
        return new ConfigurationBuilder()
            .SetBasePath(outputPath)
            .AddJsonFile("appsettings.json", optional: true)
            .AddEnvironmentVariables()
            .Build();
    }

    public static T TestConfigure<T>(string outPath , string sectionValue)
    where T : class, new()
    {
        var model = new T();
        var config = GetIConfigurationFor(outPath);
        config.GetSection(sectionValue)
            .Bind(model);
        return model;
    }

}