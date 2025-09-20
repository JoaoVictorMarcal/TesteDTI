using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using testeDTI.Data;

var builder = WebApplication.CreateBuilder(args);

//permissao
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5173", 
                                             "http://localhost:5174", 
                                             "http://localhost:3000") 
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

var connectionString = builder.Configuration.GetConnectionString("AppDbConnectionsString"); 
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

builder.Services.AddControllers();
var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins);
// ------------------------------------------------

app.UseAuthorization();
app.MapControllers();
app.Run();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connectinString = builder.Configuration.GetConnectionString("AppDbConnectionsString");
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectinString,
ServerVersion.AutoDetect(connectinString)));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
