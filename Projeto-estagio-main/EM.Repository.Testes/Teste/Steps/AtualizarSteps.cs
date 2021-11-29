using System;

using TechTalk.SpecFlow;
using EM.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EM.Repository.Testes.Teste.Steps
{
    [Binding]
    public class AtualizarSteps
    {
        Aluno _aluno;
        RepositorioAluno _repositorioAluno = new RepositorioAluno();

        [Given(@"que adicionei aluno com matricula (.*), nome ""(.*)"", cpf ""(.*)"", sexo ""(.*)"", nascimento ""(.*)""")]
        public void DadoQueAdicioneiAlunoComMatriculazNomeCpfSexoNascimento(int matricula, string nome, string cpf, string sexo, string data)
        {
            Aluno alunoTeste = new Aluno()
            {
                Matricula = matricula,
                Nome = nome,
                Cpf = cpf,
                Sexo = (sexo.Equals("Masculino") || sexo.Equals("masculino")) ? EnumeradorSexo.Masculino : EnumeradorSexo.Feminino,
                Nascimento = Convert.ToDateTime(data)
            };

            _aluno = alunoTeste;
            _repositorioAluno.Add(_aluno);
        }


        [Given(@"que atualizo o nome ""(.*)""")]
        public void DadoQueAtualizoONome(string nome)
        {
            _aluno.Nome = nome;
        }

        [Given(@"que atualizo o cpf para ""(.*)""")]
        public void DadoQueAtualizoOCpfPara(string cpf)
        {
            _aluno.Cpf = cpf;
        }

        [Given(@"atualizo o sexo para ""(.*)""")]
        public void DadoAtualizoOSexoPara(string sexo)
        {
            EnumeradorSexo enumSexo = (sexo.Equals("Masculino") || sexo.Equals("masculino")) ? EnumeradorSexo.Masculino : EnumeradorSexo.Feminino;
            _aluno.Sexo = enumSexo;
        }

        [Given(@"que atualizo o nascimento para ""(.*)""")]
        public void DadoQueAtualizoONascimentoPara(string data)
        {
            _aluno.Nascimento = Convert.ToDateTime(data);
        }

        [When(@"eu atualizo o aluno no repositorio")]
        public void QuandoEuAtualizoOAlunoNoRepositorio()
        {
            _repositorioAluno.Update(_aluno);
        }

        [Then(@"o aluno de matricula (.*), deve ter nome ""(.*)"", cpf ""(.*)"", sexo ""(.*)"", e nascimento ""(.*)""")]
        public void EntaoOAlunoDeMatriculaDeveTerNomeCpfSexoENascimento(int matricula, string nome, string cpf, string sexo, string data)
        {
            Aluno alunoRetorno = _repositorioAluno.GetByMatricula(_aluno.Matricula);

            Aluno alunoTeste = new Aluno()
            {
                Matricula = matricula,
                Nome = nome,
                Cpf = cpf,
                Sexo = (sexo.Equals("Masculino") || sexo.Equals("masculino")) ? EnumeradorSexo.Masculino : EnumeradorSexo.Feminino,
                Nascimento = Convert.ToDateTime(data)
            };

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
