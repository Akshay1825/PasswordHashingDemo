
using Microsoft.EntityFrameworkCore;
using PasswordHashingDemo.Data;
using PasswordHashingDemo.Mappers;
using PasswordHashingDemo.Repositories;
using PasswordHashingDemo.Services;

namespace PasswordHashingDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddDbContext<UserContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("connString"));
            });
            builder.Services.AddControllers();
            builder.Services.AddTransient<IRepository, Repository>();
            builder.Services.AddTransient<IService, Service>();
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
