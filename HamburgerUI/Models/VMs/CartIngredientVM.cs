using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Drawing;

namespace HamburgerUI.Models.VMs
{
    public class CartIngredientVM
    {
        public List<CartItem> CartItems { get; set; }

        public Product Product { get; set; }

        public List<Ingredient> Ingredients { get; set; }


        public List<ProductDetailsDTO> ProductDetailsDTOs { get; set; }
        public List<SelectListItem> Beverage { get; set; }
        public string BeverageString { get; set; }

        //public List<int> removedIngredients { get; set; }
    }
}
