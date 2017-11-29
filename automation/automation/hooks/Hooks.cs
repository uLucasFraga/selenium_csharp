using automation.pages;
using System.Linq;
using TechTalk.SpecFlow;

namespace automation.hooks
{
	[Binding]
	public sealed class Hooks
	{

		[BeforeScenario]
		public void BeforeScenario()
		{
			var iniciar = new Browser();

			if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("Chrome") ||
				(FeatureContext.Current.FeatureInfo.Tags.Contains("Chrome")))
				iniciar.EscolherBrowser("Chrome");

			if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("Firefox") ||
				(FeatureContext.Current.FeatureInfo.Tags.Contains("Firefox")))
				iniciar.EscolherBrowser("Firefox");
		}

		[AfterScenario]
		public void AfterScenario()
		{
			var fim = new Browser();
			fim.FinalizarBrowser();
		}
	}
}