using Microsoft.AspNetCore.Identity;
using Project.ENTITIES.Enums;
using Project.ENTITIES.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Entities
{
    public class AppUser : IdentityUser<int>, IEntity
    {

        public AppUser()
        {
            CreatedDate = DateTime.Now;
            Status = DataStatus.Inserted;
        }
        [NotMapped]
        public new int ID
        {
            get => Id;
            set => Id = value;
        }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }



        //Relational Properties
        public virtual ICollection<AppUserRole> UserRoles { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual AppUserProfile Profile { get; set; }

    }
}
