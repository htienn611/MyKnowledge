using Microsoft.EntityFrameworkCore;
using WebApi.data;
using WebApi.repository;
using WebApi.helper;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var secretKey = Environment.GetEnvironmentVariable("JWT_SECRET");
if (string.IsNullOrEmpty(secretKey))
{
    throw new Exception("JWT Secret Key is missing in environment variables.");
}

// Sử dụng secretKey trong JWT configuration

var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")
                      ?? builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<WebApiDbContext>(options => options.UseSqlServer(connectionString));

builder.Logging.ClearProviders();            // Xóa bỏ các provider mặc định (Console, Debug,...)
builder.Logging.AddConsole();                // Thêm provider Console để hiện log trong terminal
builder.Logging.AddDebug();                  // Thêm provider Debug để hiện log trong Debug Window (VS)
builder.Logging.SetMinimumLevel(LogLevel.Information); // Chỉ log từ mức Information trở lên

// 2. Đăng ký dịch vụ LoggerHelper
builder.Services.AddSingleton(typeof(LoggerHelper<>));
builder.Services.AddSingleton(new JWTHelper(secretKey));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

builder.Services.AddControllers();
builder.Services.AddScoped<IMajorRepository, MajorRepository>();
builder.Services.AddScoped<ISpecializationRepository, SpecializationRepository>();
builder.Services.AddScoped<ITopicRepository, TopicRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITopicRepository, TopicRepository>();

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowAllOrigins"); // Sử dụng policy CORS đã định nghĩa

app.UseHttpsRedirection();
//app.UseAuthorization();
app.MapControllers();

// Enable Swagger middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();

