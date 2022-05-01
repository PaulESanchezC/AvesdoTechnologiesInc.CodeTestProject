using Models.CustomerModels;
using Models.EmploymentRoleModels;
using Models.ProductModels;
using Models.StoreModels;
using Models.TaxModels;

namespace Models.MessageQueueModels;

public class ProductionQueueMessage
{
    public bool IsNewProduct { get; set; }
    public Product NewProduct { get; set; }

    public bool IsNewTax { get; set; }
    public Tax NewTax { get; set; }

    public bool IsNewStore { get; set; }
    public Store NewStore { get; set; }

    public bool IsNewEmploymentRole { get; set; }
    public EmploymentRole NewEmploymentRole { get; set; }

    public bool IsNewCostumer { get; set; }
    public Customer NewCustomer { get; set; }
}