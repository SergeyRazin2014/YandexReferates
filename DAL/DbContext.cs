using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class MyContext : DbContext
	{
		public DbSet<Referat> ReferatesSet { get; set; }

		public MyContext(string connectionString)
		{
			Database.Connection.ConnectionString = connectionString;
		}

	}


}
