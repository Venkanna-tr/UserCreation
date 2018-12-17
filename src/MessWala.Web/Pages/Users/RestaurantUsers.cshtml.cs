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
    public class RestaurantUsersModel : PageModel
    {
        public RestaurantUsersModel()
        {
            UserDto = new UserDto();
        }
        UserService userSrvc = new UserService();

        [BindProperty]
        public UserDto UserDto { get; set; }

        public void OnGetAsync(int? id)
        {
            if (id != null && id > 0)
            {
                UserDto = userSrvc.GetUserInfo(id);
            }
            UserDto.lstRoles = userSrvc.GetRoles();
            UserDto.lstUserTypes = userSrvc.GetUserTypes();
        }

        public ActionResult OnPostAsync(UserDto userDto)
        {
            try
            {
                int result = userSrvc.CreateUserDetails(userDto);
            }
            catch (System.Exception)
            {
                throw;
            }
            return RedirectToPage("/users/RestaurantUsersList");
        }

    }
}