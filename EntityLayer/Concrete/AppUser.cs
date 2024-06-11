using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AppUser:IdentityUser<int>
    {
        //identityuser sınıfında harici olarak eklemek istediklerimiz:
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }

        //Reservation ilişkisi:
        public List<Reservation> Reservations  { get; set; }

        //Comment ilişkisi
        public List<Comment> Comments { get; set; }

    }
}
