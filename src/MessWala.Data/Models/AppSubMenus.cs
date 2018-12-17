using System;
using System.Collections.Generic;

namespace MessWala.Data.Models
{
    public partial class AppSubMenus
    {
        public AppSubMenus()
        {
            AppRoleMenus = new HashSet<AppRoleMenus>();
        }

        public int AppSubMenuId { get; set; }
        public int? AppMainMenuId { get; set; }
        public string NavPath { get; set; }
        public string IconPath { get; set; }
        public string MenuText { get; set; }
        public int? OrderId { get; set; }
        public int StatusTypeId { get; set; }

        public virtual AppMainMenus AppMainMenu { get; set; }
        public virtual StatusTypes StatusType { get; set; }
        public virtual ICollection<AppRoleMenus> AppRoleMenus { get; set; }
    }
}
