using System;
using Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Config
{
	public class ContextBase : IdentityDbContext<ApplicationUser>
	{
		public ContextBase(DbContextOptions<ContextBase> options) : base(options)
		{ }

        public DbSet<Product> Product { get; set; }
		public DbSet<ApplicationUser> ApplicationUser { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if(!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(GetStringConectionConfig());
				base.OnConfiguring(optionsBuilder);
			}
		}

        protected override void OnModelCreating(ModelBuilder builder)
        {
			builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);
			base.OnModelCreating(builder);
        }
				
		private string GetStringConectionConfig()
		{
			string strCon = "Server=tcp:system-an-cs-01.database.windows.net,1433;Initial Catalog=DbSystem_AN_CS_01;Persist Security Info=False;User ID=maiconlmotadev;Password=FMw43oGfM3#V;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            return strCon;
        }

		
    }


}

