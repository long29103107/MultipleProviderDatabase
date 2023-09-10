using FluentValidation;
using Customer.Repository.Interfaces;
using Generate = Customer.Model.Generate;
namespace Customer.Service.Validation;
public class CustomerValidator : AbstractValidator<Generate.Customer>
{
    private readonly IRepositoryWrapper _wrapper;
    public CustomerValidator(IRepositoryWrapper wrapper)
    {
        _wrapper = wrapper;
        RuleFor(x => x).CustomAsync(HandleAsync);
    }
    private async Task HandleAsync(Generate.Customer model, ValidationContext<Generate.Customer> context, CancellationToken token)
    {
        return;
    }
}
