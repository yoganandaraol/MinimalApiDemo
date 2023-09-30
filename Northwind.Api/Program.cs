using Carter;
using Northwind.Api.Endpoints;
using Northwind.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCarter();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IToDoService, ToDoService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
        builder =>
        {
            builder.WithOrigins("*")
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Map minimal apis
// app.MapToDoEndpoints(); 
    // Downside of this approach is to add as many endpoints that we created, we need to configure explicitly
    // Insetead we can use Carter package 
    // eg. builder.Services.AddCarter();
    // If we add AddCarter to the services, its no more needed to add each endpoints

app.MapCarter();

app.Run();
