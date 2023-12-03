using Entities.DTOs;
using FluentValidation;

namespace BusinessLayer.Validation
{
    public class BeverageAddValidator : AbstractValidator<BeverageAddDTO>
    {
        public BeverageAddValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2).WithMessage("2 harften fazla olmalı");
            RuleFor(P => P.Price).NotEmpty();
            RuleFor(P => P.Price).GreaterThan(15);
            RuleFor(p => p.ProductName).Must(ContainsMenu).When(p => p.CategoryId == 1);
            RuleFor(p => p.ProductName).Must(ContainsHamburger).When(p => p.CategoryId == 2);
            RuleFor(p => p.ImagePath).Must(ContainsImage).WithMessage("2 jpp türünde olmalı fazla olmalı");
            //RuleFor(p=>p.)
        }
        private bool ContainsMenu(string menuName)
        {
            return menuName.Contains("Menü");
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
