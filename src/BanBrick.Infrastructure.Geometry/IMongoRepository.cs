using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BanBrick.Infrastructure.Geometry
{
    public interface IMongoRepository<TDocument>
    {
        IMongoCollection<TDocument> Collection { get; }
        
        Task InsertOneAsync(TDocument document);

        Task InsertManyAsync(IEnumerable<TDocument> documents);

        Task<IAsyncCursor<TDocument>> FindAsync(Expression<Func<TDocument, bool>> predicate,
            FindOptions<TDocument, TDocument> options = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
