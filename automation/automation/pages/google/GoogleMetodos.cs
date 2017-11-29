using OpenQA.Selenium;

namespace automation.pages.google
{
	public class GoogleMetodos : BasePage
	{
		public GoogleElementos Elementos { get; private set; }
		public void acessarHome(string url)
		{
			Navegar(url);
		}

		public void fazerPesquisa(string texto)
		{
			Elementos = new GoogleElementos();
			EsperarElementoVisivel(Elementos.inputPesquisa);
			EscreverEnter(Elementos.inputPesquisa, texto);
		}
	}
}