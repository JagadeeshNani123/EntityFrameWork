using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EntityFrameWork.Models;

namespace EntityFrameWork.Data
{
    public class EntityFrameWorkContext : DbContext
    {
        public EntityFrameWorkContext (DbContextOptions<EntityFrameWorkContext> options)
            : base(options)
        {
        }

        public DbSet<EntityFrameWork.Models.Student> Student { get; set; } = default!;
    }
}
