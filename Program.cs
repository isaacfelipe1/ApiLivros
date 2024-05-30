using ApiLivros.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<ApiLivrosBbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    
    app.UseDeveloperExceptionPage();
    
}else{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<ApiLivrosBbContext>();
context.Database.Migrate();

app.UseAuthorization();

app.MapControllers();

app.Run();
