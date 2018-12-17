using System;
using System.Collections.Generic;

namespace MessWala.Data.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Plans = new HashSet<Plans>();
            RestaurantItems = new HashSet<RestaurantItems>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int StatusTypeId { get; set; }

        public virtual StatusTypes StatusType { get; set; }
        public virtual ICollection<Plans> Plans { get; set; }
        public virtual ICollection<RestaurantItems> RestaurantItems { get; set; }
    }
}
