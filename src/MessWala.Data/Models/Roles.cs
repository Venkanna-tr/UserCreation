using System;
using System.Collections.Generic;

namespace MessWala.Data.Models
{
    public partial class Roles
    {
        public Roles()
        {
            AppRoleMenus = new HashSet<AppRoleMenus>();
            Users = new HashSet<Users>();
        }

        public int RoleId { get; set; }
        public string Name { get; set; }
        public int UserTypeId { get; set; }
        public int StatusTypeId { get; set; }

        public virtual StatusTypes StatusType { get; set; }
        public virtual UserTypes UserType { get; set; }
        public virtual ICollection<AppRoleMenus> AppRoleMenus { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
