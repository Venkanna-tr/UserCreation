using System;
using System.Collections.Generic;

namespace MessWala.Data.Models
{
    public partial class SubscriptionTypes
    {
        public SubscriptionTypes()
        {
            SubscribedUsers = new HashSet<SubscribedUsers>();
        }

        public int SubscriptionTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SubscribedUsers> SubscribedUsers { get; set; }
    }
}
