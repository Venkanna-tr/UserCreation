using System;
using System.Collections.Generic;

namespace MessWala.Data.Models
{
    public partial class RestaurantUsers
    {
        public int RestaurantUserId { get; set; }
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
        public string ProofDocumentPath { get; set; }
        public int? ProofTypeId { get; set; }
        public string Otherproof { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int StatusTypeId { get; set; }

        public virtual Users CreatedByNavigation { get; set; }
        public virtual ProofTypes ProofType { get; set; }
        public virtual Restaurants Restaurant { get; set; }
        public virtual StatusTypes StatusType { get; set; }
        public virtual Users UpdatedByNavigation { get; set; }
        public virtual Users User { get; set; }
    }
}
