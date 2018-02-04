using DAL;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Domain;

namespace IntegrationTest
{
	[TestFixture]
	public class ReferatRepoTest
	{
		private MyContext _db;

		[SetUp]
		public void Start()
		{
			Database.SetInitializer(new DropCreateDatabaseAlways<MyContext>());
			_db = new MyContext( ConfigurationManager.ConnectionStrings[0].ConnectionString);
		}

		[TearDown]
		public void Finish()
		{
			if (Database.Exists(_db.Database.Connection.ConnectionString))
				_db.Database.Delete();
		}

		[Test]
		public void AddTest()
		{
			var referat = new Referat();
			referat.Text = "hello world";

			using (var uof = new UnitOfWork())
			{
				uof.ReferatRepo.Add(referat);
				uof.Save();
			}


			using (var uof2 = new UnitOfWork())
			{
				var allReferates = uof2.ReferatRepo.GetAll().ToList();
				Assert.IsNotEmpty(allReferates);
			}


		}
	}
}
