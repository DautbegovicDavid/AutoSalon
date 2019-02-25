using AutoSalon.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoSalon_UnitTest_Testing
{
    public class ContextHelper
    {
        public static IConfiguration Configuration { get; }

        public static ApplicationDbContext GetApplicationDbContext()
        {
            DbContextOptionsBuilder<ApplicationDbContext> builder =
                new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer("Server=.;Database=Autosalon;Trusted_Connection=True;MultipleActiveResultSets=true");
                                                                 
            return new ApplicationDbContext(builder.Options);
        }
    }
}
