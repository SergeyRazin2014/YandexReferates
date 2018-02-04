using ConsoleApp.Infrastructura;
using DAL;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Введите количество скачиваемых рефератов.");
			var referatCount = Console.ReadLine();

			Database.SetInitializer(new CreateDatabaseIfNotExists<MyContext>());

			if (!new Validator().IsPositiveInt(referatCount))
			{
				Console.WriteLine("Необходимо вводить только положительные числа!");
				Console.ReadKey();
				return;
			}

			using (var uof = new UnitOfWork())
			{
				//id уже скачанных рефератов
				var downloadedReferatesIds = uof.ReferatRepo.GetAll().Select(x => x.ReferatId).ToList();

				//получить рефераты
				var referates = new ReferatHelper(int.Parse(referatCount), downloadedReferatesIds, new CryptoRandom()).GetReferatesFromYandex();

				//сохранить рефераты в базу данных
				uof.ReferatRepo.AddRange(referates);

				uof.Save();

			}


		}


	}
}
