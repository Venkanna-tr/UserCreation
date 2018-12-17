using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MessWala.Data.Models.ViewModels {
    public class UserDto {
        public int UserId { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("User Name")]
        public string UserName { get; set; }

        [DisplayName("Mobile No")]
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }

        [DisplayName("Role")]
        public int RoleId { get; set; }
        public string Role { get; set; }

        [DisplayName ("User Type")]
        public int UserTypeId { get; set; }
        public string UserType { get; set; }
        public int StatusTypeID { get; set; }
        public List<ResponseDto> lstRoles { get; set; }
        public List<ResponseDto> lstUserTypes { get; set; }

    }

    public class UserVM {
        public List<UserDto> lstUsers { get; set; }
        public PaginationVM PaginationModel { get; set; }
    }

}