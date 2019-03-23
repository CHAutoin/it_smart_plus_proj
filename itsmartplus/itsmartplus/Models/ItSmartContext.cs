using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using itsmartplus.Models;

namespace itsmartplus.Models
{
	public class ItSmartContext : DbContext
	{
		public ItSmartContext(DbContextOptions<ItSmartContext> options) : base(options)
		{

		}

		public DbSet<type> types { get; set; }
		public DbSet<employee> employees { get; set; }
		public DbSet <category> categories { get; set; }
		public DbSet <admintable> admintables { get; set; }
		public DbSet <brand> brands { get; set; }

		public DbSet <pm_category> pm_Categories { get; set; }
		public DbSet <pm_category_detail> pm_Categories_details { get; set; }
		public DbSet<supplier> supplier { get; set; }
	}
}
