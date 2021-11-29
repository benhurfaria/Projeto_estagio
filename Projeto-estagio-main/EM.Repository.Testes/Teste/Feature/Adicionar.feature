#language: pt-br
Funcionalidade: Adicionar
				
Cenario: Adiciona aluno no banco
	Dado que quero adicionar aluno no repositorio
		E que eu informo a matricula 201801481
		E que eu informo o como "ben"
		E que eu informo o numero de cpf como "02937486169"
		E que eu informo o sexo como  "masculino"
		E que eu informo a data "24/11/1995"
	Quando eu inscrever o aluno no repositorio
	Entao deve haver um aluno com matricula 201801481, nome "ben", cpf "02937486169", sexo "masculino", e nascimento "24/11/1995"