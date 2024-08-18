using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StudyCardsApi;
using StudyCardsApi.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddTransient<CardService>();
var con = builder.Configuration.GetConnectionString("DefaultConnection");
var getPassword = Environment.GetEnvironmentVariable("MYSQL_PASSWORD");
if (getPassword is not null)
{
    con += "Password=" + getPassword + ";";
}
var serverVersion = new MySqlServerVersion(new Version(10, 11, 6));
builder.Services.AddDbContext<AppDbContext>(options => options
    .UseMySql(con, serverVersion), ServiceLifetime.Transient);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
    policy =>
    {
        
    policy.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

