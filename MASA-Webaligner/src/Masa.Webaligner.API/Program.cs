using System.IO.Compression;
using Masa.Webaligner.API.Middlewares;
using Masa.Webaligner.Application;
using Masa.Webaligner.Infrastructure;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Environment.IsDevelopment());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocument();

builder.Services.Configure<BrotliCompressionProviderOptions>(
    x => x.Level = CompressionLevel.SmallestSize
);
builder.Services.Configure<GzipCompressionProviderOptions>(
    x => x.Level = CompressionLevel.SmallestSize
);
builder.Services.AddResponseCompression(
    x =>
    {
        x.Providers.Add<BrotliCompressionProvider>();
        x.Providers.Add<GzipCompressionProvider>();
        x.EnableForHttps = true;
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi3();
}

app.UseExceptionHandler(
    new ExceptionHandlerOptions
    {
        ExceptionHandler = new ExceptionsMiddleware(builder.Environment).Invoke,
    }
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseResponseCompression();

app.MapControllers();

app.Run();
