using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation
{
    public class ProductDetailsValidator:AbstractValidator<ProductDetailsDTO>
    {
        public ProductDetailsValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2).WithMessage("2 harften fazla olmalı");
            RuleFor(P => P.ProductPrice).NotEmpty();
            RuleFor(P => P.ProductPrice).GreaterThan(15);
            
            RuleFor(p => p.ImagePath).Must(ContainsImage).WithMessage("2 jpp türünde olmalı fazla olmalı");
            //RuleFor(p=>p.)
        }
        
        private bool ContainsImage(string hamburgerName)
        {
            return hamburgerName.Contains(".jpg");
        }
    }
}
