using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using WebApplicationAPI.DTO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<GardenContext>(ob
    => ob.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=FlowerAPI;Integrated Security=SSPI; TrustServerCertificate=True;"));

builder.Services.AddTransient<IFlowerRepository, FlowerRepository>();

builder.Services.AddAutoMapper(config =>
 {
     config.CreateMap<Flower, FlowerDTO>();
     config.CreateMap<FlowerDTO, Flower>();
 });

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
