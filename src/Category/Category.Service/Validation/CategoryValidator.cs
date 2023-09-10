using FluentValidation;
using Category.Repository.Interfaces;
using Generate = Category.Model.Generate;
namespace Category.Service.Validation;
public class CategoryValidator : AbstractValidator<Generate.Category>
{
    private readonly IRepositoryWrapper _wrapper;
    public CategoryValidator(IRepositoryWrapper wrapper)
    {
        _wrapper = wrapper;
        RuleFor(x => x).CustomAsync(HandleAsync);
    }
    private async Task HandleAsync(Generate.Category model, ValidationContext<Generate.Category> context, CancellationToken token)
    {
        return;
    }
}
