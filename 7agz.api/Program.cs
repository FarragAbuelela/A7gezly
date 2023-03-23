
using _7agz.Core;
using _7agz.Core.Interfaces;
using _7agz.EF;
using _7agz.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Runtime.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//adding connection string
builder.Services.AddDbContext<ApplicationDbContext>(
	options => options.UseSqlServer(
		builder.Configuration.GetConnectionString("DefaultConnection"),
		b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
		));

//builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
//builder.Services.AddSingleton<IUnitOfWork, UnitOfWork>();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
var app = builder.Build();





// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(c=> c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
