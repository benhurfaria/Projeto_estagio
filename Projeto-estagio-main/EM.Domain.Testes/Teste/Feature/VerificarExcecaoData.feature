#language: pt-br
Funcionalidade: Criar um aluno com data invalida

Cenario: Criando aluno com data invalida
	Dado que quero criar um aluno com data invalida
		E que eu informar uma matricula 201801481
		E que eu informar um nome "ben"
		E que eu informar um numero de cpf como "12345678912"
		E que eu informar um sexo como  "masculino"
		E que eu informar uma data "24/11/2022"
	Quando eu criar o aluno e a data for invalida
	Entao disparo uma excecao na data

