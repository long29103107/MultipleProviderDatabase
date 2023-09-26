using FluentValidation;
using Basket.Repository.Interfaces;
using Generate = Basket.Model.Generate;
namespace Basket.Service.Validation;
public class BasketValidator : AbstractValidator<Generate.Basket>
{
    private readonly IRepositoryWrapper _wrapper;
    public BasketValidator(IRepositoryWrapper wrapper)
    {
        _wrapper = wrapper;
        RuleFor(x => x).CustomAsync(HandleAsync);
    }
    private async Task HandleAsync(Generate.Basket model, ValidationContext<Generate.Basket> context, CancellationToken token)
    {
        return;
    }
}
