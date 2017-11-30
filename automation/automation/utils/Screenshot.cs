using OpenQA.Selenium;
using System;
using System.IO;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Tracing;

namespace automation.utils
{
	public class ScreenShot
	{
		private IWebDriver Driver { get; set; }

		public void TirarScreenshot()
		{
			if (ScenarioContext.Current.TestError != null)
			{
				Driver = (IWebDriver)ScenarioContext.Current["Driver"];
				TirarScreenshot(Driver);
			}
		}

		private void TirarScreenshot(IWebDriver Driver)
		{
			try
			{
				string fileNameBase = string.Format("error-{0}_{1}",
													//FeatureContext.Current.FeatureInfo.Title.ToIdentifier(),
													DateTime.Now.ToString("dd.MM.yyyy"),
													ScenarioContext.Current.ScenarioInfo.Title.ToIdentifier());

				var artifactDirectory = Path.Combine(Directory.GetCurrentDirectory(), "imagens_error");
				if (!Directory.Exists(artifactDirectory))
					Directory.CreateDirectory(artifactDirectory);

				string pageSource = Driver.PageSource;
				string sourceFilePath = Path.Combine(artifactDirectory, fileNameBase + "_source.html");
				File.WriteAllText(sourceFilePath, pageSource, Encoding.UTF8);
				Console.WriteLine("Page source: {0}", new Uri(sourceFilePath));

				ITakesScreenshot tirarScreenshot = Driver as ITakesScreenshot;

				if (tirarScreenshot != null)
				{
					var screenshot = tirarScreenshot.GetScreenshot();

					string screenshotCaminhoArquivo = Path.Combine(artifactDirectory, fileNameBase + "_screenshot.png");

					screenshot.SaveAsFile(screenshotCaminhoArquivo, ScreenshotImageFormat.Png);

					Console.WriteLine("ScreenShot: {0}", new Uri(screenshotCaminhoArquivo));
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Erro ao tirar screenshot: {0}", ex);
			}
		}
	}
}
