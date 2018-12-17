using System;
using System.Collections.Generic;

namespace MessWala.Data.Models
{
    public partial class UserOrderItems
    {
        public int UserOrderItemId { get; set; }
        public int UserOrderId { get; set; }
        public int ItemId { get; set; }
        public Guid? GroupId { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual RestaurantItems Item { get; set; }
        public virtual UserOrders UserOrder { get; set; }
    }
}
