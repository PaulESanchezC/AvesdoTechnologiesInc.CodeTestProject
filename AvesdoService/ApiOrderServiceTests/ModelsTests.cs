using FluentAssertions;
using Models.CustomerModels;
using Models.EmploymentRoleModels;
using NUnit.Framework;

namespace ApiOrderServiceTests;

[TestFixture]
public class ModelsTests
{
    [Test]
    public void Customer_Model_Properties_Validation()
    {
        var customer = new Customer();
        var model = typeof(Customer);
        var properties = model.GetProperties();

        var customerId = model.GetProperty("CustomerId");
        var customerFirstName = model.GetProperty("CustomerFirstName");
        var customerLastName = model.GetProperty("CustomerLastName");
        var customerPhoneNumber = model.GetProperty("CustomerPhoneNumber");
        var customerEmail = model.GetProperty("CustomerEmail");
        var customerAddress = model.GetProperty("CustomerAddress");
        var customerCity = model.GetProperty("CustomerCity");
        var customerStateOrProvince = model.GetProperty("CustomerStateOrProvince");
        var customerZipCode = model.GetProperty("CustomerZipCode");
        var customerPreferredPronoun = model.GetProperty("CustomerPreferredPronoun");
        var cateCreated = model.GetProperty("DateCreated");
        var customIsActiveerId = model.GetProperty("IsActive");

        Assert.NotNull(customer.CustomerId);
        Assert.NotNull(customer.DateCreated);
        Assert.AreEqual(36,customer.CustomerId.Length);
        Assert.AreEqual(DateTime.Now.Date,customer.DateCreated.Date);
        Assert.AreEqual(true,customer.IsActive);

        Assert.NotNull(properties);
        Assert.AreEqual(12, properties.Length);

        Assert.NotNull(customerId);
        Assert.NotNull(customerFirstName);
        Assert.NotNull(customerLastName);
        Assert.NotNull(customerPhoneNumber);
        Assert.NotNull(customerEmail);
        Assert.NotNull(customerAddress);
        Assert.NotNull(customerCity);
        Assert.NotNull(customerStateOrProvince);
        Assert.NotNull(customerZipCode);
        Assert.NotNull(customerPreferredPronoun);
        Assert.NotNull(cateCreated);
        Assert.NotNull(customIsActiveerId);
    }

    [Test]
    public void CustomerDto_Model_Properties__Validation()
    {
        var model = typeof(CustomerDto);
        var properties = model.GetProperties();

        var customerId = model.GetProperty("CustomerId");
        var customerFirstName = model.GetProperty("CustomerFirstName");
        var customerLastName = model.GetProperty("CustomerLastName");
        var customerPhoneNumber = model.GetProperty("CustomerPhoneNumber");
        var customerEmail = model.GetProperty("CustomerEmail");
        var customerAddress = model.GetProperty("CustomerAddress");
        var customerCity = model.GetProperty("CustomerCity");
        var customerStateOrProvince = model.GetProperty("CustomerStateOrProvince");
        var customerZipCode = model.GetProperty("CustomerZipCode");
        var customerPreferredPronoun = model.GetProperty("CustomerPreferredPronoun");

        Assert.NotNull(properties);
        Assert.AreEqual(10, properties.Length);

        Assert.NotNull(customerId);
        Assert.NotNull(customerFirstName);
        Assert.NotNull(customerLastName);
        Assert.NotNull(customerPhoneNumber);
        Assert.NotNull(customerEmail);
        Assert.NotNull(customerAddress);
        Assert.NotNull(customerCity);
        Assert.NotNull(customerStateOrProvince);
        Assert.NotNull(customerZipCode);
        Assert.NotNull(customerPreferredPronoun);
    }

    [Test]
    public void EmploymentRole_Properties__Validation()
    {
        var employmentRole = new EmploymentRole();
        var model = typeof(EmploymentRole);
        var properties = model.GetProperties();

        var employmentRoleId = model.GetProperty("EmploymentRoleId");
        var employmentRoleName = model.GetProperty("EmploymentRoleName");
        var employmentRoleDescription = model.GetProperty("EmploymentRoleDescription");
        var employmentDateCreated = model.GetProperty("DateCreated");
        var employmentIsActive = model.GetProperty("IsActive");


        Assert.AreEqual(DateTime.Now.Date,employmentRole.DateCreated.Date);
        Assert.AreEqual(true,employmentRole.IsActive);
        Assert.NotNull(properties);
        Assert.AreEqual(5,properties.Length);
        Assert.NotNull(employmentRoleId);
        Assert.NotNull(employmentRoleName);
        Assert.NotNull(employmentRoleDescription);
        Assert.NotNull(employmentDateCreated);
        Assert.NotNull(employmentIsActive);
    }



}