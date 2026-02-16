using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarsInit.Model;

namespace TarsInit.Data
{
    public class TarskeresoContext:DbContext
    {
        public TarskeresoContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected TarskeresoContext()
        {
        }

       



    }
}
