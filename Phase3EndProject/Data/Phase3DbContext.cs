using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Phase3EndProject.Models;

namespace Phase3EndProject.Data
{
    public class Phase3DbContext : DbContext
    {
        public Phase3DbContext (DbContextOptions<Phase3DbContext> options)
            : base(options)
        {
        }

        public DbSet<Phase3EndProject.Models.DeptMasters> DeptMasters { get; set; } = default!;

        public DbSet<Phase3EndProject.Models.EmpProfile>? EmpProfile { get; set; }
    }
}
