using SOFTW2_Uebungen.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<MovieController>();

builder.Services.AddCors(options =>
{
    // options.AddDefaultPolicy(policy =>
    // {
    //     // var allowedOrigins = builder.Configuration.GetRequiredSection("CORS:AllowedOrigins").GetChildren().Select(s => s.Value!).ToArray();
    //
    //     policy.AllowCredentials();
    //     policy.WithOrigins("http://localhost:5173");
    //     policy.WithHeaders("Accept-Language", "Authorize", "Content-Type");
    //     policy.AllowAnyHeader();
    //     policy.AllowAnyMethod();
    //     policy.WithExposedHeaders("Location");
    // });
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
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
app.UseCors();
app.UseAuthorization();

app.MapControllers();
Console.WriteLine("I AM ALIVE!!!!!");
app.Run();
