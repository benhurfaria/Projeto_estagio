#language: pt-br

Funcionalidade: Criar um aluno valido

Cenario: Criando aluno
	Dado que quero criar um aluno
		E que eu informo a matricula 201801482
		E que eu informo o como "ben"
		E que eu informo o numero de cpf como "65155831091"
		E que eu informo o sexo como  "masculino"
		E que eu informo a data "24/11/1994"
	Quando eu criar o aluno e os dados estao no formato
	Entao verifico se eh valido