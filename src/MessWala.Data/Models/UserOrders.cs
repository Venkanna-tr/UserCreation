using System;
using System.Collections.Generic;

namespace MessWala.Data.Models
{
    public partial class UserOrders
    {
        public UserOrders()
        {
            UserOrderItems = new HashSet<UserOrderItems>();
        }

        public int UserOrderId { get; set; }
        public int SubscribedUserId { get; set; }
        public DateTime OrderedDate { get; set; }
        public int OrderStatusTypeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual OrderStatusTypes OrderStatusType { get; set; }
        public virtual SubscribedUsers SubscribedUser { get; set; }
        public virtual ICollection<UserOrderItems> UserOrderItems { get; set; }
    }
}
