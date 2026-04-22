using LibraryManagementAPI.Data;
using Microsoft.EntityFrameworkCore;
using LibraryManagementAPI.Repositories;
using LibraryManagementAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// SERVICE REGISTRATION
builder.Services.AddControllers();

builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IAuthorService, AuthorService>();

var app = builder.Build();

// LOGGER
var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation(" Environment: {EnvironmentName}", app.Environment.EnvironmentName);
logger.LogInformation(" App Name: {AppName}", app.Environment.ApplicationName);


// MIDDLEWARE
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Library Management API V1");
        options.RoutePrefix = "swagger";
    });
}
else if(app.Environment.IsProduction())
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
