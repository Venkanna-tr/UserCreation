using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using MessWala.Data.Models;
using MessWala.Data.Models.ViewModels.AccountViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MessWala.Web.Pages {
    public class IndexModel : PageModel {
        FoodExContext _context = new FoodExContext ();

        [BindProperty]
        public LoginDto LoginDto { get; set; }
        public void OnGet () {

        }
        public ActionResult OnPost () {
            try {
                LoginDto usr = (from u in _context.Users where u.UserName == LoginDto.UserName select new LoginDto () {
                    UserName = u.UserName,
                }).FirstOrDefault ();
                if (usr != null) {
                    return RedirectToPage ("users/RestaurantUsersList");
                } else {
                    return RedirectToPage ("restaurant/plans");
                }
            } catch (Exception) {
                throw;
            }
        }
    }
}