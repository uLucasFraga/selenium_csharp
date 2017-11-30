using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace automation.pages
{
	public class BasePage
	{
		private static int ESPERAR_ELEMENTO_SEGUNDOS = 20;
		private readonly IWebDriver Driver;

		public BasePage()
		{
			Driver = (IWebDriver)ScenarioContext.Current["Driver"];
		}

		public void EsperarElemento(By caminho)
		{
			var Esperar = new WebDriverWait(Driver, TimeSpan.FromSeconds(ESPERAR_ELEMENTO_SEGUNDOS));
			Esperar.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(caminho));
		}

		public bool EsperarElementoVisivel(By caminho)
		{
			var Esperar = new WebDriverWait(Driver, TimeSpan.FromSeconds(ESPERAR_ELEMENTO_SEGUNDOS));
			Esperar.Until(ExpectedConditions.ElementIsVisible(caminho));

			return Localizar(caminho).Displayed;
		}

		public bool EsperarElementoClicavel(By caminho)
		{
			var Esperar = new WebDriverWait(Driver, TimeSpan.FromSeconds(ESPERAR_ELEMENTO_SEGUNDOS));
			Esperar.Until(ExpectedConditions.ElementToBeClickable(caminho));

			return Localizar(caminho).Displayed && Localizar(caminho).Enabled;
		}

		public IWebElement Localizar(By caminho)
		{
			return Driver.FindElement(caminho);
		}

		public void Clicar(By caminho)
		{
			EsperarElementoVisivel(caminho);
			EsperarElementoClicavel(caminho);
			Localizar(caminho).Click();
		}

		public void EscreverEnter(By caminho, string texto)
		{
			EsperarElementoVisivel(caminho);
			Localizar(caminho).Clear();
			Localizar(caminho).SendKeys(texto);
			Localizar(caminho).SendKeys(Keys.Enter);
		}

		public void Escrever(By caminho, string texto)
		{
			EsperarElementoVisivel(caminho);
			Localizar(caminho).Clear();
			Localizar(caminho).SendKeys(texto);
		}

		public string PegarTexto(By caminho)
		{
			return Localizar(caminho).Text;
		}

		public void Navegar(string url)
		{
			Driver.Navigate().GoToUrl(url);
		}
	}
}