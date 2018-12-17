using System;
using System.Collections.Generic;

namespace MessWala.Data.Models
{
    public partial class LoginDeviceTypes
    {
        public LoginDeviceTypes()
        {
            UserLogs = new HashSet<UserLogs>();
        }

        public int LoginDeviceTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserLogs> UserLogs { get; set; }
    }
}
