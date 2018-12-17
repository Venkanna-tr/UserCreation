using System;
using System.Collections.Generic;

namespace MessWala.Data.Models
{
    public partial class UserTypes
    {
        public UserTypes()
        {
            Roles = new HashSet<Roles>();
            Users = new HashSet<Users>();
        }

        public int UserTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Roles> Roles { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
