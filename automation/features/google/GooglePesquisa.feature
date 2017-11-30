#language: pt-BR
#Author: Lucas Fraga
#Date: 29/11/2017
#Version: 0.10

@Chrome
Funcionalidade: Pesquisar no google

#positivo
Cenario: Pesquisar no google com sucesso
	Dado que eu navegue para a home
	Quando eu realizar uma pesquisa
	Entao eu visualizo a pesquisa com sucesso

#negativo
Cenario: Pesquisar no google sem sucesso
	Dado que eu navegue para a home
	Quando eu realizar uma pesquisa
	Entao eu visualizo a pesquisa inválida com sucesso