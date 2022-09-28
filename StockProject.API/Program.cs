using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StockProject.Bussiness;
using StockProject.Bussiness.Interfaces;
using StockProject.Bussiness.Mappings;
using StockProject.Bussiness.Repos;
using StockProject.Bussiness.Services;
using StockProject.Bussiness.ValidationRules;
using StockProject.DataAccess.Context;
using StockProject.DataAccess.Interfaces;
using StockProject.DataAccess.Repositories;
using StockProject.Dtos.CategoryDtos;
using StockProject.Dtos.OrderDtos;
using StockProject.Dtos.ProductDtos;
using StockProject.Dtos.UserDtos;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt => {
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidIssuer = "http://localhost",
        ValidAudience = "http://localhost",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("halilhalilhalil1.")),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
    };

});

builder.Services.AddDbContext<StockProjectContext>(x => x.UseSqlServer("server=coinodb-dev.cjq6i1xxy6zz.eu-central-1.rds.amazonaws.com; database=StockProjectHalil;Uid=sa;Password=DtzsCI3HF9n4WIX7O3dj6SSdC43PdpwpMtcaXtDlj8TJy3KDSJ"));


builder.Services.AddTransient<IValidator<CategoryCreateDto>, CategoryCreateDtoValidator>();
builder.Services.AddTransient<IValidator<CategoryUpdateDto>, CategoryUpdateDtoVaildator>();
builder.Services.AddTransient<IValidator<OrderCreateDto>, OrderCreateDtoValidator>();
builder.Services.AddTransient<IValidator<OrderUpdateDto>, OrderUpdateDtoValidator>();
builder.Services.AddTransient<IValidator<ProductCreateDto>, ProductCreateDtoValidator>();
builder.Services.AddTransient<IValidator<ProductUpdateDto>, ProductUpdateDtoValidator>();
builder.Services.AddTransient<IValidator<UserCreateDto>, UserCreateDtoValidator>();
builder.Services.AddTransient<IValidator<UserUpdateDto>, UserUpdateDtoValidator>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
//builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
builder.Services.AddScoped<IUsersUserRolesRepository, UsersUserRolesRepository>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUsersUserRolesService, UsersUserRolesService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRoleService, UserRoleService>();
builder.Services.AddScoped<IAuthService, AuthService>();




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

app.UseStaticFiles();

app.UseRouting();


app.UseAuthentication();

app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapControllers();

app.Run();
