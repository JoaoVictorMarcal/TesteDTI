using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using testeDTI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connectinString = builder.Configuration.GetConnectionString("AppDbConnectionsString");
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectinString,
ServerVersion.AutoDetect(connectinString)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
