using System;
using System.Collections.Generic;

namespace MessWala.Data.Models
{
    public partial class StatusTypes
    {
        public StatusTypes()
        {
            AppMainMenus = new HashSet<AppMainMenus>();
            AppSubMenus = new HashSet<AppSubMenus>();
            Categories = new HashSet<Categories>();
            PlanItems = new HashSet<PlanItems>();
            Plans = new HashSet<Plans>();
            RestaurantItems = new HashSet<RestaurantItems>();
            RestaurantUsers = new HashSet<RestaurantUsers>();
            Restaurants = new HashSet<Restaurants>();
            Roles = new HashSet<Roles>();
            Users = new HashSet<Users>();
        }

        public int StatusTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AppMainMenus> AppMainMenus { get; set; }
        public virtual ICollection<AppSubMenus> AppSubMenus { get; set; }
        public virtual ICollection<Categories> Categories { get; set; }
        public virtual ICollection<PlanItems> PlanItems { get; set; }
        public virtual ICollection<Plans> Plans { get; set; }
        public virtual ICollection<RestaurantItems> RestaurantItems { get; set; }
        public virtual ICollection<RestaurantUsers> RestaurantUsers { get; set; }
        public virtual ICollection<Restaurants> Restaurants { get; set; }
        public virtual ICollection<Roles> Roles { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
