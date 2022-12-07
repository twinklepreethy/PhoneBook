using Microsoft.EntityFrameworkCore;
using PhoneBookAPI;
using PhoneBookAPI.Context;
using PhoneBookAPI.Repository;
using PhoneBookAPI.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();

builder.Services.AddControllers();

builder.Services.AddSingleton<IBaseRepository<Contact>, BaseRepository<Contact>>();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddSingleton<DataContext>();
builder.Services.AddSingleton<IGetAllContactsService, GetAllContactsService>();
builder.Services.AddSingleton<IGetContactService, GetContactService>();
builder.Services.AddSingleton<IAddContactService, AddContactService>();
builder.Services.AddSingleton<IUpdateContactService, UpdateContactService>();
builder.Services.AddSingleton<IDeleteContactService, DeleteContactService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(builder => builder
     .AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader());
app.MapControllers();

app.Run();
