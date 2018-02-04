using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
	public interface IRepository<T> where T : class
	{
		IEnumerable<T> GetAll();
		T GetById(int id);
		void Add(T item);
		void Delete(int id);
		bool IsDownloaded(int referatId);
		void AddRange(IEnumerable<Referat> referats);
	}
}
