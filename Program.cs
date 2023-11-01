using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
//using ProductsAPI.Models;
//using ProductsAPI.Data;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using RebarProject.Data;
using RebarProject.Models;
using RebarProject.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<OrderStoreDatabaseSetting>(
builder.Configuration.GetSection(nameof(OrderStoreDatabaseSetting)));
builder.Services.AddSingleton<OrderStoreDatabaseSetting>(sp => sp.GetRequiredService<IOptions<OrderStoreDatabaseSetting>>().Value);
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("OrderStoreDatabaseSetting:ConnectionString")));
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddControllers();  


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




//// Register services here
//builder.Services.Configure<MongoDBSetting>(builder.Configuration.GetSection(nameof(MongoDBSettings)));

//builder.Services.AddSingleton<MongoDBContext>(serviceProvider =>
//{
//    var settings = serviceProvider.GetRequiredService<IOptions<MongoDBSettings>>().Value;
//    return new MongoDBContext(settings.ConnectionString, settings.DatabaseName);
//});

//// Add controllers
//builder.Services.AddControllers();




var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();

