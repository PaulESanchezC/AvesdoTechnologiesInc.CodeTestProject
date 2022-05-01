using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using ApiOrderService.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Models.OrderModels;
using Models.ResponseModels;
using Moq;
using NUnit.Framework;
using Services.Repository.OrderRepository;

namespace ApiOrderServiceTests;

[TestFixture]
public class OrderControllerTests
{
    private OrderController _orderController;
    private Mock<IOrderRepository> _orderRepository;
    private Response<OrderDto> ExpectedResponse;

    [SetUp]
    public void Setup()
    {
        _orderRepository = new();
        _orderController = new(_orderRepository.Object);
        
        
        var responseObject = new List<OrderDto>
        {
            new() { OrderId = "1" }
        };
        ExpectedResponse = new Response<OrderDto>
            { IsSuccessful = true, Message = "Ok", Title = "Ok", StatusCode = 200, ResponseObject = responseObject };
    }

    [Test]
    public async Task GetAllOrdersWithPagination_WhenInputsAreCorrect_Verify_ReturnNotNull_ServiceCall_ReturnType()
    {
        const int pageSize = 1;
        const int currentPage = 1;
        _orderRepository.Setup(method => method.GetAllWithPagesAsync(
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<Expression<Func<Order,bool>>>(),
                It.IsAny<Expression<Func<Order, object>>>(),
                It.IsAny<CancellationToken>(),
                It.IsAny<Expression<Func<Order,object>>[]>()))
            .ReturnsAsync(new Response<OrderDto>()).Verifiable();

        var result = await _orderController.GetAllOrdersWithPagination(pageSize, currentPage, CancellationToken.None);


        Assert.NotNull(result);
        Assert.AreEqual(typeof(ObjectResult),result.GetType());

        _orderRepository.Verify(method => method.GetAllWithPagesAsync(
            It.IsAny<int>(),
            It.IsAny<int>(),
            It.IsAny<Expression<Func<Order, bool>>>(),
            It.IsAny<Expression<Func<Order, object>>>(),
            It.IsAny<CancellationToken>(),
            It.IsAny<Expression<Func<Order, object>>[]>()),Times.Once);
    }
    [Test]
    public async Task GetAllOrdersWithPagination_Internal_WhenInputsAreCorrect_Verify_ReturnValues()
    {
        const int pageSize = 1;
        const int currentPage = 1;
        _orderRepository.Setup(method => method.GetAllWithPagesAsync(
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<Expression<Func<Order, bool>>>(),
                It.IsAny<Expression<Func<Order, object>>>(),
                It.IsAny<CancellationToken>(),
                It.IsAny<Expression<Func<Order, object>>[]>()))
            .ReturnsAsync(ExpectedResponse);

        var result =
            await _orderController.GetAllOrdersWithPagination(pageSize, currentPage, CancellationToken.None) as
                ObjectResult;
        var resultValue = (Response<OrderDto>)result.Value!;
        var orderId = resultValue.ResponseObject.First().OrderId;

        Assert.AreEqual(200,result.StatusCode);
        Assert.AreEqual("Ok", resultValue.Message);
        Assert.AreEqual("Ok",resultValue.Title);
        Assert.AreEqual(true,resultValue.IsSuccessful);
        Assert.AreEqual(result.StatusCode, resultValue.StatusCode);
        Assert.AreEqual("1",orderId);
    }
    [Test]
    public async Task GetAllOrdersWithPagination_InvalidInput_Verify_ReturnNotNull_NoServiceCall_ReturnType()
    {
        _orderRepository.Setup(method => method.GetAllWithPagesAsync(
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<Expression<Func<Order, bool>>>(),
                It.IsAny<Expression<Func<Order, object>>>(),
                It.IsAny<CancellationToken>(),
                It.IsAny<Expression<Func<Order, object>>[]>()))
            .ReturnsAsync(new Response<OrderDto>()).Verifiable();

        var result = await _orderController.GetAllOrdersWithPagination(0, 0, CancellationToken.None) as ObjectResult;

        var modelState = _orderController.ModelState;

        Assert.AreEqual(false, modelState.IsValid);
        Assert.That(modelState.ErrorCount,Is.AtLeast(1));
        Assert.NotNull(result);
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
        _orderRepository.Verify(method => method.GetAllWithPagesAsync(
            It.IsAny<int>(),
            It.IsAny<int>(),
            It.IsAny<Expression<Func<Order, bool>>>(),
            It.IsAny<Expression<Func<Order, object>>>(),
            It.IsAny<CancellationToken>(),
            It.IsAny<Expression<Func<Order, object>>[]>()), Times.Never);
    }
    [Test]
    public async Task GetAllOrdersWithPagination_InvalidInput_PageSize_Verify_ModelState()
    {
        var result = await _orderController.GetAllOrdersWithPagination(0, 1, CancellationToken.None) as ObjectResult;
        var modelState = _orderController.ModelState;

        Assert.AreEqual(false,modelState.IsValid);
        Assert.AreEqual("pageSize",modelState.Keys.First());
        Assert.AreEqual("Invalid pageSize Value, pageSize must be > 0 (zero)", modelState.Values.First().Errors.First().ErrorMessage);
    }
    [Test]
    public async Task GetAllOrdersWithPagination_InvalidInput_CurrentPage_Verify_ModelState()
    {
        var result = await _orderController.GetAllOrdersWithPagination(1, 0, CancellationToken.None) as ObjectResult;
        var modelState = _orderController.ModelState;

        Assert.AreEqual(false, modelState.IsValid);
        Assert.AreEqual("currentPage", modelState.Keys.First());
        Assert.AreEqual("Invalid currentPage Value, currentPage must be > 0 (zero)", modelState.Values.First().Errors.First().ErrorMessage);
    }


