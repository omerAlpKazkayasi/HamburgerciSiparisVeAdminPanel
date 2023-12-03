using Core.Entities.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class User : IdentityUser, IEntity
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }
        public string? Name { get; set; }
        public string? Surname { get; set; }
       

        //public int CartId { get; set; }
        public Cart Cart { get; set; }
        public ICollection<Order> Orders { get; set; }
    }


}
