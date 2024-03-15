using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PlaceMyOrder.Api.Middlewares;
using PlaceMyOrder.Api.Services;
using PlaceMyOrder.Core.Facade;
using PlaceMyOrder.Core.Services;
using PlaceMyOrder.Domain.Interfaces;
using PlaceMyOrder.Infrastructure.Data;
using PlaceMyOrder.Infrastructure.Dto;
using PlaceMyOrder.Infrastructure.Mappings;
using PlaceMyOrder.Infrastructure.Repositories;
using PlaceMyOrder.Infrastructure.Utils;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
// Add serilog
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PlaceMyOrderDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PlaceMyOrderConnectionString")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPasswordEncoder, BCryptPasswordEncoder>();
builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<AuthFacade>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorizationBuilder();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();
