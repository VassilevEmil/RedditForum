using Application.DAOInterface;
using Application.Impls;
using Domain.Contracts;
using FileData.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//services login
builder.Services.AddScoped<IUserService, UserServiceImpl>();
builder.Services.AddScoped<IForum, ForumServiceImpl>();
//file 
builder.Services.AddScoped<FileContext>();
builder.Services.AddScoped<IForumDAO, FileDataDAO>();

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