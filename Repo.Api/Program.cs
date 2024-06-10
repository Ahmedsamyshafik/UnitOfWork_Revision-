
using Microsoft.EntityFrameworkCore;
using Repo.Core;
using Repo.Core.Interface;
using Repo.Core.Models;
using Repo.EF;
using Repo.EF.Repo;

namespace Repo.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //my service
            builder.Services.AddDbContext<AppDBContext>(opt =>
            opt.UseSqlServer(
                builder.Configuration.GetConnectionString("DefualtConnection")
                ));
            //builder.Services.AddTransient(typeof(IBaseRepo<>), typeof(BaseRepo<>));
            builder.Services.AddTransient<IUnitOfWork,UnitOfWork>();
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
