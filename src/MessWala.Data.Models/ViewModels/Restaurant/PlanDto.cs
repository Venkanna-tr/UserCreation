using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MessWala.Data.Models.ViewModels
{
    public class PlanDto
    {
        public int PlanId { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Restaurant")]
        public int RestaurantId { get; set; }

        [DisplayName("Category")]
        public int CategoryId { get; set; }

        [DisplayName("Plan Type")]
        public int PlanMasterId { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public int StatusTypeId { get; set; }
        public string PlanImagePath { get; set; }
        public string JsonArray { get; set; }
        public List<PlanItemsDto> LstPlanItemsDto { get; set; }
        public List<ResponseDto> LstPlanMastersDto { get; set; }
        public List<ResponseDto> LstRestaurantsDto { get; set; }
        public List<ResponseDto> LstCategoriesDto { get; set; }
        //public List<RestaurantItemsDto> LstRestaurantItemsDto { get; set; }

        public string Restaurant { get; set; }
        public string Category { get; set; }
        public string PlanMaster { get; set; }

    }

    public class PlanVM
    {
        public List<PlanDto> LstPlans { get; set; }
        public PaginationVM PaginationModel { get; set; }
    }

    public class PaginationVM
    {
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public List<int> ActivePages { get; set; }
        public string Url { get; set; }
    }
}