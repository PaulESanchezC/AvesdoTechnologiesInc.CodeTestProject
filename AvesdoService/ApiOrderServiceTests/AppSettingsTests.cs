using ApiOrderServiceTests.TestModels.TestOptionsModels;
using ApiOrderServiceTests.TestServices;
using ApiOrderServiceTests.TestStaticData;

using NUnit.Framework;


namespace ApiOrderServiceTests;

[TestFixture]
public class AppSettingsTests
{
    private ConnectionStringOptionsTest _connectionString;
    private RabbitMqOptionsTest _rabbitMqOptionsTest;
    private JwtOptionsTest _jwtOptions;

    [SetUp]
    public void Setup()
    {
        _connectionString = AppSettingsJsonService.TestConfigure<ConnectionStringOptionsTest>(TestContext.CurrentContext.TestDirectory, AppSettingsConstants.ConnectionString);
        _rabbitMqOptionsTest = AppSettingsJsonService.TestConfigure<RabbitMqOptionsTest>(TestContext.CurrentContext.TestDirectory, AppSettingsConstants.RabbitMq);
        _jwtOptions = AppSettingsJsonService.TestConfigure<JwtOptionsTest>(TestContext.CurrentContext.TestDirectory, AppSettingsConstants.JwtOptions);
    }

    [Test]
    public void ConnectionStrings_AppSettings_Values()
    {
        Assert.AreEqual(
            "Server=(localdb)\\MSSQLLocalDB;Database=Avesdo_Orders_Service;Trusted_Connection=True;MultipleActiveResultSets=true",
            _connectionString.AsvesdoOrderService_ConnectionString);
    }

    [Test]
    public void RabbitMq_AppSettings_Values()
    {
        Assert.AreEqual("localhost", _rabbitMqOptionsTest.Hostname);
        Assert.AreEqual("guest", _rabbitMqOptionsTest.Password);
        Assert.AreEqual("guest", _rabbitMqOptionsTest.Username);
        Assert.AreEqual("Production Queue Message", _rabbitMqOptionsTest.ProductionQueueMessage);
        Assert.AreEqual("Sales Queue Message", _rabbitMqOptionsTest.SalesQueueMessage);
    }
    [Test]

    public void JwtOptions_AppSettings_Values()
    {
        Assert.AreEqual("914f0a63-adce-46f4-9843-d382b5032702", _jwtOptions.SecretKey);
    }
}