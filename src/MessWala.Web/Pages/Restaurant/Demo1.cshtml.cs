using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Threading.Tasks;

namespace MessWala.Web.Pages.restaurant
{
    public class Demo1Model : PageModel
    {
        [BindProperty]
        public string SubToken { get; set; }
        public class LoginData
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public string DeviceId { get; set; }
            public string Token { get; set; }
        }
        static HttpClient client = new HttpClient();
        public async Task<IActionResult> OnGet()
        {
            string baseUrl = "http://localhost:62145/api/account/login";

            LoginData data = new LoginData
            {
                UserName = "Manoj",
                Password = "test12$",
                DeviceId = "123456"
            };

            HttpResponseMessage response = await client.PostAsJsonAsync(baseUrl, data);
            if (response.IsSuccessStatusCode)
            {
                var product = await response.Content.ReadAsAsync<LoginData>();
                SubToken = product.Token;
            }
            return Page();
        }
    }
}