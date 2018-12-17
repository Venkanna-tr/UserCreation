using System;
using System.Collections.Generic;

namespace MessWala.Data.Models
{
    public partial class LoginStatusTypes
    {
        public LoginStatusTypes()
        {
            UserLogs = new HashSet<UserLogs>();
        }

        public int LoginStatusTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserLogs> UserLogs { get; set; }
    }
}
