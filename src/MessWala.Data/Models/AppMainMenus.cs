using System;
using System.Collections.Generic;

namespace MessWala.Data.Models
{
    public partial class AppMainMenus
    {
        public AppMainMenus()
        {
            AppSubMenus = new HashSet<AppSubMenus>();
        }

        public int AppMainMenuId { get; set; }
        public string NavPath { get; set; }
        public string IconPath { get; set; }
        public string MenuText { get; set; }
        public int? OrderId { get; set; }
        public int StatusTypeId { get; set; }

        public virtual StatusTypes StatusType { get; set; }
        public virtual ICollection<AppSubMenus> AppSubMenus { get; set; }
    }
}
