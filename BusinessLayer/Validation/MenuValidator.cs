using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation
{
    public class MenuValidator : AbstractValidator<MenuAddDTO>
    {
        public MenuValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2).WithMessage("2 harften fazla olmalı");
            RuleFor(P => P.Price).NotEmpty();
            RuleFor(P => P.Price).GreaterThan(15);
            RuleFor(p => p.ProductName).Must(ContainsMenu);
           
            RuleFor(p => p.ImagePath).Must(ContainsImage).WithMessage("2 jpp türünde olmalı fazla olmalı");
            //RuleFor(p=>p.)
        }
        private bool ContainsMenu(string menuName)
        {
            return menuName.Contains("Menü");
        }
        
        private bool ContainsImage(string hamburgerName)
        {
            return hamburgerName.Contains(".jpg");
        }
    }
}
