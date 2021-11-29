using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel.DataAnnotations;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace EM.Domain.Testes
{
    [Binding]
    public class CriarUmAlunoInvalidoStepDefinitions
    {
        Aluno aluno;
        int _matricula;
        string _nome;
        string _cpf;
        EnumeradorSexo _sexo;
        DateTime _data;
        [Given(@"que quero criar um aluno invalido")]
        public void GivenQueQueroCriarUmAlunoInvalido()
        {
            aluno = new Aluno();
        }

        [Given(@"que eu informar a matricula (.*)")]
        public void GivenQueEuInformarAMatricula(int p0)
        {
            _matricula = p0;
        }

        [Given(@"que eu informar o nome ""([^""]*)""")]
        public void GivenQueEuInformarONome(string benh)
        {
            _nome = benh;
        }

        [Given(@"que eu informar o numero de cpf como ""([^""]*)""")]
        public void GivenQueEuInformarONumeroDeCpfComo(string p0)
        {
            _cpf = p0;
        }

        [Given(@"que eu informar o sexo como  ""([^""]*)""")]
        public void GivenQueEuInformarOSexoComo(string sexo)
        {
            _sexo = (sexo.Equals("Masculino") || sexo.Equals("masculino")) ? EnumeradorSexo.Masculino : EnumeradorSexo.Feminino;
        }

        [Given(@"que eu informar a data ""([^""]*)""")]
        public void GivenQueEuInformarAData(string p0)
        {
            _data = Convert.ToDateTime(p0);
        }

        [When(@"eu criar o aluno e dados forem invalidos")]
        public void WhenEuCriarOAlunoEDadosForemInvalidos()
        {
            aluno.Matricula = _matricula;
            aluno.Nome = _nome;
            aluno.Cpf = _cpf;
            aluno.Nascimento = _data;
            aluno.Sexo = _sexo;
        }

        [Then(@"disparo uma excecao")]
        public void ThenDisparoUmaExcecao()
        {

            NUnit.Framework.Assert.Catch<ValidationException>(()=> new Aluno(_matricula,_nome,_cpf,_data,_sexo));

        }
    }
}
