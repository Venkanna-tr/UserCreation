using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessWala.Data.Models.ViewModels;
using MessWala.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace MessWala.Web.Pages.Users
{
    public class RestaurantUsersListModel : PageModel
    {
        public RestaurantUsersListModel()
        {
            Users = new UserVM();
            Users.PaginationModel = new PaginationVM();
        }
        UserService userSrvc = new UserService();

        [BindProperty]
        public UserVM Users { get; set; }

        public void OnGetAsync(int? id, int? pageSize)
        {
            if (id != null && id > 0)
            {
                Users.PaginationModel.PageNumber = id.Value;
            }
            if (pageSize != null && pageSize > 0)
            {
                Users.PaginationModel.PageSize=pageSize.Value;
            }
                Users = userSrvc.GetUsersList(Users);
        }

        public ActionResult OnPostAsync(UserDto userDto)
        {
            try
            {
                int result = userSrvc.CreateUserDetails(userDto);
            }
            catch (System.Exception)
            {

            }
            return RedirectToPage("/restaurant/plans");
        }

        public ActionResult OnGetDeleteUSerAsync(int id)
        {
            int result = userSrvc.DeleteUSer(id);
            return RedirectToPage("/Users/RestaurantUsersList");
        }

    }
}