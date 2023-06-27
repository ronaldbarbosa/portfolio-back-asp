using Microsoft.EntityFrameworkCore;
using portfolio_back.Models;
using portfolio_back.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

// DB Connection
builder.Services.AddDbContext<ProjectContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("LocalConnection")));

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .WithOrigins("http://localhost:3000/")
    .AllowCredentials());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
