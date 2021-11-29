using System;
using TechTalk.SpecFlow;
using EM.Domain;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace EM.Repository.Testes
{
    [Binding]
    public class TestarOGetallStepDefinitions
    {
        Aluno aluno1= new Aluno(1, "b", "", Convert.ToDateTime("24/11/1995"), EnumeradorSexo.Masculino);
        Aluno aluno2 = new Aluno(2, "c", "", Convert.ToDateTime("24/11/1997"), EnumeradorSexo.Feminino);
        Aluno aluno3 = new Aluno(3, "d", "", Convert.ToDateTime("24/11/2001"), EnumeradorSexo.Masculino);
        RepositorioAluno repositorio = new RepositorioAluno();
        
        [Given(@"que eu tenho uma lista de alunos")]
        public void GivenQueEuTenhoUmaListaDeAlunos()
        {
            repositorio.Add(aluno1);
            repositorio.Add(aluno2);
            repositorio.Add(aluno3);
        }

        [When(@"eu chamo o metodo getall")]
        public void WhenEuChamoOMetodoGetall()
        {
            var colecao = repositorio.GetAll();
            Assert.IsTrue(colecao.Contains(aluno1));
            Assert.IsTrue(colecao.Contains(aluno2));
            Assert.IsTrue(colecao.Contains(aluno3));
        }

        [Then(@"ele retorna minha lista de alunos")]
        public void ThenEleRetornaMinhaListaDeAlunos()
        {
            repositorio.Remove(aluno1);
            repositorio.Remove(aluno2);
            repositorio.Remove(aluno3);
            Assert.IsTrue(true);
            
        }
    }
}
