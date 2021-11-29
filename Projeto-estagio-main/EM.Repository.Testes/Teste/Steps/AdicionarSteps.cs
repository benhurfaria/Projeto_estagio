using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using EM.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EM.Repository.Testes.Teste.Steps
{
    [Binding]
    public class AdicionarSteps
    {
        Aluno _aluno;
        RepositorioAluno _repositorioAluno = new RepositorioAluno();

        [Given(@"que quero adicionar aluno no repositorio")]
        public void GivenQueQueroAdicionarAlunoNoRepositorio()
        {
            _aluno = new Aluno();
        }

        [Given(@"que eu informo a matricula (.*)")]
        public void GivenQueEuInformoAMatricula(int matricula)
        {
            _aluno.Matricula = matricula;
        }

        [Given(@"que eu informo o como ""([^""]*)""")]
        public void GivenQueEuInformoOComo(string nome)
        {
            _aluno.Nome = nome;
        }

        [Given(@"que eu informo o numero de cpf como ""([^""]*)""")]
        public void GivenQueEuInformoONumeroDeCpfComo(string cpf)
        {
            _aluno.Cpf = cpf;
        }

        [Given(@"que eu informo o sexo como  ""([^""]*)""")]
        public void GivenQueEuInformoOSexoComo(string sexo)
        {
            EnumeradorSexo enumSexo = (sexo.Equals("Masculino")  || sexo.Equals("masculino")) ? EnumeradorSexo.Masculino : EnumeradorSexo.Feminino;
            _aluno.Sexo = enumSexo;
        }

        [Given(@"que eu informo a data ""([^""]*)""")]
        public void GivenQueEuInformoAData(string data)
        {
            _aluno.Nascimento = Convert.ToDateTime(data);
        }


        [When(@"eu inscrever o aluno no repositorio")]
        public void WhenEuInscreverOsAlunosNoRepositorio()
        {
            _repositorioAluno.Add(_aluno);
        }

        [Then(@"deve haver um aluno com matricula (.*), nome ""([^""]*)"", cpf ""([^""]*)"", sexo ""([^""]*)"", e nascimento ""([^""]*)""")]
        public void ThenElesVaoParaOBanco(int matricula, string nome, string cpf, string sexo, string data)
        {
            Aluno alunoTeste = new Aluno()
            {
                Matricula = matricula,
                Nome = nome,
                Cpf = cpf,
                Sexo = (sexo.Equals("Masculino") || sexo.Equals("masculino")) ? EnumeradorSexo.Masculino : EnumeradorSexo.Feminino,
                Nascimento = Convert.ToDateTime(data)
            };

            Aluno alunoRetorno = _repositorioAluno.GetByMatricula(_aluno.Matricula);

            Assert.IsNotNull(alunoRetorno);
            Assert.AreEqual(alunoTeste.Matricula, alunoRetorno.Matricula);
            Assert.AreEqual(alunoTeste.Nome, alunoRetorno.Nome);
            Assert.AreEqual(alunoTeste.Sexo, alunoRetorno.Sexo);
            Assert.AreEqual(alunoTeste.Nascimento, alunoRetorno.Nascimento);
            Assert.AreEqual(alunoTeste.Cpf, alunoRetorno.Cpf);

            _repositorioAluno.Remove(new Aluno() { Matricula = matricula });
        }

    }
}
