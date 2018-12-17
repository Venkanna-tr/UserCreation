using System;
using System.Collections.Generic;

namespace MessWala.Data.Models
{
    public partial class RestaurantItems
    {
        public RestaurantItems()
        {
            PlanItems = new HashSet<PlanItems>();
            UserOrderItems = new HashSet<UserOrderItems>();
        }

        public int ItemId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string AliasName { get; set; }
        public int RestaurantId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int StatusTypeId { get; set; }
        public string Description { get; set; }
        public string Imagename { get; set; }
        public string Imagepath { get; set; }

        public virtual Categories Category { get; set; }
        public virtual Users CreatedByNavigation { get; set; }
        public virtual Restaurants Restaurant { get; set; }
        public virtual StatusTypes StatusType { get; set; }
        public virtual Users UpdatedByNavigation { get; set; }
        public virtual ICollection<PlanItems> PlanItems { get; set; }
        public virtual ICollection<UserOrderItems> UserOrderItems { get; set; }
    }
}
