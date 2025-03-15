using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using Product_Management.MongoContext;
using Product_Management.Repositories.Conteracts.Common;
using Product_Management.Repositories.Conteracts.Product;
using Product_Management.Repositories.Services.Common;
using Product_Management.Repositories.Services.Product;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Product Management API",
        Version = "v1"
    });
});


#region MongoDB Context Configuration

builder.Services.AddSingleton<IMongoDBContext, MongoDBContext>();

#endregion

#region Registeration Services

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductService, ProductService>();

#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product Management API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();
