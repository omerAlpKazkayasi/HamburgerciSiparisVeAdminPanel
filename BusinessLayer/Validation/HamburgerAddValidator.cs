using Entities.DTOs;
using FluentValidation;

namespace BusinessLayer.Validation
{
    public class HamburgerAddValidator : AbstractValidator<HamburgerAddDTO>
    {
        public HamburgerAddValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2).WithMessage("2 harften fazla olmalı");
            RuleFor(P => P.Price).NotEmpty();
            RuleFor(P => P.Price).GreaterThan(15);
            
            RuleFor(p => p.ProductName).Must(ContainsHamburger);
            RuleFor(p => p.ImagePath).Must(ContainsImage).WithMessage("2 jpp türünde olmalı fazla olmalı");
            //RuleFor(p=>p.)
        }
        
        private bool ContainsHamburger(string hamburgerName)
        {
            return hamburgerName.Contains("hamburger");
        }
        private bool ContainsImage(string hamburgerName)
        {
            return hamburgerName.Contains(".jpg");
        }
    }
}
