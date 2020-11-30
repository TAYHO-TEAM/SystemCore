using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MongoDb.Common.Interfaces
{
    public interface IMongoRepository<TDocument> where TDocument : IDocument
    {
        IQueryable<TDocument> AsQueryable();
        IEnumerable<TDocument> FilterBy(Expression<Func<TDocument, bool>> filterExpression);
        IEnumerable<TProjected> FilterBy<TProjected>(Expression<Func<TDocument, bool>> filterExpression, Expression<Func<TDocument, TProjected>> projectionExpression);
        TDocument FindOne(Expression<Func<TDocument, bool>> filterExpression);
        Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression);
        TDocument FindById(string id);
        Task<TDocument> FindByIdAsync(string id);
        Task InsertOneAsync(TDocument document);
        Task InsertManyAsync(ICollection<TDocument> documents);
        Task ReplaceOneAsync(TDocument document);
        Task DeleteOneAsync(Expression<Func<TDocument, bool>> filterExpression);
        Task DeleteByIdAsync(string id);
        Task DeleteManyAsync(Expression<Func<TDocument, bool>> filterExpression);
    }
}