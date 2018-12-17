using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MessWala.Data.Models;
using MessWala.Data.Models.ViewModels;

namespace MessWala.Services
{
    public class RestaurantService
    {
        FoodExContext dbContext = new FoodExContext();
        // public RestaurantService(FoodExContext _dbContext)
        // {
        //     dbContext = _dbContext;
        // }

        public List<ResponseDto> GetPlanMastersMinInfo()
        {
            return dbContext.PlanMasters.Select(m => new ResponseDto()
            {
                Id = m.PlanMasterId,
                    Name = m.Name
            }).ToList();
        }

        public List<ResponseDto> GetCategoriesMinInfo()
        {
            return dbContext.Categories.Select(m => new ResponseDto()
            {
                Id = m.CategoryId,
                    Name = m.Name
            }).ToList();
        }

        public List<ResponseDto> GetRestaurantsMinInfo()
        {
            return dbContext.Restaurants.Where(m => m.StatusTypeId == 1).Select(m => new ResponseDto()
            {
                Id = m.RestaurantId,
                    Name = m.Name
            }).ToList();
        }

        public List<ResponseDto> GetRestaurantItemsMinInfo()
        {
            return dbContext.RestaurantItems.Where(m => m.StatusTypeId == 1).Select(m => new ResponseDto()
            {
                Id = m.ItemId,
                    Name = m.Name
            }).ToList();

        }

        #region Plan Related Methods
        public PlanDto GetPlanDetails(int? id)
        {
            PlanDto plan = new PlanDto();
            plan.LstPlanMastersDto = GetPlanMastersMinInfo();
            plan.LstRestaurantsDto = GetRestaurantsMinInfo();
            plan.LstCategoriesDto = GetCategoriesMinInfo();

            var planData = dbContext.Plans.Where(m => m.PlanId == id).FirstOrDefault();
            if (planData != null)
            {
                plan.PlanId = planData.PlanId;
                plan.Name = planData.Name;
                plan.RestaurantId = planData.RestaurantId;
                plan.CategoryId = planData.CategoryId;
                plan.PlanMasterId = planData.PlanMasterId;
                plan.Cost = planData.Cost;
                plan.Description = planData.Description;

            }
            return plan;
            //Plans.LstRestaurantItemsDto = GetRestItemsMinInfo();
        }

        public List<PlanItemsDto> GetListOfPlanItems(int? planId)
        {
            var planItems = dbContext.PlanItems.Where(m => m.PlanId == planId).OrderBy(m => m.PlanItemId);
            //var groupIds = (from pi in dbContext.Planitemsnew.OrderBy(m => m.Planitemid) group pi by pi.Groupid into g select g.Key.Value);
            var groupIds = planItems.GroupBy(m => m.Groupid).Select(m => m.Key).ToList();

            List<PlanItemsDto> lstPlanItems = new List<PlanItemsDto>();
            int index = 1;
            foreach (var group in groupIds)
            {
                var groupData = planItems.Where(m => m.Groupid == group).ToList();
                if (groupData != null && groupData.Count > 0)
                {
                    PlanItemsDto itemData = new PlanItemsDto();
                    itemData.PlanGroupId = index;
                    itemData.PlanId = groupData[0].PlanId;
                    itemData.SelectedItemIds = groupData.Select(m => m.ItemId).ToArray();
                    itemData.DefaultItemIds = groupData.Where(m => m.Isdefaultitem == true).Select(m => m.ItemId).ToArray();
                    itemData.MaxItemsToSelect = groupData.Where(m => m.Isdefaultitem == true).Count();
                    itemData.GroupId = groupData[0].Groupid;

                    lstPlanItems.Add(itemData);
                    index++;
                }
            }
            return lstPlanItems.OrderByDescending(m => m.PlanGroupId).ToList();

        }

