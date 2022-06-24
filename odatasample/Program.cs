using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using odatasample;
using odatasample.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CustomerContext>(options => options.UseInMemoryDatabase("orders-db"));

builder.Services.AddControllers()
    .AddOData(options => options.Select().OrderBy().Count().Expand().Filter().SetMaxTop(50));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.OperationFilter<ODataOperationFilter>());

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();