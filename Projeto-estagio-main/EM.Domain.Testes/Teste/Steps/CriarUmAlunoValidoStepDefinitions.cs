using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Domain.Testes
{
    [Binding]
    public class CriarUmAlunoValidoStepDefinitions
    {
        Aluno aluno;
        int _matricula;
        string _nome;
        string _cpf;
        DateTime _data;
        EnumeradorSexo _sexo;
        [Given(@"que quero criar um aluno")]
        public void GivenQueQueroCriarUmAluno()
        {
            aluno = new Aluno();
        }

        [Given(@"que eu informo a matricula (.*)")]
        public void GivenQueEuInformoAMatricula(int p0)
        {
            _matricula = p0;
        }

        [Given(@"que eu informo o como ""([^""]*)""")]
        public void GivenQueEuInformoOComo(string benh)
        {
            _nome = benh;
        }

        [Given(@"que eu informo o numero de cpf como ""([^""]*)""")]
        public void GivenQueEuInformoONumeroDeCpfComo(string p0)
        {
            _cpf = p0;
        }

        [Given(@"que eu informo o sexo como  ""([^""]*)""")]
        public void GivenQueEuInformoOSexoComo(string sexo)
        {
            _sexo = (sexo.Equals("Masculino") || sexo.Equals("masculino")) ? EnumeradorSexo.Masculino : EnumeradorSexo.Feminino;
        }

        [Given(@"que eu informo a data ""([^""]*)""")]
        public void GivenQueEuInformoAData(string data)
        {
            _data = Convert.ToDateTime(data);
        }

        [When(@"eu criar o aluno e os dados estao no formato")]
        public void WhenEuCriarOAlunoEOsDadosEstaoNoFormato()
        {
            aluno.Matricula = _matricula;
            aluno.Nome = _nome;
            aluno.Cpf = _cpf;
            aluno.Nascimento = _data;
            aluno.Sexo = _sexo;
        }

        [Then(@"verifico se eh valido")]
        public void ThenVerificoSeEhValido()
        {
            Assert.IsNotNull(aluno);
        }
    }
}