        public int UpsertPlanDetails(PlanDto planDto)
        {
            Plans planDetails = dbContext.Plans.Where(m => m.PlanId == planDto.PlanId).FirstOrDefault();
            var lstPlanItemDetails = dbContext.PlanItems.Where(m => m.PlanId == planDto.PlanId);
            if (planDetails != null)
            {
                planDetails.Name = planDto.Name;
                planDetails.CategoryId = planDto.CategoryId;
                planDetails.PlanMasterId = planDto.PlanMasterId;
                planDetails.RestaurantId = planDto.RestaurantId;
                planDetails.Cost = planDto.Cost;
                planDetails.Description = planDto.Description;
                planDetails.UpdatedBy = 1;
                planDetails.UpdatedDate = DateTime.Now;
                planDetails.StatusTypeId = 1;

                foreach (var planItem in planDto.LstPlanItemsDto)
                {
                    Guid groupId = planItem.GroupId;
                    if (!planItem.IsEdit)
                        groupId = Guid.NewGuid();
                    foreach (var foodItem in planItem.SelectedItemIds)
                    {

                        PlanItems planItemEntity = lstPlanItemDetails.Where(m => m.Groupid == groupId && m.ItemId == foodItem).FirstOrDefault();
                        if (planItemEntity != null)
                        {
                            planItemEntity.PlanId = planDto.PlanId;
                            planItemEntity.Isdefaultitem = planItem.DefaultItemIds.Contains(foodItem);
                            planItemEntity.UpdatedBy = 1;
                            planItemEntity.UpdatedDate = DateTime.Now;
                            planItemEntity.StatusTypeId = 1;
                        }
                        else
                        {
                            planItemEntity = new PlanItems();
                            planItemEntity.PlanId = planDto.PlanId;
                            planItemEntity.ItemId = foodItem;
                            planItemEntity.Isdefaultitem = planItem.DefaultItemIds.Contains(foodItem);
                            planItemEntity.Groupid = groupId;
                            planItemEntity.CreatedBy = 1;
                            planItemEntity.CreatedDate = DateTime.Now;
                            planItemEntity.StatusTypeId = 1;

                            planDetails.PlanItems.Add(planItemEntity);

                        }
                    }

                    var removableItems = lstPlanItemDetails.Where(m => m.Groupid == groupId && !planItem.SelectedItemIds.Any(o => o == m.ItemId)).ToList();
                    dbContext.PlanItems.RemoveRange(removableItems);

                }
                if (planDto.LstPlanItemsDto != null && planDto.LstPlanItemsDto.Count > 0)
                {
                    var uniqueGroups = planDto.LstPlanItemsDto.GroupBy(m => m.GroupId).Select(m => m.Key).ToList();
                    var removableGroups = lstPlanItemDetails.Where(m => !uniqueGroups.Any(o => o == m.Groupid)).ToList();
                    dbContext.PlanItems.RemoveRange(removableGroups);
                }

            }
            else
            {
                planDetails = new Plans();
                planDetails.Name = planDto.Name;
                planDetails.CategoryId = planDto.CategoryId;
                planDetails.PlanMasterId = planDto.PlanMasterId;
                planDetails.RestaurantId = planDto.RestaurantId;
                planDetails.Cost = planDto.Cost;
                planDetails.Description = planDto.Description;
                planDetails.CreatedBy = 1;
                planDetails.CreatedDate = DateTime.Now;
                planDetails.StatusTypeId = 1;

                foreach (var planItem in planDto.LstPlanItemsDto)
                {
                    Guid groupId = Guid.NewGuid();
                    foreach (var foodItem in planItem.SelectedItemIds)
                    {
                        PlanItems planItemsNew = new PlanItems();
                        planItemsNew.PlanId = planDto.PlanId;
                        planItemsNew.ItemId = foodItem;
                        planItemsNew.Isdefaultitem = planItem.DefaultItemIds.Contains(foodItem);
                        planItemsNew.Groupid = groupId;
                        planItemsNew.CreatedBy = 1;
                        planItemsNew.CreatedDate = DateTime.Now;
                        planItemsNew.StatusTypeId = 1;

                        planDetails.PlanItems.Add(planItemsNew);

                    }

                }
                dbContext.Plans.Add(planDetails);
            }

            return dbContext.SaveChanges();
        }

        public PlanVM GetListOfPlans(PlanVM planVM)
        {
            planVM.LstPlans = dbContext.Plans.Where(m => m.StatusTypeId == 1).Select(m => new PlanDto()
            {
                PlanId = m.PlanId,
                    Name = m.Name,
                    Restaurant = m.Restaurant.Name,
                    Category = m.Category.Name,
                    PlanMaster = m.PlanMaster.Name,
                    Cost = m.Cost,
                    Description = m.Description

            }).ToList();
            planVM.PaginationModel.TotalPages = (int) Math.Ceiling(decimal.Divide(planVM.LstPlans.Count, planVM.PaginationModel.PageSize));
            planVM.PaginationModel.TotalRecords = planVM.LstPlans.Count;
            if (planVM.LstPlans.Count > planVM.PaginationModel.PageSize)
                planVM.LstPlans = planVM.LstPlans.Skip((planVM.PaginationModel.PageNumber - 1) * planVM.PaginationModel.PageSize).Take(planVM.PaginationModel.PageSize).ToList();
            planVM.PaginationModel.Url = "/restaurant/plans";
            return planVM;

        }

        public int DeletePlan(int planId)
        {
            Plans planDetails = dbContext.Plans.Where(m => m.PlanId == planId).FirstOrDefault();
            if (planDetails != null)
            {
                planDetails.StatusTypeId = 2;
                planDetails.UpdatedBy = 1;
                planDetails.UpdatedDate = DateTime.Now;
            }

            return dbContext.SaveChanges();

        }

        #endregion

    }
}