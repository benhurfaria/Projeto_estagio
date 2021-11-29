#language: pt-br
Funcionalidade: Remover

Cenario: Remover aluno no banco
	Dado que adicionei um  aluno de matricula 201801481, nome "ben", cpf "02937486169", sexo "masculino", nascimento "24/11/1995" no repositorio
	Quando eu remover o aluno no repositorio
	Entao nao havera registro do aluno de matricula 201801481 no repositorio