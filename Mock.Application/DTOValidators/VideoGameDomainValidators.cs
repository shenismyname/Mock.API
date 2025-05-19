using FluentValidation;
using Mock.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Application.DTOValidators
{
    public class CreateVideoGameDtoValidator : AbstractValidator<CreateVideoGameDto>
    {
        public CreateVideoGameDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty();
            RuleFor(x => x.Platform)
                .NotEmpty();
            RuleFor(x => x.PublisherId)
                .NotEmpty();
            RuleFor(x => x.GenreList)
                .NotEmpty();
        }
    }
}
