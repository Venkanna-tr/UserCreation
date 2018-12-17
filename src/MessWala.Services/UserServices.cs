using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MessWala.Data.Models;
using MessWala.Data.Models.ViewModels;

namespace MessWala.Services
{
    public class UserService
    {
        FoodExContext dbContext = new FoodExContext();
        // public UserService(FoodExContext _dbContext)
        // {
        //     dbContext = _dbContext;
        // }
        public List<ResponseDto> GetRoles()
        {
            return dbContext.Roles.Select(m => new ResponseDto()
            {
                Id = m.RoleId,
                Name = m.Name
            }).ToList();
        }
        public List<ResponseDto> GetUserTypes()
        {
            return dbContext.UserTypes.Select(m => new ResponseDto()
            {
                Id = m.UserTypeId,
                Name = m.Name
            }).ToList();
        }

        public List<ResponseDto> GetRestaurantUsers()
        {
            return dbContext.UserTypes.Select(m => new ResponseDto()
            {
                Id = m.UserTypeId,
                Name = m.Name
            }).ToList();
        }

        public UserVM GetUsersList(UserVM Users)
        {
            Users.lstUsers = (from u in dbContext.Users
                              join r in dbContext.Roles on u.RoleId equals r.RoleId
                              join ut in dbContext.UserTypes on u.UserTypeId equals ut.UserTypeId
                              where u.StatusTypeId == 1
                              select new UserDto()
                              {
                                  UserId = u.UserId,
                                  FirstName = u.FirstName,
                                  LastName = u.LastName,
                                  UserName = u.UserName,
                                  MobileNo = u.MobileNo,
                                  Email = u.Email,
                                  Address1 = u.Address1,
                                  Address2 = u.Address2,
                                  Address3 = u.Address3,
                                  Role = r.Name,
                                  UserType = ut.Name,
                              }).ToList();
            return Users;

        }

        public int CreateUserDetails(UserDto userDto)
        {
            Users userData = dbContext.Users.Where(m => m.UserId == userDto.UserId).FirstOrDefault();
            var lstPlanItemDetails = dbContext.PlanItems.Where(m => m.PlanId == userDto.UserId);
            if (userData != null)
            {
                userData.FirstName = userDto.FirstName;
                userData.LastName = userDto.LastName;
                userData.UserName = userDto.UserName;
                userData.MobileNo = userDto.MobileNo;
                userData.Email = userDto.Email;
                userData.Address1 = userDto.Address1;
                userData.Address2 = userDto.Address2;
                userData.Address2 = userDto.Address2;
                userData.UpdatedBy = 1;
                userData.UpdatedDate = DateTime.Now;
                userData.StatusTypeId = 1;
            }
            else
            {
                userData = new Users();
                userData.FirstName = userDto.FirstName;
                userData.LastName = userDto.LastName;
                userData.UserName = userDto.UserName;
                userData.MobileNo = userDto.MobileNo;
                userData.Email = userDto.Email;
                userData.RoleId = userDto.RoleId;
                userData.UserTypeId = userDto.UserTypeId;
                userData.Address1 = userDto.Address1;
                userData.Address2 = userDto.Address2;
                userData.Address3 = userDto.Address3;
                userData.CreatedBy = 1;
                userData.CreatedDate = DateTime.Now;
                userData.StatusTypeId = 1;
                dbContext.Users.Add(userData);
            }
            return dbContext.SaveChanges();
        }

        public UserDto GetUserInfo(int? id)
        {
            UserDto userdto = new UserDto();
            var user = dbContext.Users.Where(m => m.UserId == id).FirstOrDefault();
            if (user != null)
            {
                userdto.UserId = user.UserId;
                userdto.FirstName = user.FirstName;
                userdto.LastName = user.LastName;
                userdto.UserName = user.UserName;
                userdto.MobileNo = user.MobileNo;
                userdto.Email = user.Email;
                userdto.RoleId = user.RoleId;
                userdto.UserTypeId = user.UserTypeId;
                userdto.Address1 = user.Address1;
                userdto.Address2 = user.Address2;
                userdto.Address3 = user.Address3;
                userdto.StatusTypeID = user.StatusTypeId;
            }
            return userdto;
        }


        public int DeleteUSer(int userId)
        {
            Users userInfo = dbContext.Users.Where(m => m.UserId == userId).FirstOrDefault();
            if (userInfo != null)
            {
                userInfo.StatusTypeId = 2;
                userInfo.UpdatedBy = 1;
                userInfo.UpdatedDate = DateTime.Now;
            }
            return dbContext.SaveChanges();
        }
    }

}