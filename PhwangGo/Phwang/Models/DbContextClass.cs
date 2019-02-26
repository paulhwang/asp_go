using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Phwang.Models
{
    public class DbContextClass : DbContext
    {
        public DbContextClass() //: base("name=GoDatabase")
        {
        }
        public virtual DbSet<AccountTableClass> Accounts { get; set; }
    }
}
