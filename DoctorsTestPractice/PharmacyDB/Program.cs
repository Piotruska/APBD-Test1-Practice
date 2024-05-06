using PharmacyDB.Repositories;
using PharmacyDB.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ImyService,MyService>();
builder.Services.AddScoped<ImyRepository,MyRepository>();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();                 //Forgot to add this  - 404 error
app.Run();

