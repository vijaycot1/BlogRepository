using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAngular.Models
{
    public class Users
    {
 //       [Id] INT NOT NULL PRIMARY KEY,
	//[Name] Varchar(50),
	//[Password] VARCHAR(50),
	//[Username]
 //       VARCHAR(20)
        public long Id { get; set; }
        public String Name { get; set; }
        public String Password { get; set; }
        public String Username { get; set; }
        public string Token { get;set; }
    }

    public class CreateUserEntity
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public bool IsActive { get; set; }
        
    }
}
