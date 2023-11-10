using Autofac;
using Autofac.Extensions.DependencyInjection;
using Brand.Repository;
using Brand.Repository.Interfaces;
using Brand.Service.Profiles;
using System.Reflection;
using FluentValidation.AspNetCore;
using FluentValidation;
using Brand.Service.Validation;
using Shared.Repository.Configuration.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureDbContext<RepositoryContext>(builder.Configuration);
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
builder.Services.AddValidatorsFromAssemblyContaining<BrandValidator>();
builder.Services.AddFluentValidationAutoValidation(); 
builder.Services.AddFluentValidationClientsideAdapters();
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterAssemblyTypes(Assembly.Load("Brand.Service"))
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
    builder.RegisterAssemblyTypes(Assembly.Load("Brand.Repository"))
        .Where(t => t.Name.EndsWith("Repository"))
        .AsImplementedInterfaces()
        .InstancePerLifetimeScope();
    builder.RegisterType<RepositoryWrapper>()
        .As<IRepositoryWrapper>()
        .InstancePerLifetimeScope();
});
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
