
using Microsoft.EntityFrameworkCore;
using MovieManagement.DataAccess.Context;
using MovieManagement.DataAccess.Implementation;
using MovieManagement.Domain.Repository;
using System.Text.Json.Serialization;

namespace GMovieManagement.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Add connection to Database
            builder.Services.AddDbContext<MovieManagementDbContext>(
                option => option.UseSqlServer(builder.Configuration.GetConnectionString("MovieConnection")));

            //builder.Services.AddDbContext<MovieManagementDbContext>(p =>
            //{
            //    p.UseSqlServer(builder.Configuration.GetConnectionString("MovieConnection"));
                
            //});

            // 
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
            builder.Services.AddMvcCore().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            builder.Services.AddControllers();
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
