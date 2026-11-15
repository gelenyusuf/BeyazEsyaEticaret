

    using Microsoft.AspNetCore.Identity;
using Project.ENTITIES.Entities;
using Project.ENTITIES.Enums;
using Project.ENTITIES.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

public class AppRole : IdentityRole<int>, IEntity
    {
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

        public virtual ICollection<AppUserRole> UserRoles { get; set; }
    }

