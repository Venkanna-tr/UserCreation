using System;
using System.Collections.Generic;

namespace MessWala.Data.Models
{
    public partial class UserLogs
    {
        public int UserLogId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public DateTime LogonTime { get; set; }
        public DateTime? LogoutTime { get; set; }
        public Guid? SessionId { get; set; }
        public int LoginStatusTypeId { get; set; }
        public string ClientIp { get; set; }
        public int LoginDeviceTypeId { get; set; }
        public string DeviceModel { get; set; }

        public virtual LoginDeviceTypes LoginDeviceType { get; set; }
        public virtual LoginStatusTypes LoginStatusType { get; set; }
        public virtual Users User { get; set; }
    }
}
