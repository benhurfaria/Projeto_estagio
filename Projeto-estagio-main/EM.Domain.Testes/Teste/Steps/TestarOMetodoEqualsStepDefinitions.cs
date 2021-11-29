using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace EM.Domain.Testes
{
    [Binding]
    public class TestarOMetodoEqualsStepDefinitions
    {
        Aluno aluno1;
        Aluno aluno2;
        bool esperado;
        bool action;
        [Given(@"dois alunos")]
        public void GivenDoisAlunos()
        {
            aluno1 = new Aluno(1,"ben","02937486169",Convert.ToDateTime("24/11/1995"),EnumeradorSexo.Masculino);
            aluno2 = new Aluno(1, "ben", "02937486169", Convert.ToDateTime("24/11/1995"), EnumeradorSexo.Masculino);
        }

        [When(@"eu instanciar eles")]
        public void WhenEuInstanciarEles()
        {
            esperado = true;
            action = aluno1.Equals(aluno2);
            
        }

        [Then(@"verifico se eh igual")]
        public void ThenVerificoSeEhIgual()
        {
            Assert.AreEqual(esperado, action);
        }
    }
}
