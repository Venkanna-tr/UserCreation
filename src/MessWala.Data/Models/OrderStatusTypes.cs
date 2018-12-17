using System;
using System.Collections.Generic;

namespace MessWala.Data.Models
{
    public partial class OrderStatusTypes
    {
        public OrderStatusTypes()
        {
            UserOrders = new HashSet<UserOrders>();
        }

        public int OrderStatusTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserOrders> UserOrders { get; set; }
    }
}
