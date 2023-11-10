using FluentValidation;
using Brand.Repository.Interfaces;
using Generate = Brand.Model.Generate;
namespace Brand.Service.Validation;
public class BrandValidator : AbstractValidator<Generate.Brand>
{
    private readonly IRepositoryWrapper _wrapper;
    public BrandValidator(IRepositoryWrapper wrapper)
    {
        _wrapper = wrapper;
        RuleFor(x => x).CustomAsync(HandleAsync);
    }
    private async Task HandleAsync(Generate.Brand model, ValidationContext<Generate.Brand> context, CancellationToken token)
    {
        return;
    }
}
