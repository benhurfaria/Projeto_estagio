using System;
using System.ComponentModel.DataAnnotations;
using TechTalk.SpecFlow;

namespace EM.Domain.Testes
{
    [Binding]
    public class CriarUmAlunoComDataInvalidaStepDefinitions
    {
        Aluno aluno;
        int _matricula;
        string _nome;
        string _cpf;
        EnumeradorSexo _sexo;
        DateTime _data;
        [Given(@"que quero criar um aluno com data invalida")]
        public void GivenQueQueroCriarUmAlunoComDataInvalida()
        {
            aluno = new Aluno();
        }

        [Given(@"que eu informar uma matricula (.*)")]
        public void GivenQueEuInformarUmaMatricula(int p0)
        {
            _matricula = p0;
        }

        [Given(@"que eu informar um nome ""([^""]*)""")]
        public void GivenQueEuInformarUmNome(string p0)
        {
            _nome = p0;
        }

        [Given(@"que eu informar um numero de cpf como ""([^""]*)""")]
        public void GivenQueEuInformarUmNumeroDeCpfComo(string p0)
        {
            _cpf = p0;
        }

        [Given(@"que eu informar um sexo como  ""([^""]*)""")]
        public void GivenQueEuInformarUmSexoComo(string sexo)
        {
            _sexo = (sexo.Equals("Masculino") || sexo.Equals("masculino")) ? EnumeradorSexo.Masculino : EnumeradorSexo.Feminino;
        }

        [Given(@"que eu informar uma data ""([^""]*)""")]
        public void GivenQueEuInformarUmaData(string p0)
        {
            _data = Convert.ToDateTime(p0);
        }

        [When(@"eu criar o aluno e a data for invalida")]
        public void WhenEuCriarOAlunoEADataForInvalida()
        {
            aluno.Matricula = _matricula;
            aluno.Nome = _nome;
            aluno.Cpf = _cpf;
            aluno.Nascimento = _data;
            aluno.Sexo = _sexo;
        }

        [Then(@"disparo uma excecao na data")]
        public void ThenDisparoUmaExcecaoNaData()
        {
            NUnit.Framework.Assert.Catch<ValidationException>(() => new Aluno(_matricula, _nome, _cpf, _data, _sexo));
        }
    }
}
