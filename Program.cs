using ApiLivros.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<ApiLivrosBbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Livros",
        Version = "v1",
        Description = "API para Livros [CRUD]",
        Contact = new OpenApiContact
        {
            Name = "Isaac Felipe",
            Email = "ifdsl.lic20@uea.edu.br",
            Url = new Uri("https://github.com/isaacfelipe1"),
        }
    });
});

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
