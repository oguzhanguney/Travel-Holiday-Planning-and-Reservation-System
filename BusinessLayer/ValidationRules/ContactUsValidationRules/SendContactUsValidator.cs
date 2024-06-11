using DTOLayer.DTOs.ContactDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.ContactUsValidationRules
{
    public class SendContactUsValidator:AbstractValidator<SendMessageDto>
    {
        public SendContactUsValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez!");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail alanı boş geçilemez!");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu alanı boş geçilemez!");
            RuleFor(x => x.MessageBody).NotEmpty().WithMessage("Mesaj alanı boş geçilemez!");
            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("Konu alanına en az 5 karakter veri girişi yapınız!");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Konu alanına en az 100 karakter veri girişi yapınız!");
            RuleFor(x => x.Mail).MinimumLength(10).WithMessage("Konu alanına en az 10 karakter veri girişi yapınız!");
            RuleFor(x => x.Mail).MaximumLength(100).WithMessage("Konu alanına en az 100 karakter veri girişi yapınız!");
        }
    }
}
