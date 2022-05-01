using System.Linq.Expressions;
using Models.ResponseModels;

namespace Services.TinyRepository;

public interface ITinyRepository<T, TDto>
    where T : class
    where TDto : class
{
    Task<Response<TDto>> GetAllByAsync(Expression<Func<T, bool>>? predicate, Expression<Func<T, object>>? orderBy, bool descending, CancellationToken cancellationToken, params Expression<Func<T, object>>[] includes);
    Task<Response<TDto>> GetSingleByAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken, params Expression<Func<T, object>>[] includes);
    Task<Response<TDto>> ResponseSingleBuilderTask(bool isSuccessful, int statusCode, string title, string message,
        T? responseObject);
    Task<Response<TDto>> ResponseManyBuilderTask(bool isSuccessful, int statusCode, string title, string message,
        List<T>? responseObject);
}