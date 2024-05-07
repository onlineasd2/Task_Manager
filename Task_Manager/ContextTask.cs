using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager
{
    class ContextTask : DbContext
    {
        public ContextTask (DbContextOptions<ContextTask> options)
            : base (options)
        {

        }

        public DbSet<STask> STasks { get; set; } 

    }
}
