#language: pt-br
Funcionalidade: Criar um aluno invalido

Cenario: Criando aluno invalido
	Dado que quero criar um aluno invalido
		E que eu informar a matricula 201801482
		E que eu informar o nome ""
		E que eu informar o numero de cpf como "12345678912"
		E que eu informar o sexo como  "masculino"
		E que eu informar a data "24/11/1994"
	Quando eu criar o aluno e dados forem invalidos
	Entao disparo uma excecao






