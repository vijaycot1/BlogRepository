using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyAngular
{
    public class LoginContext: DbContext
    {
        public LoginContext(DbContextOptions options)
       : base(options)
        {

        }

        public DbSet<Models.Login> Users { get; set; }
    }
}
