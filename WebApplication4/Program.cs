var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI(x =>
{

    // For Debug in Kestrel
    x.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API V1");

#if DEBUG
    x.RoutePrefix = "swagger"; // For localhost
#else
    x.RoutePrefix = string.Empty; //  For azure
#endif
}
);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
