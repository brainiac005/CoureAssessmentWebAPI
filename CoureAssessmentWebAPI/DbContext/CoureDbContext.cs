using CoureAssessmentWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CoureAssessmentWebAPI.DbContext
{
    public partial class CoureDbContext : IdentityDbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CoureDbContext()
        {
        }
        public CoureDbContext(DbContextOptions<CoureDbContext> options)
            : base(options)
        {
        }

      public DbSet<Country> Country { get; set; }
      public DbSet<CountryDetails> CountryDetails { get; set; }
    }
}
