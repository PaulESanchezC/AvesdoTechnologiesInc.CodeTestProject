using System.Linq.Expressions;
using ApiOrderService.Controllers;
using Microsoft.AspNetCore.Mvc;
using Models.OrderModels;
using Models.ResponseModels;
using Moq;
using NUnit.Framework;
using Services.Repository.OrderRepository;

namespace ApiOrderServiceTests.OrderControllerTests;

[TestFixture]
public class GetAllOrdersWithPagination
{
    private OrderController _orderController;
    private Mock<IOrderRepository> _orderRepository;
    [SetUp]
    public void Setup()
    {
        _orderRepository = new();
        _orderController = new(_orderRepository.Object);
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
        var responseObject = new List<OrderDto>
        {
            new() { OrderId = "1" }
        };
        var response = new Response<OrderDto>
            { IsSuccessful = true, Message = "Ok", Title = "Ok", StatusCode = 200, ResponseObject = responseObject };

        _orderRepository.Setup(method => method.GetAllWithPagesAsync(
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<Expression<Func<Order, bool>>>(),
                It.IsAny<Expression<Func<Order, object>>>(),
                It.IsAny<CancellationToken>(),
                It.IsAny<Expression<Func<Order, object>>[]>()))
            .ReturnsAsync(response);

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

        var result = await _orderController.GetAllOrdersWithPagination(0, 0, CancellationToken.None);


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
    

}