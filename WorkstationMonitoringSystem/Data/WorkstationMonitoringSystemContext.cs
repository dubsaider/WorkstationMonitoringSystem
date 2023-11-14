using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkstationMonitoringSystem.Models;

namespace WorkstationMonitoringSystem.Data
{
    public class WorkstationMonitoringSystemContext : DbContext
    {
        public WorkstationMonitoringSystemContext (DbContextOptions<WorkstationMonitoringSystemContext> options)
            : base(options)
        {
        }

        public DbSet<WorkstationMonitoringSystem.Models.Workstation> Workstation { get; set; } = default!;
    }
}
