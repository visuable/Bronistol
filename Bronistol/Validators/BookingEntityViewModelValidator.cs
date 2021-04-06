using System;
using System.Globalization;
using System.Linq;
using Bronistol.Constants;
using Bronistol.Database.Enumerations;
using Bronistol.Models;
using Bronistol.Options.Validations;
using FluentValidation;
using Microsoft.Extensions.Options;

namespace Bronistol.Validators
{
    public class BookingEntityViewModelValidator : AbstractValidator<BookingEntityViewModel>
    {
        private readonly IOptions<ValidationOptions> _validationOptions;

        public BookingEntityViewModelValidator(IOptions<ValidationOptions> validationOptions)
        {
            _validationOptions = validationOptions;
            var defaultMessage = _validationOptions.Value.DefaultMessage;

            RuleFor(x => x.Name)
                .Must(x => !string.IsNullOrWhiteSpace(x.Name)).WithMessage(defaultMessage);
            RuleFor(x => x.Reason)
                .Must(x => !string.IsNullOrWhiteSpace(x.Description)).WithMessage(defaultMessage);
            RuleFor(x => x.Priority)
                .Must(x => Enum.GetNames(typeof(Priority)).Contains(x.Priority)).WithMessage(defaultMessage);
            RuleFor(x => x.SubmitDate)
                .Must(x => DateTime.TryParseExact(x.Date, AutoMapperConstants.DateTimeFormat,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.AllowWhiteSpaces, out _));
            RuleFor(x => x.AssignedDate)
                .Must(x => DateTime.TryParseExact(x.Date, AutoMapperConstants.DateTimeFormat,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.AllowWhiteSpaces, out _));
        }
    }
}