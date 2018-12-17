using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MessWala.Data;
using MessWala.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace MessWala.Api.Controllers {
    public class PlanController : BaseController {
        // Iconfiguration _configuaration;
        FoodExContext _context;

        private readonly ILogger<PlanController> _logger;
        public PlanController (ILogger<PlanController> logger, FoodExContext context) {
            // this._configuaration = configuaration;
            _logger = logger;
            _context = context;
        }

        public class PlanData {
            public int PlanId { get; set; }
            public string Name { get; set; }
            public int RestaurantId { get; set; }
            public int CategoryId { get; set; }
            public int PlanMasterId { get; set; }
            public int CreatedBy { get; set; }
            public DateTime CreatedDate { get; set; }
            public int? UpdatedBy { get; set; }
            public DateTime? UpdatedDate { get; set; }
            public int StatusTypeId { get; set; }

        }

        [HttpPost]
        [Route ("api/Plan/CreatePlan")]
        public async Task<int> CreatePlan (PlanData plan) {

            try {
                var entity = new Plans {

                    PlanId = plan.PlanId,
                    Name = plan.Name,
                    RestaurantId = plan.RestaurantId,
                    CategoryId = plan.CategoryId,
                    PlanMasterId = plan.PlanMasterId,
                    CreatedBy = plan.CreatedBy,
                    StatusTypeId = plan.StatusTypeId,
                    CreatedDate = plan.CreatedDate,
                    UpdatedDate = plan.UpdatedDate,
                    UpdatedBy = plan.StatusTypeId,
                };
                _context.Plans.Add (entity);
                return await _context.SaveChangesAsync ();
            } catch (Exception) {
                throw;
            }
        }

        [HttpPost]
        [Route ("api/Plan/GetPlan")]
        public async Task<List<PlanData>> GetPlan () {

            try {
                var data = await (from plan in _context.Plans select new PlanData () {
                    PlanId = plan.PlanId,
                        Name = plan.Name,
                        RestaurantId = plan.RestaurantId,
                        CategoryId = plan.CategoryId,
                        PlanMasterId = plan.PlanMasterId,
                        CreatedBy = plan.CreatedBy,
                        StatusTypeId = plan.StatusTypeId,
                        CreatedDate = plan.CreatedDate,
                        UpdatedDate = plan.UpdatedDate,
                        UpdatedBy = plan.StatusTypeId,
                }).ToListAsync ();
                return data;
            } catch (Exception) {
                throw;
            }

        }

    }
}