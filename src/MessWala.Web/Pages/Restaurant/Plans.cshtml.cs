using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessWala.Data.Models.ViewModels;
using MessWala.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MessWala.Web.Pages.Restaurant
{
    public class PlansModel : PageModel
    {
        RestaurantService restSrvc = new RestaurantService();
        public PlansModel()
        {
            PlanModel = new PlanVM();
            PlanModel.PaginationModel = new PaginationVM();
        }

        [BindProperty]
        public PlanVM PlanModel { get; set; }

        public void OnGetAsync(int? id, int? pageSize)
        {
            try
            {
                if (id != null && id > 0)
                    PlanModel.PaginationModel.PageNumber = id.Value;
                if (pageSize != null && pageSize > 0)
                    PlanModel.PaginationModel.PageSize = pageSize.Value;
                PlanModel = restSrvc.GetListOfPlans(PlanModel);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public ActionResult OnGetDeletePlanAsync(int id)
        {
            int result = restSrvc.DeletePlan(id);
            return RedirectToPage("/restaurant/plans");
        }
    }
}