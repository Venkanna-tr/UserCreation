using System;
using System.Collections.Generic;

namespace MessWala.Data.Models
{
    public partial class UserCreds
    {
        public int UserId { get; set; }
        public string PasswordEncryption { get; set; }
        public string PasswordHash { get; set; }

        public virtual Users User { get; set; }
    }
}
