using System.Security.AccessControl;
using Models.OrderModels;
using Models.TutorialModels;

namespace Services.TutorialServices;

public interface ITutorialService
{
    Task<string> ProvideJwtToken();
    Task<OrderCreateDto> GenerateOrderCreateDtoAsync(string storeId, string customerId, CancellationToken cancellationToken, params TutorialOrderCreateDto[] products);
}