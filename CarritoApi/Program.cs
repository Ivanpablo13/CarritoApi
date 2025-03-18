using CarritoApi.Extensions;

var builder = WebApplication.CreateBuilder(args);
AppConfigurator.ConfigureApp(builder);
// Add services to the container.



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

