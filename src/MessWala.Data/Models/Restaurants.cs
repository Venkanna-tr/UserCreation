using System;
using System.Collections.Generic;

namespace MessWala.Data.Models
{
    public partial class Restaurants
    {
        public Restaurants()
        {
            Plans = new HashSet<Plans>();
            RestaurantItems = new HashSet<RestaurantItems>();
            RestaurantUsers = new HashSet<RestaurantUsers>();
        }

        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int StatusTypeId { get; set; }

        public virtual Users CreatedByNavigation { get; set; }
        public virtual StatusTypes StatusType { get; set; }
        public virtual Users UpdatedByNavigation { get; set; }
        public virtual ICollection<Plans> Plans { get; set; }
        public virtual ICollection<RestaurantItems> RestaurantItems { get; set; }
        public virtual ICollection<RestaurantUsers> RestaurantUsers { get; set; }
    }
}
