using System;
using TechTalk.SpecFlow;
using EM.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EM.Repository.Testes.Teste.Steps
{
    [Binding]
    public class RemoverSteps
    {
        Aluno _aluno;
        RepositorioAluno _repositorioAluno = new RepositorioAluno();

        [Given(@"que adicionei um  aluno de matricula (.*), nome ""(.*)"", cpf ""(.*)"", sexo ""(.*)"", nascimento ""(.*)"" no repositorio")]
        public void DadoQueAdicioneiUmAlunoDeMatriculaNomeCpfSexoNascimentoNoRepositorio(int matricula, string nome, string cpf, string sexo, string data)
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


        [When(@"eu remover o aluno no repositorio")]
        public void WhenEuRemoverOsAlunosNoRepositorio()
        {
            _repositorioAluno.Remove(_aluno);
        }

        [Then(@"nao havera registro do aluno de matricula (.*) no repositorio")]
        public void EntaoNaoHaveraRegistroDoAlunoDeMatricula(int matricula)
        {
            Aluno alunoRetorno = _repositorioAluno.GetByMatricula(matricula);
            Assert.IsNull(alunoRetorno);
        }

    }
}
