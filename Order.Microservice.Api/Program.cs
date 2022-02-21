using MediatR;
using Order.Microservice.Domain.Entities.Common;
using Order.Microservice.Domain.Interfaces.Infra;
using Order.Microservice.Infra.Contexts;
using Order.Microservice.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<AppDbContext>(x => new AppDbContext(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();

builder.Services.AddMediatR(typeof(Entity));

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();

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
