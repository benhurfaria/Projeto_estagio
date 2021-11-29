#language: pt-br
Funcionalidade: Atualizar
				
Cenario: Atualiza aluno no banco
	Dado que adicionei aluno com matricula 201801481, nome "joao", cpf "02937486169", sexo "masculino", nascimento "24/11/1995"
		E que atualizo o nome "maria"
		E que atualizo o cpf para "12345678910"
		E atualizo o sexo para "feminino"
		E que atualizo o nascimento para "01/01/2000"
	Quando eu atualizo o aluno no repositorio
	Entao o aluno de matricula 201801481, deve ter nome "maria", cpf "12345678910", sexo "feminino", e nascimento "01/01/2000"