using Microsoft.AspNetCore.Connections;
using PhoneBook.Context;
using PhoneBook.Models.Entities;
using PhoneBook.Repository;
using PhoneBook.Service;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IRepository<Contact>, Repository<Contact>>();
builder.Services.AddSingleton<IRepository<Contact>, Repository<Contact>>();
builder.Services.AddSingleton<ICreateContactService, CreateContactService>();
builder.Services.AddSingleton<IGetContactService, GetContactService>();
builder.Services.AddSingleton<IGetAllContactsService, GetAllContactsService>();
builder.Services.AddSingleton<IDeleteContactService, DeleteContactService>();
builder.Services.AddSingleton<IUpdateContactService, UpdateContactService>();
builder.Services.AddSingleton<IFilterContactsService, FilterContactsService>();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
