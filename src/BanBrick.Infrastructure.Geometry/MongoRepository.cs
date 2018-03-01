using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BanBrick.Infrastructure.Geometry
{
    public class MongoRepository<TDocument> : IMongoRepository<TDocument>
    {
        private IMongoCollection<TDocument> _collection;

        public IMongoCollection<TDocument> Collection => _collection;

        public MongoRepository(IMongoDatabase database, string collectionName)
        {
            _collection = database.GetCollection<TDocument>(collectionName);
        }

        public async Task InsertOneAsync(TDocument document)
        {
            await _collection.InsertOneAsync(document);
        }

        public async Task InsertManyAsync(IEnumerable<TDocument> documents)
        {
            await _collection.InsertManyAsync(documents);
        }

        public async Task<IAsyncCursor<TDocument>> FindAsync(Expression<Func<TDocument, bool>> predicate,
            FindOptions<TDocument, TDocument> options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _collection.FindAsync(predicate, options, cancellationToken);
        }
    }
}
