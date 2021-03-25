using Bronistol.Options.Validations;
using Bronistol.Requests;
using FluentValidation;
using Microsoft.Extensions.Options;

namespace Bronistol.Validators
{
    public class GetReservedTablesCommandValidator : AbstractValidator<GetReservedTablesCommand>
    {
        private readonly IOptions<GetReservedTablesCommandValidatorOptions> _options;

        public GetReservedTablesCommandValidator(IOptions<GetReservedTablesCommandValidatorOptions> options)
        {
            _options = options;
            RuleFor(x => x.Count)
                .LessThanOrEqualTo(_options.Value.MaxCount).GreaterThan(0);
            RuleFor(x => x.Offset)
                .GreaterThanOrEqualTo(0);
        }
    }
}