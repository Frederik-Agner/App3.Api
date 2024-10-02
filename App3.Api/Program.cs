using App3.Api.Data.DB;
using App3.Api.Data.Interface;
using App3.Api.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton(new ConnectionStringData {
    SqlConnectionName = "Default"
});

builder.Services.AddSingleton<DataAccess>();
builder.Services.AddSingleton<IEquipmentRepository, EquipmentRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
