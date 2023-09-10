using FluentValidation;
using Product.Repository.Interfaces;
using Generate = Product.Model.Generate;
namespace Product.Service.Validation;
public class ProductValidator : AbstractValidator<Generate.Product>
{
    private readonly IRepositoryWrapper _wrapper;
    public ProductValidator(IRepositoryWrapper wrapper)
    {
        _wrapper = wrapper;
        RuleFor(x => x).CustomAsync(HandleAsync);
    }
    private async Task HandleAsync(Generate.Product model, ValidationContext<Generate.Product> context, CancellationToken token)
    {
        return;
    }
}
