using System;
using System.Collections.Generic;

namespace MessWala.Data.Models
{
    public partial class AppRoleMenus
    {
        public int AppRoleId { get; set; }
        public int RoleId { get; set; }
        public int AppSubMenuId { get; set; }
        public bool Canview { get; set; }
        public bool Canadd { get; set; }
        public bool Canedit { get; set; }
        public bool Candelete { get; set; }
        public bool Isactive { get; set; }

        public virtual AppSubMenus AppSubMenu { get; set; }
        public virtual Roles Role { get; set; }
    }
}
