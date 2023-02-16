using ApplicationCore.Interfaces;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IIpAddressRepository, IpAddressRepository>();
builder.Services.AddScoped<ISpeedTestRepository, SpeedTestRepository>();
builder.Services.AddDbContext<SpeedTestContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SpeedTestContext")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var MyAllowedSpecificOrigins = "_myAllowedSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowedSpecificOrigins, 
    builder =>
    {
        builder.WithOrigins("http://localhost:5058/api/Ip")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = "";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(MyAllowedSpecificOrigins);

app.MapControllers();

app.Run();
