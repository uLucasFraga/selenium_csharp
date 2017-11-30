using automation.pages;
using automation.utils;
using OpenQA.Selenium;
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

			if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("IE") ||
				(FeatureContext.Current.FeatureInfo.Tags.Contains("IE")))
				iniciar.EscolherBrowser("IE");
		}

		[AfterScenario]
		public void AfterScenario()
		{
			if (ScenarioContext.Current.TestError != null)
			{
				var screen = new ScreenShot();
				screen.TirarScreenshot();
			}
			var fim = new Browser();
			fim.FinalizarBrowser();
		}
	}
}