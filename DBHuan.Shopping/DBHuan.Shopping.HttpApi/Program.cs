using Autofac;
using Autofac.Extensions.DependencyInjection;
using DBHuan.Shopping.Application;
using DBHuan.Shopping.Application.Contracts;
using DBHuan.Shopping.HttpApi;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Text.Json;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

Log.Logger.Information("App running");
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new DBHuanShoppingModule()));

// thông số cấu hình của jwt
builder.Services.Configure<JwtOption>(builder.Configuration.GetSection("Jwt"));

// disable validate mặc định của .net core
builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

// serilog
builder.Host.UseSerilog((context, config) =>
    config.ReadFrom.Configuration(context.Configuration));

builder.Services.AddAutoMapper(typeof(DBHuanShoppingAutoMapperProfile).Assembly);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});
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

app.UseMiddleware<DBHuanShoppingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();