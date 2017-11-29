using NUnit.Framework;
using OpenQA.Selenium;

namespace automation.pages.componentes.google
{
	public class GoogleVerificacoes : BasePage
	{
		public By campoTexto = By.CssSelector("#rhs_title span");
		public By campoVasco = By.CssSelector("");

		public void verificarPesquisa(string validar)
		{
			EsperarElementoVisivel(campoTexto);

			string texto = PegarTexto(campoTexto);
			Assert.AreEqual(texto, validar);
		}
	}
}