using Domain;
using HtmlAgilityPack;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ConsoleApp.Infrastructura
{
	public class ReferatHelper : IReferatHelper
	{
		private int _referatCount;
		private readonly List<int> _downloadedReferatTokens;
		private readonly ICryptoRandom _random;


		public ReferatHelper(int refefatCount, List<int> downloadedReferatIds, ICryptoRandom random)
		{
			_referatCount = refefatCount;
			_downloadedReferatTokens = downloadedReferatIds;
			_random = random;

		}

		public List<Referat> GetReferatesFromYandex()
		{
			var bag = new ConcurrentBag<Referat>();

			var taskList = CreateTasks(GetRandomReferatesTokens());

			foreach (var task in taskList)
				task.Start();

			Task.WaitAll(taskList.ToArray());

			foreach (var task in taskList)
				bag.Add(task.Result);

			return bag.ToList();
		}

		private List<Task<Referat>> CreateTasks(List<int> referatTokens)
		{
			var taskList = new List<Task<Referat>>();

			for (int i = 0; i < referatTokens.Count; i++)
			{
				var task = new Task<Referat>(GetOneReferatFromYandex, referatTokens[i]);
				taskList.Add(task);
			}

			return taskList;
		}

		private Referat GetOneReferatFromYandex(Object referatTokenObj)
		{
			var referatToken = (int)referatTokenObj;

			if (_downloadedReferatTokens.Contains(referatToken))
				return null;

			HttpWebRequest myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create($"https://yandex.ru/referats/?t=mathematics&s={referatToken}");
			HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

			using (StreamReader myStreamReader = new StreamReader(myHttpWebResponse.GetResponseStream()))
			{
				var html = myStreamReader.ReadToEnd();

				var res = new Referat();
				res.ReferatToken = referatToken.ToString();
				res.Text = GetReferatTextFromHtml(html);

				return res;
			}
		}

		public string GetReferatTextFromHtml(string htmlString)
		{
			HtmlDocument doc = new HtmlDocument();

			doc.LoadHtml(htmlString);

			var res = doc.DocumentNode.Descendants("div").First(x => x.HasClass("referats__text")).InnerHtml;

			return res;
		}

		public List<int> GetRandomReferatesTokens()
		{
			var resList = new List<int>();

			for (int i = 0; i < _referatCount; i++)
			{
				var token = _random.Next();

				if (resList.Contains(token))
				{
					i--;
					continue;
				}

				resList.Add(token);
			}

			return resList;
		}
	}
}