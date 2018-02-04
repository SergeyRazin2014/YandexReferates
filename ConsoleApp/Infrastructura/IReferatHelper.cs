using System.Collections.Generic;
using Domain;

namespace ConsoleApp.Infrastructura
{
	public interface IReferatHelper
	{
		List<int> GetRandomReferatesTokens();
		List<Referat> GetReferatesFromYandex();
		string GetReferatTextFromHtml(string htmlString);
	}
}