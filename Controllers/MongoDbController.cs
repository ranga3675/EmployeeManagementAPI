using Microsoft.AspNetCore.Mvc;
using MongoDbAPI.Interfaces;
using MongoDbAPI.Models;
using MongoDbAPI.Repositories;
using MongoDbAPI.Services;

namespace MongoDbAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MongoDbController : ControllerBase
    {
        private readonly IService<Employee> _mongoDbService;
        public MongoDbController(IService<Employee> mongoDbService)
        {
            _mongoDbService = mongoDbService ?? throw new ArgumentNullException(nameof(mongoDbService));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetMongoDbs()
        {
            try
            {                 // Ensure the service is not null before proceeding
                if (_mongoDbService == null)
                {
                    throw new InvalidOperationException("MongoDbService is not initialized.");
                }
                else
                {
                    var mongoDbs = await _mongoDbService.GetAllAsync();
                    return Ok(mongoDbs);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetMongoDb(string id)
        {
            try
            {
                // Ensure the service is not null before proceeding
                if (_mongoDbService == null)
                {
                    throw new InvalidOperationException("MongoDbService is not initialized.");
                }
                else
                {
                    var mongoDb = await _mongoDbService.GetByIdAsync(id);
                    if (mongoDb == null)
                    {
                        return NotFound();
                    }
                    return Ok(mongoDb);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<ActionResult> AddMongoDb([FromBody] Employee mongoDb)
        {
            try
            { // Ensure the service is not null before proceeding
                if (_mongoDbService == null)
                {
                    throw new InvalidOperationException("MongoDbService is not initialized.");
                }
                else
                {
                    await _mongoDbService.AddAsync(mongoDb);
                    //return CreatedAtAction(nameof(GetMongoDb), new { id = mongoDb.Id }, mongoDb);
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMongoDb(string id, [FromBody] Employee mongoDb)
        {
            try
            {
                // Ensure the service is not null before proceeding
                if (_mongoDbService == null)
                {
                    throw new InvalidOperationException("MongoDbService is not initialized.");
                }
                else
                {
                    var existingMongoDb = await _mongoDbService.GetByIdAsync(id);
                    if (existingMongoDb == null)
                    {
                        return NotFound();
                    }
                    await _mongoDbService.UpdateAsync(mongoDb);
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMongoDb(string id)
        {
            try
            { // Ensure the service is not null before proceeding
                if (_mongoDbService == null)
                {
                    throw new InvalidOperationException("MongoDbService is not initialized.");
                }
                else
                {
                    var existingMongoDb = await _mongoDbService.GetByIdAsync(id);
                    if (existingMongoDb == null)
                    {
                        return NotFound();
                    }
                    await _mongoDbService.DeleteAsync(id);
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }


    }
}
