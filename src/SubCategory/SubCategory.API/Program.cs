using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SubCategory.Repository;
using SubCategory.Repository.Interfaces;
using SubCategory.Service.Profiles;
using System.Reflection;
using FluentValidation.AspNetCore;
using FluentValidation;
using SubCategory.Service.Validation;
var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RepositoryContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
builder.Services.AddValidatorsFromAssemblyContaining<SubCategoryValidator>();
builder.Services.AddFluentValidationAutoValidation(); 
builder.Services.AddFluentValidationClientsideAdapters();
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterAssemblyTypes(Assembly.Load("SubCategory.Service"))
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
    builder.RegisterAssemblyTypes(Assembly.Load("SubCategory.Repository"))
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
