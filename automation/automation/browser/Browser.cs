using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using TechTalk.SpecFlow;

namespace automation.pages
{
	public sealed class Browser
	{
		private IWebDriver Driver { get; set; }

		public void EscolherBrowser(string browser)
		{
			switch (browser)
			{
				case "Chrome":
					var options = new ChromeOptions();
					options.AddUserProfilePreference("credentials_enable_service", false);
					options.AddUserProfilePreference("password_manager_enabled", false);
					Driver = new ChromeDriver(options);
					ConfigurarBrowser();
					ScenarioContext.Current["Driver"] = Driver;
					break;

				case "Firefox":
					var profilePadrao = new FirefoxProfileManager();
					FirefoxProfile profile = profilePadrao.GetProfile("Selenium");
					Driver = new FirefoxDriver(profile);
					ConfigurarBrowser();
					ScenarioContext.Current["Driver"] = Driver;
					break;

				case "IE":
					Driver = new InternetExplorerDriver();
					ConfigurarBrowser();
					ScenarioContext.Current["driver"] = Driver;
					break;

				default:
					Driver = new ChromeDriver();
					ConfigurarBrowser();
					ScenarioContext.Current["Driver"] = Driver;
					break;
			}
		}

		private void ConfigurarBrowser()
		{
			Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
			Driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromMilliseconds(10);
			Driver.Manage().Window.Maximize();
		}

		public void FinalizarBrowser()
		{
			Driver = (IWebDriver)ScenarioContext.Current["Driver"];
			Driver.Quit();
			Driver.Dispose();
		}
	}
}