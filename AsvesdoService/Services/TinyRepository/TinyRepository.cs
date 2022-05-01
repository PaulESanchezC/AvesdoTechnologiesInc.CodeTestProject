using System.Linq.Expressions;
using AutoMapper;
using Data;
using Microsoft.EntityFrameworkCore;
using Models.ResponseModels;

namespace Services.TinyRepository;

public class TinyRepository<T,TDto> : ITinyRepository<T,TDto>
    where T : class
    where TDto : class
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _db;

    public TinyRepository(IMapper mapper, ApplicationDbContext db)
    {
        _mapper = mapper;
        _db = db;
    }

    public async Task<Response<TDto>> GetAllByAsync(Expression<Func<T, bool>>? predicate, Expression<Func<T, object>>? orderBy, bool descending ,CancellationToken cancellationToken,
        params Expression<Func<T, object>>[] includes)
    {
        var query = _db.Set<T>().AsQueryable().AsNoTracking();

        var result = includes.Aggregate(query, (result, data) => result.Include(data));
        if (predicate != null)
            result = result.Where(predicate);

        if (orderBy is not null)
            result = descending ? result.OrderByDescending(orderBy) : result.OrderBy(orderBy);

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