using AutoMapper;
using Data;
using Models.OrderModels;

namespace Services.Repository.OrderRepository;

public class OrderRepository : Repository<OrderBase, OrderDto, OrderCreateDto, OrderUpdateDto> , IOrderRepository
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;
    public OrderRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
    {
        _db = db;
        _mapper = mapper;
    }
}