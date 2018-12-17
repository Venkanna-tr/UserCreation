using System;
using System.Collections.Generic;

namespace MessWala.Data.Models
{
    public partial class ProofTypes
    {
        public ProofTypes()
        {
            RestaurantUsers = new HashSet<RestaurantUsers>();
        }

        public int ProofTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RestaurantUsers> RestaurantUsers { get; set; }
    }
}
