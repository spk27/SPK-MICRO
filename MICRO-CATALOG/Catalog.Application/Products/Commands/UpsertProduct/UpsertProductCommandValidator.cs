using FluentValidation;
using Spk.Catalog.Domain.Rules;

namespace Spk.Catalog.Application.Products.Commands.UpsertProduct
{
    public class UpsertProductCommandValidator : AbstractValidator<UpsertProductCommand>
    {
        public UpsertProductCommandValidator()
        {
            
            RuleFor(x => x.Name)
                .MaximumLength(ProductRules.MaxLengthProductName).WithMessage(ProductRules.MaxLengthNameValidation)
                .NotEmpty().WithMessage(ProductRules.NotEmptyNameValidation);
            RuleFor(x => x.Price)
                .GreaterThan(ProductRules.MinPriceValue).WithMessage(ProductRules.MinPriceValueValidation)
                .LessThan(ProductRules.MaxPriceValue).WithMessage(ProductRules.MaxPriceValueValidation);
        }
    }
}
