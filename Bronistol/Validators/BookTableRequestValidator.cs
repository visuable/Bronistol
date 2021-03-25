using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Bronistol.Commands;
using Bronistol.Constants;
using Bronistol.Database.EntitiesDto;
using Bronistol.Database.Enumerations;
using Bronistol.Options;
using FluentValidation;
using Microsoft.Extensions.Options;

namespace Bronistol.Validators
{
    public class BookTableRequestValidator : AbstractValidator<BookTableRequest>
    {
        private IOptions<ValidationOptions> _validationOptions;
        public BookTableRequestValidator(IOptions<ValidationOptions> validationOptions)
        {
            _validationOptions = validationOptions;
            var defaultMessage = _validationOptions.Value.DefaultMessage;

            RuleFor(x => x.Table.Name)
                .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage(defaultMessage);
            RuleFor(x => x.Table.Reason)
                .Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage(defaultMessage);
            RuleFor(x => x.Table.Priority)
                .Must(x => Enum.GetNames(typeof(Priority)).Contains(x)).WithMessage(defaultMessage);
            RuleFor(x => x.Table.SubmitDate)
                .Must(x => DateTime.TryParseExact(x, AutoMapperConstants.DateTimeFormat, CultureInfo.InvariantCulture,
                    DateTimeStyles.AllowWhiteSpaces, out _));
            RuleFor(x => x.Table.AssignedDate)
                .Must(x => DateTime.TryParseExact(x, AutoMapperConstants.DateTimeFormat, CultureInfo.InvariantCulture,
                    DateTimeStyles.AllowWhiteSpaces, out _));
        }
    }
}
