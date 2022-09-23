using FluentValidation;
using Microsoft.EntityFrameworkCore;
using StockProject.Bussiness.ValidationRules;
using StockProject.DataAccess.Context;
using StockProject.Dtos.CategoryDtos;
using StockProject.Dtos.OrderDtos;
using StockProject.Dtos.ProductDtos;
using StockProject.Dtos.UserDtos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<StockProjectContext>(x => x.UseSqlServer("server=coinodb-dev.cjq6i1xxy6zz.eu-central-1.rds.amazonaws.com; database=StockProjectHalil;Uid=sa;Password=DtzsCI3HF9n4WIX7O3dj6SSdC43PdpwpMtcaXtDlj8TJy3KDSJ"));

builder.Services.AddTransient<IValidator<CategoryCreateDto>, CategoryCreateDtoValidator>();
builder.Services.AddTransient<IValidator<CategoryUpdateDto>, CategoryUpdateDtoVaildator>();
builder.Services.AddTransient<IValidator<OrderCreateDto>, OrderCreateDtoValidator>();
builder.Services.AddTransient<IValidator<OrderUpdateDto>, OrderUpdateDtoValidator>();
builder.Services.AddTransient<IValidator<ProductCreateDto>, ProductCreateDtoValidator>();
builder.Services.AddTransient<IValidator<ProductUpdateDto>, ProductUpdateDtoValidator>();
builder.Services.AddTransient<IValidator<UserCreateDto>, UserCreateDtoValidator>();
builder.Services.AddTransient<IValidator<UserUpdateDto>, UserUpdateDtoValidator>();




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

app.UseAuthorization();

app.MapControllers();

app.Run();
