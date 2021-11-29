using System;
using TechTalk.SpecFlow;
using EM.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EM.Repository.Testes
{
    [Binding]
    public class TestarOGetbymatriculaStepDefinitions
    {
        RepositorioAluno repositorio = new RepositorioAluno();
        Aluno aluno;
        Aluno alunomatricula;
        [Given(@"que eu tenho a matricula do aluno (.*)")]
        public void GivenQueEuTenhoAMatriculaDoAluno(int p0)
        {
            aluno = repositorio.GetByMatricula(p0);
        }

        [When(@"eu pesquisar a matricula na barra de pesquisar")]
        public void WhenEuPesquisarAMatriculaNaBarraDePesquisar()
        {
            alunomatricula = repositorio.GetByMatricula(157);
        }

        [Then(@"vou obter a mmatricula do aluno")]
        public void ThenVouObterAMmatriculaDoAluno()
        {
            Assert.AreEqual(alunomatricula, aluno);
        }
    }
}
