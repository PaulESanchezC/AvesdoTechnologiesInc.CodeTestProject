using System.Linq.Expressions;
using AutoMapper;
using Data;
using Microsoft.EntityFrameworkCore;
using Models.ResponseModels;

namespace Services.Repository;
public class Repository<T, TDto, TCreate> : IRepository<T, TDto, TCreate>
    where T : class
    where TDto : class
    where TCreate : class
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _db;
    public Repository(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<Response<TDto>> GetAllByAsync(Expression<Func<T, bool>>? predicate, Expression<Func<T, object>>? orderBy, CancellationToken cancellationToken, params Expression<Func<T, object>>[] includes)
    {
        var query = _db.Set<T>().AsQueryable().AsNoTracking();

        var result = includes.Aggregate(query, (result, data) => result.Include(data));
        if (predicate != null)
            result = result.Where(predicate);

        if (orderBy is not null)
            result = result.OrderBy(orderBy);

        if (!result.Any())
            return await ResponseSingleBuilderTask(false, 404, "Empty Result", "The operation returned an empty result", null);

        return await ResponseManyBuilderTask(true, 200, "Ok", "Ok", await result.ToListAsync(cancellationToken));
    }

    public async Task<Response<TDto>> GetSingleByAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken, params Expression<Func<T, object>>[] includes)
    {
        var query = _db.Set<T>()
            .AsQueryable()
            .AsNoTracking();

        var result = includes.Aggregate(query, (result, data) => result.Include(data));
        result = result.Where(predicate);

        if (!result.Any())
            return await ResponseSingleBuilderTask(false, 400, "Empty Result", "The operation returned an empty result", null);
        if (result.Count() > 1)
            return await ResponseSingleBuilderTask(false, 300, "Multiple Results", "The operation returned an more than one result", null);

        return await ResponseSingleBuilderTask(true, 200, "Ok", "Ok", await result.FirstOrDefaultAsync(cancellationToken));
    }

    public async Task<Response<TDto>> GetAllWithPagesAsync(int pageSize, int currentPage, Expression<Func<T, bool>>? predicate, Expression<Func<T, object>>? orderBy,
        CancellationToken cancellationToken, params Expression<Func<T, object>>[] includes)
    {
        var query = _db.Set<T>()
            .AsQueryable()
            .AsNoTracking();

        var result = includes.Aggregate(query, (result, data) => result.Include(data));
        if (predicate != null)
            result = result.Where(predicate);
        if (orderBy != null)
            result = result.OrderBy(orderBy);

        var pagination = result.Skip((currentPage - 1) * pageSize).Take(pageSize);

        if (!pagination.Any())
            return await ResponseSingleBuilderTask(false, 400, "Empty Result", "The operation returned an empty result", null);

        return await ResponseManyBuilderTask(true, 200, "Ok", "Ok", await pagination.ToListAsync(cancellationToken));
    }

    public async Task<Response<TDto>> CreateAsync(TCreate objectToCreate, CancellationToken cancellationToken)
    {
        var objectToCreateT = _mapper.Map<T>(objectToCreate);

        var entity = await _db.AddAsync<T>(objectToCreateT, cancellationToken);
        if (entity.State != EntityState.Added)
            return await ResponseSingleBuilderTask(false, 409, "Operation Failed", $"Could not add the {typeof(T).Name}", null);

        try
        {
            await _db.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException e)
        {
            return await ResponseSingleBuilderTask(false, 409, "Operation Failed", $"Could not save the {typeof(T).Name}", null);
        }

        return await ResponseSingleBuilderTask(true, 201, "Ok", "Ok", objectToCreateT);
    }


    public Task<Response<TDto>> ResponseSingleBuilderTask(bool isSuccessful, int statusCode, string title, string message, T? responseObject)
    {
        var responseObjectDto = new List<TDto> { _mapper.Map<TDto>(responseObject) };

        var response = new Response<TDto>
        {
            IsSuccessful = isSuccessful,
            StatusCode = statusCode,
            Title = title,
            Message = message,
            ResponseObject = responseObjectDto
        };
        return Task.FromResult(response);
    }

    public Task<Response<TDto>> ResponseManyBuilderTask(bool isSuccessful, int statusCode, string title, string message, List<T>? responseObject)
    {
        var responseObjectDto = new List<TDto>();
        if (responseObject != null)
            responseObjectDto.AddRange(responseObject.Select(item => _mapper.Map<TDto>(item)));

        var response = new Response<TDto>
        {
            IsSuccessful = isSuccessful,
            StatusCode = statusCode,
            Title = title,
            Message = message,
            ResponseObject = responseObjectDto
        };
        return Task.FromResult(response);
    }
}