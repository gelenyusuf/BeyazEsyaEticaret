using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Entities
{
    public class AppUserProfile:BaseEntity
    {
        public string FirtName { get; set; }
        public string LastName { get; set; }

        //Relational Properties 

        public virtual AppUser AppUser { get; set; }
    }
}
