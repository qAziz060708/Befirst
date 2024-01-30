using Befirst.BusinessLogic.ServiceExtentions;
using Befirst.DataAccess.DbConnection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers().AddNewtonsoftJson(op => op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
var config = builder.Configuration.GetSection("ConnectionStrings");
builder.Services.AddDbContext<BefirstDbContext>(option => option.UseNpgsql(config["Connect"]));
builder.Services.RegisterServices(builder.Configuration);
builder.Services.AddScoped<BefirstDbContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
