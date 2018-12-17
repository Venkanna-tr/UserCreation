using System;
using System.Collections.Generic;

namespace MessWala.Data.Models
{
    public partial class PlanMasters
    {
        public PlanMasters()
        {
            Plans = new HashSet<Plans>();
        }

        public int PlanMasterId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Plans> Plans { get; set; }
    }
}
