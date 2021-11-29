using System;
using TechTalk.SpecFlow;
using EM.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace EM.Repository.Testes
{
    [Binding]
    public class RetornarUmaListaDeNomesQueTenhaUmaParteDoNomeStepDefinitions
    {
        RepositorioAluno repositorio = new RepositorioAluno();
        List<Aluno> alunos = new List<Aluno>();
        Aluno aluno;
        [Given(@"que eu tenha entrado com uma parte do nome")]
        public void GivenQueEuTenhaEntradoComUmaParteDoNome()
        {
            aluno = new Aluno(730, "yasmim", "54248958082", Convert.ToDateTime("24/11/1995"), EnumeradorSexo.Feminino);
            repositorio.Add(aluno);
            alunos.Add(aluno);
        }

        [Given(@"esse nome tenha ""([^""]*)""")]
        public void GivenEsseNomeTenha(string y)
        {
            
        }

        [When(@"eu mandar parte do nome ao repositorio")]
        public void WhenEuMandarParteDoNomeAoRepositorio()
        {
            repositorio.GetByContendoNoNome(aluno.Nome);
        }

        [Then(@"ele retorna todos os alunos que tem parte do nome")]
        public void ThenEleRetornaTodosOsAlunosQueTemParteDoNome()
        {
            List<Aluno> alunoRetorno = (List<Aluno>)repositorio.GetByContendoNoNome(aluno.Nome);
            Assert.AreEqual(alunos[0].Nome, alunoRetorno[0].Nome);
            repositorio.Remove(alunos[0]);
        }
    }
}
