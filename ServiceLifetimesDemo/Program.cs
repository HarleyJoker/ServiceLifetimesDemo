using ServiceLifetimesDemo.Services.Implementations;
using ServiceLifetimesDemo.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// register services to the DI container.
builder.Services.AddTransient<ITransientService, TransientService>();
builder.Services.AddScoped<IScopedService, ScopedService>();
builder.Services.AddSingleton<ISingletonService, SingletonService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//minimal APi approach
app.MapGet("/", (ITransientService transientService, IScopedService scopedService, ISingletonService singletonService) =>
{
    return Results.Ok(new
    {
        Transient = transientService.GetOperationId(),
        Scoped = scopedService.GetOperationId(),
        Singleton = singletonService.GetOperationId()
    });
});

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
