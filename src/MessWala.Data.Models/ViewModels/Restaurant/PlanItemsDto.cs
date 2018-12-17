using System;
using System.Collections.Generic;

namespace MessWala.Data.Models.ViewModels
{
    public class PlanItemsDto
    {
        public int PlanItemId { get; set; }
        public int? PlanId { get; set; }
        public int[] SelectedItemIds { get; set; }
        public int[] DefaultItemIds { get; set; }
        public int? MaxItemsToSelect { get; set; }
        public Guid GroupId { get; set; }
        public int PlanGroupId { get; set; }
        public bool IsEdit { get; set; }
        public int? StatusTypeId { get; set; }
    }
}