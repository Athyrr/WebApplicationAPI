using Business;
using Business.Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Repositories;
using Repositories.Contracts;
using System.Reflection;
using System.Text.Json.Serialization;
using WebApplicationAPI.DTO.FieldDTO;
using WebApplicationAPI.DTO.FlowerDTO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddDbContext<GardenContext>(ob
//    => ob.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=FlowerAPI;Integrated Security=SSPI; TrustServerCertificate=True;"));

builder.Services.AddDbContext<GardenContext>(ob
    => ob.UseSqlServer(connectionString: @"Data Source=(localdb)\MSSQLLOCALDB;Initial Catalog=FlowerAPI;Integrated Security=True"));

builder.Services.AddTransient<IFlowerRepository, FlowerRepository>();
builder.Services.AddTransient<IFlowerBusiness, FlowerBusiness>();
builder.Services.AddTransient<IFieldRepository, FieldRepository>();
builder.Services.AddTransient<IFieldBusiness, FieldBusiness>();

builder.Services.AddAutoMapper(config =>
 {
     config.CreateMap<Flower, FlowerDTO>();
     config.CreateMap<FlowerDTO, Flower>();

     config.CreateMap<Flower, FlowerToChangeDTO>();
     config.CreateMap<FlowerToChangeDTO, Flower>();

     config.CreateMap<Flower, FlowerByIdDTO>();
     config.CreateMap<FlowerByIdDTO, Flower>();

     config.CreateMap<Field, FieldDTO>();
     config.CreateMap<FieldDTO, Field>();

     config.CreateMap<Field, FieldByIdDTO>();
     config.CreateMap<FieldByIdDTO, Field>();

     config.CreateMap<Field, FieldToAddDTO>();
     config.CreateMap<FieldToAddDTO, Field>();
 });


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddJsonOptions(x =>
x.JsonSerializerOptions.ReferenceHandler =
ReferenceHandler.IgnoreCycles);


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
