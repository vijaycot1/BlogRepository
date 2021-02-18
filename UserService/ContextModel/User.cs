using System;
using System.Collections.Generic;

#nullable disable

namespace UserService.ContextModel
{
    public partial class User
    {
        public User()
        {
            Posts = new HashSet<Post>();
        }

        public long Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public bool IsActive { get; set; }
        public DateTime? LastLogin { get; set; }
        public string Salt { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
