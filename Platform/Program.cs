using Microsoft.EntityFrameworkCore;
using Platform.Data;
using Platform.HttpCommand;
using Platform.Repository;

var builder = WebApplication.CreateBuilder(args);
var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.AllowAnyOrigin()//.WithOrigins("http://localhost:4203")
                          .AllowAnyHeader().AllowAnyMethod();
                      });
});

// Add services to the container.
builder.Services.AddScoped<IPlatformRepository, PlatformRepository>();
builder.Services.AddScoped<IClientCommand, ClientCommand>();
builder.Services.AddTransient<DataSeeder>();
builder.Services.AddHttpClient();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration["ConnectionStrings:PlatformService"];
var api = builder.Configuration.GetSection("CommandServiceApi").Value;
Console.WriteLine("------> Api Endpoint {0}", api);

builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(connectionString));

var app = builder.Build();
app.SeedData();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(e =>
    {
        e.SwaggerEndpoint("/swagger/v1/swagger.json", "Platform service");
        e.RoutePrefix = string.Empty;
    });
}

// app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();
