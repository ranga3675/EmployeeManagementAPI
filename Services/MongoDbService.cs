using MongoDbAPI.DTO;
using MongoDbAPI.Interfaces;
using MongoDbAPI.Models;
using MongoDbAPI.Repositories;

namespace MongoDbAPI.Services
{
    public class MongoDbService:IService<Employee>
    {
        private readonly IRepository<DTOEmployee> _mongoDbRepository;
        public MongoDbService(IRepository<DTOEmployee> mongoDbRepository)
        {
            _mongoDbRepository = mongoDbRepository ?? throw new ArgumentNullException(nameof(mongoDbRepository));
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            try
            {
                // Ensure the repository is not null before proceeding
                if (_mongoDbRepository == null)
                {
                    throw new InvalidOperationException("MongoDbRepository is not initialized.");
                }
                else
                {
                    var dtoMongoDbs = await _mongoDbRepository.GetAllAsync();
                    return dtoMongoDbs.Select(dto => new Employee
                    {
                        Id = dto.Id,
                        FirstName = dto.FirstName,
                        LastName = dto.LastName,
                        PersonalPhone = dto.PersonalPhone,
                        WorkPhone = dto.WorkPhone,
                        PersonalEmail = dto.PersonalEmail,
                        WorkEmail = dto.WorkEmail,
                        IsFullTime = dto.IsFullTime,
                        HoursPerWeek = dto.HoursPerWeek,
                        Title = dto.Title,
                        Department = dto.Department,
                        CreatedAt = dto.CreatedAt,
                        UpdatedAt = dto.UpdatedAt

                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error accessing MongoDB repository.", ex);
            }
        }
        public async Task<Employee> GetByIdAsync(string id)
        {
            try
            {
                // Ensure the repository is not null before proceeding
                if (_mongoDbRepository == null)
                {
                    throw new InvalidOperationException("MongoDbRepository is not initialized.");
                }
                else
                {
                    var dtoMongoDb = await _mongoDbRepository.GetByIdAsync(id);
                    return new Employee
                    {
                        Id = dtoMongoDb.Id,
                        FirstName = dtoMongoDb.FirstName,
                        LastName = dtoMongoDb.LastName,
                        PersonalPhone = dtoMongoDb.PersonalPhone,
                        WorkPhone = dtoMongoDb.WorkPhone,
                        PersonalEmail = dtoMongoDb.PersonalEmail,
                        WorkEmail = dtoMongoDb.WorkEmail,
                        IsFullTime = dtoMongoDb.IsFullTime,
                        HoursPerWeek = dtoMongoDb.HoursPerWeek,
                        Title = dtoMongoDb.Title,
                        Department = dtoMongoDb.Department,
                        CreatedAt = dtoMongoDb.CreatedAt,
                        UpdatedAt = dtoMongoDb.UpdatedAt
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error accessing MongoDB repository.", ex);
            }
        }

        public async Task AddAsync(Employee mongoDb)
        {
            try
            {
                // Ensure the repository is not null before proceeding
                if (_mongoDbRepository == null)
                {
                    throw new InvalidOperationException("MongoDbRepository is not initialized.");
                }
                else
                {
                    var dtoMongoDb = new DTOEmployee
                    {
                        FirstName = mongoDb.FirstName,
                        LastName = mongoDb.LastName,
                        PersonalPhone = mongoDb.PersonalPhone,
                        WorkPhone = mongoDb.WorkPhone,
                        PersonalEmail = mongoDb.PersonalEmail,
                        WorkEmail = mongoDb.WorkEmail,
                        IsFullTime = mongoDb.IsFullTime,
                        HoursPerWeek = mongoDb.HoursPerWeek,
                        Title = mongoDb.Title,
                        Department = mongoDb.Department,
                        CreatedAt = mongoDb.CreatedAt,
                        UpdatedAt = mongoDb.UpdatedAt
                    };
                    await _mongoDbRepository.AddAsync(dtoMongoDb);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error accessing MongoDB repository.", ex);
            }
            // Map MongoDb to DTOMongoDb before passing it to the repository
        }

        public async Task UpdateAsync(Employee mongoDb)
        {
            try
            {
                // Ensure the repository is not null before proceeding
                if (_mongoDbRepository == null)
                {
                    throw new InvalidOperationException("MongoDbRepository is not initialized.");
                }
                else
                {
                    // Map MongoDb to DTOMongoDb before passing it to the repository
                    var dtoMongoDb = new DTOEmployee
                    {
                        Id = mongoDb.Id,
                        FirstName = mongoDb.FirstName,
                        LastName = mongoDb.LastName,
                        PersonalPhone = mongoDb.PersonalPhone,
                        WorkPhone = mongoDb.WorkPhone,
                        PersonalEmail = mongoDb.PersonalEmail,
                        WorkEmail = mongoDb.WorkEmail,
                        IsFullTime = mongoDb.IsFullTime,
                        HoursPerWeek = mongoDb.HoursPerWeek,
                        Title = mongoDb.Title,
                        Department = mongoDb.Department,
                        CreatedAt = mongoDb.CreatedAt,
                        UpdatedAt = mongoDb.UpdatedAt
                    };
                    await _mongoDbRepository.UpdateAsync(dtoMongoDb);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error accessing MongoDB repository.", ex);
            }

        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                // Ensure the repository is not null before proceeding
                if (_mongoDbRepository == null)
                {
                    throw new InvalidOperationException("MongoDbRepository is not initialized.");
                }
                else
                {
                    await _mongoDbRepository.DeleteAsync(id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error accessing MongoDB repository.", ex);
            }

        }
    }
}
