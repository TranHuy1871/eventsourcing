using EventSourcing.Infratructure.Repository;
using EventStore.ClientAPI;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Build();
var services = builder.Services;


//var eventStoreConnection = EventStoreConnection.Create(
//                connectionString: configuration.Configuration.GetValue<string>("EventStore:ConnectionString"),
//                builder: ConnectionSettings.Create().KeepReconnecting(),
//                connectionName: configuration.Configuration.GetValue<string>("EventStore:ConnectionName"));
// Add services to the container.

//services.AddSingleton(eventStoreConnection);
services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddTransient<AggregateRepository>();





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
