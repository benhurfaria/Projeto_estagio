#language: pt-br	
Funcionalidade: retornar uma lista de nomes que tenha uma parte do nome

Cenario: Lista de nomes
	Dado que eu tenha entrado com uma parte do nome
	E esse nome tenha "y"
	Quando eu mandar parte do nome ao repositorio
	Entao ele retorna todos os alunos que tem parte do nome
