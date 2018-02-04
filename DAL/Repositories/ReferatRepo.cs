using DAL.Abstract;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
	public class ReferatRepo : IRepository<Referat>
	{
		private readonly MyContext _db;

		public ReferatRepo(MyContext context)
		{
			_db = context;
		}

		public void Add(Referat item)
		{
			_db.ReferatesSet.Add(item);
		}

		public void AddRange(IEnumerable<Referat> referates)
		{
			_db.ReferatesSet.AddRange(referates);
		}

		public void Delete(int id)
		{
			var referat = _db.ReferatesSet.FirstOrDefault(x => x.ReferatId == id);

			if (referat != null)
				_db.ReferatesSet.Remove(referat);
		}

		public Referat GetById(int id)
		{
			return _db.ReferatesSet.FirstOrDefault(x=>x.ReferatId == id);
		}

		public IEnumerable<Referat> GetAll()
		{
			return _db.ReferatesSet;
		}

		public bool IsDownloaded(int referatId)
		{
			var res = GetById(referatId);
			return res != null;
		}
	}
}