    [Test]
    public async Task GetAllOrdersForStore_ValidInput__Verify_ReturnNotNull_ServiceCall_ReturnType()
    {
        const string storeId = "Id";
        _orderRepository.Setup(method => method.GetAllByAsync(
                It.IsAny<Expression<Func<Order, bool>>>(),
                It.IsAny<Expression<Func<Order, object>>>(),
                It.IsAny<CancellationToken>(),
                It.IsAny<Expression<Func<Order, object>>[]>()))
            .ReturnsAsync(ExpectedResponse).Verifiable();

        var result = await _orderController.GetAllOrdersForStore(storeId, CancellationToken.None) as ObjectResult;
        var resultValue = (Response<OrderDto>)result.Value!;

        Assert.NotNull(result);
        Assert.AreEqual(typeof(ObjectResult),result.GetType());
        Assert.AreEqual(200,result.StatusCode);
        Assert.AreEqual("Ok",resultValue.Title);
        Assert.AreEqual("Ok",resultValue.Message);
        Assert.AreEqual(true, resultValue.IsSuccessful);
        Assert.AreEqual(result.StatusCode,resultValue.StatusCode);
    }
    [Test]
    public async Task GetAllOrdersForStore_InvalidInput__Verify_ReturnNotNull_NoServiceCall_ReturnType_ModelState()
    {
        _orderRepository.Setup(method => method.GetAllByAsync(
                It.IsAny<Expression<Func<Order, bool>>>(),
                It.IsAny<Expression<Func<Order, object>>>(),
                It.IsAny<CancellationToken>(),
                It.IsAny<Expression<Func<Order, object>>[]>()))
            .ReturnsAsync(new Response<OrderDto>()).Verifiable();

        var result = await _orderController.GetAllOrdersForStore(string.Empty, CancellationToken.None) as ObjectResult;
        var modelState = _orderController.ModelState;

        Assert.AreEqual(false, modelState.IsValid);
        Assert.AreEqual("storeId", modelState.Keys.First());
        Assert.AreEqual("The storeId field is required.", modelState.Values.First().Errors.First().ErrorMessage);
        Assert.AreEqual(400,result.StatusCode);
        _orderRepository.Verify(method => method.GetAllByAsync(
                It.IsAny<Expression<Func<Order, bool>>>(),
                It.IsAny<Expression<Func<Order, object>>>(),
                It.IsAny<CancellationToken>(),
                It.IsAny<Expression<Func<Order, object>>[]>()), Times.Never);
    }


    [Test]
    public async Task FindAllOrdersForStoreByDate_ValidInput__Verify_ReturnNotNull_ServiceCall_ReturnType()
    {
        const string storeId = "id";
        const string dateRequest = "12-30-2000";
        _orderRepository.Setup(method => method.GetAllByAsync(
                It.IsAny<Expression<Func<Order, bool>>>(),
                It.IsAny<Expression<Func<Order, object>>>(),
                It.IsAny<CancellationToken>(),
                It.IsAny<Expression<Func<Order, object>>[]>()))
            .ReturnsAsync(ExpectedResponse).Verifiable();

        var result = await _orderController.FindAllOrdersForStoreByDate(storeId, dateRequest, CancellationToken.None) as ObjectResult;
        var resultValue = (Response<OrderDto>)result.Value;

        Assert.NotNull(result);
        Assert.NotNull(resultValue);
        Assert.AreEqual(typeof(ObjectResult),result.GetType());
        Assert.AreEqual(typeof(Response<OrderDto>), resultValue.GetType());
        Assert.AreEqual(200,resultValue.StatusCode);
        Assert.AreEqual(true,resultValue.IsSuccessful);
        Assert.AreEqual("Ok",resultValue.Title);
        Assert.AreEqual("Ok",resultValue.Message);
        Assert.AreEqual("1",resultValue.ResponseObject.First().OrderId);
        Assert.AreEqual(resultValue.StatusCode,result.StatusCode);
        _orderRepository.Verify(method => method.GetAllByAsync(
            It.IsAny<Expression<Func<Order, bool>>>(),
            It.IsAny<Expression<Func<Order, object>>>(),
            It.IsAny<CancellationToken>(),
            It.IsAny<Expression<Func<Order, object>>[]>()), Times.Once);
    }
}