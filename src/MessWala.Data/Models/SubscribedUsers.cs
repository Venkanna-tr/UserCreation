using System;
using System.Collections.Generic;

namespace MessWala.Data.Models
{
    public partial class SubscribedUsers
    {
        public SubscribedUsers()
        {
            UserOrders = new HashSet<UserOrders>();
        }

        public int SubscribedUserId { get; set; }
        public int UserId { get; set; }
        public int SubscriptionTypeId { get; set; }
        public int PlanId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? TotalDays { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual Plans Plan { get; set; }
        public virtual SubscriptionTypes SubscriptionType { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<UserOrders> UserOrders { get; set; }
    }
}
