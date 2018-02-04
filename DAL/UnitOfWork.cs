using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class UnitOfWork : IDisposable
	{

		private MyContext _db = new MyContext(ConfigurationManager.ConnectionStrings[0].ConnectionString);
		private ReferatRepo _referatRepo;

		public ReferatRepo ReferatRepo
		{
			get
			{
				if (_referatRepo == null)
					_referatRepo = new ReferatRepo(_db);

				return _referatRepo;
			}
		}

		public void Save()
		{
			_db.SaveChanges();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		private bool disposed = false;

		public virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
					_db.Dispose();

				this.disposed = true;
			}
		}
	}
}
