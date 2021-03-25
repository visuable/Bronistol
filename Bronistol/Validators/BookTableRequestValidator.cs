using System;
using System.Globalization;
using System.Linq;
using Bronistol.Commands;
using Bronistol.Constants;
using Bronistol.Database.Enumerations;
using Bronistol.Options.Validations;
using FluentValidation;
using Microsoft.Extensions.Options;

namespace Bronistol.Validators
{
    public class BookTableRequestValidator : AbstractValidator<BookTableRequest>
    {
        private readonly IOptions<ValidationOptions> _validationOptions;

        public BookTableRequestValidator(IOptions<ValidationOptions> validationOptions)
        {
            _validationOptions = validationOptions;
            var defaultMessage = _validationOptions.Value.DefaultMessage;

            RuleFor(x => x.Table.Name)
                .Must(x => !string.IsNullOrWhiteSpace(x.Name)).WithMessage(defaultMessage);
            RuleFor(x => x.Table.Reason)
                .Must(x => !string.IsNullOrWhiteSpace(x.Description)).WithMessage(defaultMessage);
            RuleFor(x => x.Table.Priority)
                .Must(x => Enum.GetNames(typeof(Priority)).Contains(x.Priority)).WithMessage(defaultMessage);
            RuleFor(x => x.Table.SubmitDate)
                .Must(x => DateTime.TryParseExact(x.Date, AutoMapperConstants.DateTimeFormat, CultureInfo.InvariantCulture,
                    DateTimeStyles.AllowWhiteSpaces, out _));
            RuleFor(x => x.Table.AssignedDate)
                .Must(x => DateTime.TryParseExact(x.Date, AutoMapperConstants.DateTimeFormat, CultureInfo.InvariantCulture,
                    DateTimeStyles.AllowWhiteSpaces, out _));
        }
    }
}