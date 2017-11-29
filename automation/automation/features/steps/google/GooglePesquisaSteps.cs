using automation.pages;
using automation.pages.componentes.google;
using automation.pages.google;
using System.Configuration;
using TechTalk.SpecFlow;

namespace automation.steps.google
{
	[Binding]
	public class GooglePesquisaSteps : BasePage
	{
		public GoogleMetodos google { get; private set; }
		public GoogleVerificacoes verificacoes { get; private set; }

		[Given(@"que eu navegue para a home")]
		public void DadoQueEuNavegueParaAHome()
		{
			google = new GoogleMetodos();
			google.acessarHome(ConfigurationManager.AppSettings["googleHome"]);
		}

		[When(@"eu realizar uma pesquisa")]
		public void QuandoEuRealizarUmaPesquisa()
		{
			google.fazerPesquisa("github");
		}

		[Then(@"eu visualizo a pesquisa com sucesso")]
		public void EntaoEuVisualizoAPesquisaComSucesso()
		{
			verificacoes = new GoogleVerificacoes();
			verificacoes.verificarPesquisa("GitHub Inc.");
		}
	}
}