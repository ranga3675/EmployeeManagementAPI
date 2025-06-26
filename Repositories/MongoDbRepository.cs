using MongoDB.Driver;
using MongoDbAPI.Data;
using MongoDbAPI.DTO;
using MongoDbAPI.Interfaces;
using MongoDbAPI.Models;

namespace MongoDbAPI.Repositories
{
    public class MongoDbRepository : IRepository<DTOEmployee>
    {
        private readonly MongoDbContext _context;
        private readonly IMongoCollection<DTOEmployee> _collection;
        public MongoDbRepository(MongoDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _collection = _context.GetCollection<DTOEmployee>("Employee"); // Ensure the collection name matches your MongoDB setup
        }
        public async Task<IEnumerable<DTOEmployee>> GetAllAsync()
        {
            try
            {
                // Ensure the collection is not null before proceeding
                if (_collection == null)
                {
                    throw new InvalidOperationException("MongoDB collection is not initialized.");
                }
                else
                {
                    return await _collection.Find(_ => true).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error accessing MongoDB collection.", ex);
            }
        }
        public async Task<DTOEmployee> GetByIdAsync(string id)
        {
            try
            {
                // Ensure the collection is not null before proceeding
                if (_collection == null)
                {
                    throw new InvalidOperationException("MongoDB collection is not initialized.");
                }
                else
                {
                    return await _collection.Find(mongo => mongo.Id == id).FirstOrDefaultAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error accessing MongoDB collection.", ex);
            }
        }
        public async Task AddAsync(DTOEmployee mongoDb)
        {
            try
            {
                // Ensure the collection is not null before proceeding
                if (_collection == null)
                {
                    throw new InvalidOperationException("MongoDB collection is not initialized.");
                }
                else
                {
                    await _collection.InsertOneAsync(mongoDb);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error accessing MongoDB collection.", ex);
            }
        }
        public async Task UpdateAsync(DTOEmployee mongoDb)
        {
            try
            {
                // Ensure the collection is not null before proceeding
                if (_collection == null)
                {
                    throw new InvalidOperationException("MongoDB collection is not initialized.");
                }
                else
                {
                    await _collection.ReplaceOneAsync(mongo => mongo.Id == mongoDb.Id, mongoDb);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error accessing MongoDB collection.", ex);
            }

        }
        public async Task DeleteAsync(string id)
        {
            try
            {
                // Ensure the collection is not null before proceeding
                if (_collection == null)
                {
                    throw new InvalidOperationException("MongoDB collection is not initialized.");
                }
                else
                {
                    await _collection.DeleteOneAsync(mongo => mongo.Id == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error accessing MongoDB collection.", ex);
            }
        }

    }
}
