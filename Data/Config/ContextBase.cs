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
			string strCon = "Data Source=MAC-WIN;Initial Catalog=DbSystem_AN_CS_01; Integrated Security=True";
			return strCon;
		}


	}


}

