using FluentValidation;
using Gatherly.Application.Behaviors;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .Scan(
        selector => selector
            .FromAssemblies(
                Gatherly.Infrastructure.AssemblyReference.Assembly,
                Gatherly.Persistence.AssemblyReference.Assembly)
            .AddClasses(false)
            .AsImplementedInterfaces()
            .WithScopedLifetime());

builder.Services.AddMediatR(Gatherly.Application.AssemblyReference.Assembly);

builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

builder.Services.AddValidatorsFromAssembly(Gatherly.Application.AssemblyReference.Assembly,
    includeInternalTypes: true);

builder
    .Services
    .AddControllers()
    .AddApplicationPart(Gatherly.Presentation.AssemblyReference.Assembly);

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();