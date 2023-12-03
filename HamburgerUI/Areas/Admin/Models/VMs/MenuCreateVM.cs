using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HamburgerUI.Areas.Admin.Models.VMs
{
    public class MenuCreateVM
    {

        public MenuAddDTO Product { get; set; }
        public List<SelectListItem> Ingredients { get; set; }
        public List<SelectListItem> Sizes { get; set; }
        public List<int> SelectedIngredients { get; set; }


    }
}
