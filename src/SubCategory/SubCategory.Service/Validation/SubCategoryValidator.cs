using FluentValidation;
using SubCategory.Repository.Interfaces;
using Generate = SubCategory.Model.Generate;
namespace SubCategory.Service.Validation;
public class SubCategoryValidator : AbstractValidator<Generate.SubCategory>
{
    private readonly IRepositoryWrapper _wrapper;
    public SubCategoryValidator(IRepositoryWrapper wrapper)
    {
        _wrapper = wrapper;
        RuleFor(x => x).CustomAsync(HandleAsync);
    }
    private async Task HandleAsync(Generate.SubCategory model, ValidationContext<Generate.SubCategory> context, CancellationToken token)
    {
        return;
    }
}
