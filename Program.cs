
using Microsoft.Extensions.DependencyInjection;
using MongoDbAPI.Data;
using MongoDbAPI.DTO;
using MongoDbAPI.Interfaces;
using MongoDbAPI.Models;
using MongoDbAPI.Repositories;
using MongoDbAPI.Services;

namespace MongoDbAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyCors", builder =>
                {
                    builder
                    .WithOrigins("https://localhost:7020")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
            builder.Services.AddScoped<MongoDbContext>();
            builder.Services.AddScoped<IRepository<DTOEmployee>, MongoDbRepository>();
            builder.Services.AddScoped<IService<Employee>, MongoDbService>();          
      
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
