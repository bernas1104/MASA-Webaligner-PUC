using System.Reflection;
using FluentValidation.AspNetCore;
using Masa.Webaligner.API.Filters;
using Masa.Webaligner.API.Middlewares;
using Masa.Webaligner.Infrastructure.Options;
using Masa.Webaligner.Application;
using Masa.Webaligner.Infrastructure;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<InfrastructureOptions>(
    builder.Configuration.GetSection("InfrastructureOptions")
);

var infrastructureOptions = new InfrastructureOptions();
builder.Configuration.Bind("InfrastructureOptions", infrastructureOptions);

builder.Services
    .AddApplication()
    .AddInfrastructure(
        builder.Configuration.GetConnectionString("MasaDatabase"),
        infrastructureOptions,
        builder.Environment.IsDevelopment()
    );

builder.Services.Configure<ApiBehaviorOptions>(opt => {
    opt.SuppressModelStateInvalidFilter = true;
});

builder.Services
    .AddControllers(opt => {
        opt.EnableEndpointRouting = false;
        opt.Filters.Add(new ValidationsFilter());
    })
    .AddFluentValidation(opt => {
        opt.RegisterValidatorsFromAssembly(
            Assembly.GetAssembly(typeof(ApplicationModule))
        );
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocument(opt => {
    opt.PostProcess = document => {
        document.Info.Title = "MASA-Webaligner";
        document.Info.Description = "Web API para a plataforma MASA-Webaligner de alinhamento" +
            "de sequencias genéticas";
        document.Info.Version = "2.0.0";
        document.Info.TermsOfService = "None";
        document.Schemes = new List<NSwag.OpenApiSchema>
        {
            NSwag.OpenApiSchema.Https,
        };
        document.Info.Contact = new NSwag.OpenApiContact
        {
            Name = "Bernardo Costa Nascimento",
            Email = "bernardoc1104@gmail.com",
            Url = "https://github.com/bernas1104/"
        };
        document.Info.License = new NSwag.OpenApiLicense
        {
            Name = "Use under GPL-3.0 license",
            Url = "https://www.gnu.org/licenses/gpl-3.0.html"
        };
    };
});

builder.Services.AddResponseCompression();

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
