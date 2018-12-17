using System;
using System.Collections.Generic;

namespace MessWala.Data.Models
{
    public partial class PlanItems
    {
        public int PlanItemId { get; set; }
        public int PlanId { get; set; }
        public int ItemId { get; set; }
        public bool Isdefaultitem { get; set; }
        public Guid Groupid { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int StatusTypeId { get; set; }

        public virtual Users CreatedByNavigation { get; set; }
        public virtual RestaurantItems Item { get; set; }
        public virtual Plans Plan { get; set; }
        public virtual StatusTypes StatusType { get; set; }
        public virtual Users UpdatedByNavigation { get; set; }
    }
}
