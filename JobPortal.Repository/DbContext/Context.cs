using Jobportal.Model.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Repository.Contexts
{
   public class Context:DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<RoleMaster> roleMasters { get; set; }
        public DbSet<OtpMaster> otpMasters { get; set; }
        public DbSet<JobMaster> jobMasters { get; set; }
        public DbSet<CandidateMaster> candidateMasters { get; set; }
    }
}
