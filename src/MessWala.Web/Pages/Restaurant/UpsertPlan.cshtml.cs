using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessWala.Data.Models.ViewModels;
using MessWala.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace MessWala.Web.Pages.Restaurant
{
    public class UpsertPlanModel : PageModel
    {
        RestaurantService restSrvc = new RestaurantService();
        // public UpsertPlanModel(RestaurantService _restSrvc)
        // {
        //     restSrvc = _restSrvc;
        // }

        [BindProperty]
        public PlanDto PlanDto { get; set; }

        public void OnGetAsync(int? id)
        {
            PlanDto = restSrvc.GetPlanDetails(id);
        }

        public ActionResult OnGetListOfRestaurantItems()
        {
            var data = restSrvc.GetRestaurantItemsMinInfo();
            return new JsonResult(data);
        }

        public ActionResult OnGetListOfPlanItems(int? planId)
        {
            var lstPlanItems = restSrvc.GetListOfPlanItems(planId);
            return new JsonResult(lstPlanItems);

        }

        public ActionResult OnPostAsync()
        {
            try
            {
                PlanDto.LstPlanItemsDto = JsonConvert.DeserializeObject<List<PlanItemsDto>>(PlanDto.JsonArray);
                int result = restSrvc.UpsertPlanDetails(PlanDto);

            }
            catch (System.Exception)
            {

            }
            return RedirectToPage("/restaurant/plans");
        }

    }
}