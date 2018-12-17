using Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SuperAdminModule.Controllers
{
    [ApiController]
    [Route("api/superadmin")]
    public class SuperAdminController : Controller
    {
        ISampleService _sampleService;
        readonly IConfiguration cnf;
        public SuperAdminController(ISampleService sampleService, IConfiguration configurationService)
        {
            _sampleService = sampleService;
            cnf = configurationService;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var cr = new ContentResult();
            var sample = _sampleService.GetTestData();
            sample = cnf["DataProvider"];
            //sample = (cnf == null) ? "null" : "not null";
            cr.Content = sample;
            return cr;
            //return View();
        }
    }
}
