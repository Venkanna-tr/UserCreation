using System;
using System.Collections.Generic;

namespace MessWala.Data.Models
{
    public partial class Users
    {
        public Users()
        {
            InverseCreatedByNavigation = new HashSet<Users>();
            InverseUpdatedByNavigation = new HashSet<Users>();
            PlanItemsCreatedByNavigation = new HashSet<PlanItems>();
            PlanItemsUpdatedByNavigation = new HashSet<PlanItems>();
            PlansCreatedByNavigation = new HashSet<Plans>();
            PlansUpdatedByNavigation = new HashSet<Plans>();
            RestaurantItemsCreatedByNavigation = new HashSet<RestaurantItems>();
            RestaurantItemsUpdatedByNavigation = new HashSet<RestaurantItems>();
            RestaurantUsersCreatedByNavigation = new HashSet<RestaurantUsers>();
            RestaurantUsersUpdatedByNavigation = new HashSet<RestaurantUsers>();
            RestaurantUsersUser = new HashSet<RestaurantUsers>();
            RestaurantsCreatedByNavigation = new HashSet<Restaurants>();
            RestaurantsUpdatedByNavigation = new HashSet<Restaurants>();
            SubscribedUsers = new HashSet<SubscribedUsers>();
            UserLogs = new HashSet<UserLogs>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public int RoleId { get; set; }
        public int UserTypeId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int StatusTypeId { get; set; }

        public virtual Users CreatedByNavigation { get; set; }
        public virtual Roles Role { get; set; }
        public virtual StatusTypes StatusType { get; set; }
        public virtual Users UpdatedByNavigation { get; set; }
        public virtual UserTypes UserType { get; set; }
        public virtual UserCreds UserCreds { get; set; }
        public virtual ICollection<Users> InverseCreatedByNavigation { get; set; }
        public virtual ICollection<Users> InverseUpdatedByNavigation { get; set; }
        public virtual ICollection<PlanItems> PlanItemsCreatedByNavigation { get; set; }
        public virtual ICollection<PlanItems> PlanItemsUpdatedByNavigation { get; set; }
        public virtual ICollection<Plans> PlansCreatedByNavigation { get; set; }
        public virtual ICollection<Plans> PlansUpdatedByNavigation { get; set; }
        public virtual ICollection<RestaurantItems> RestaurantItemsCreatedByNavigation { get; set; }
        public virtual ICollection<RestaurantItems> RestaurantItemsUpdatedByNavigation { get; set; }
        public virtual ICollection<RestaurantUsers> RestaurantUsersCreatedByNavigation { get; set; }
        public virtual ICollection<RestaurantUsers> RestaurantUsersUpdatedByNavigation { get; set; }
        public virtual ICollection<RestaurantUsers> RestaurantUsersUser { get; set; }
        public virtual ICollection<Restaurants> RestaurantsCreatedByNavigation { get; set; }
        public virtual ICollection<Restaurants> RestaurantsUpdatedByNavigation { get; set; }
        public virtual ICollection<SubscribedUsers> SubscribedUsers { get; set; }
        public virtual ICollection<UserLogs> UserLogs { get; set; }
    }
}
