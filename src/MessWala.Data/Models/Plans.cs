using System;
using System.Collections.Generic;

namespace MessWala.Data.Models
{
    public partial class Plans
    {
        public Plans()
        {
            PlanItems = new HashSet<PlanItems>();
            SubscribedUsers = new HashSet<SubscribedUsers>();
        }

        public int PlanId { get; set; }
        public string Name { get; set; }
        public int RestaurantId { get; set; }
        public int CategoryId { get; set; }
        public int PlanMasterId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int StatusTypeId { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public string Imagename { get; set; }
        public string Imagepath { get; set; }

        public virtual Categories Category { get; set; }
        public virtual Users CreatedByNavigation { get; set; }
        public virtual PlanMasters PlanMaster { get; set; }
        public virtual Restaurants Restaurant { get; set; }
        public virtual StatusTypes StatusType { get; set; }
        public virtual Users UpdatedByNavigation { get; set; }
        public virtual ICollection<PlanItems> PlanItems { get; set; }
        public virtual ICollection<SubscribedUsers> SubscribedUsers { get; set; }
    }
}
