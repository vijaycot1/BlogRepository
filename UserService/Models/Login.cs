using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyAngular.Models
{
    [Table("Movie")]
    public class Login
    {
        [Key]
        public int LoginId { get; set; }
        public String password{ get;set;}
        

    }
}
