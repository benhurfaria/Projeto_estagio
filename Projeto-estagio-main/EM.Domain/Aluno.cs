using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Domain
{

    public class Aluno : IEntidade
    {
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime Nascimento { get; set; }
        public EnumeradorSexo Sexo { get; set; }

        public Aluno()
        {

        }
        public Aluno(int matricula, string nome, string cpf, DateTime nascimento, EnumeradorSexo sexo)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ValidationException("Aluno deve ter um nome!");
            }
            if (nascimento.CompareTo(DateTime.Today) > 0)
            {
                throw new ValidationException("O aluno deve ter nascido!");
            }

            Matricula = matricula;
            Nome = nome;
            Cpf = cpf;
            Nascimento = nascimento;
            Sexo = sexo;
        }
        public override bool Equals(object obj)
        {
            return obj is Aluno aluno && aluno.Matricula == Matricula;

        }

        public override int GetHashCode()
        {
            return Matricula;
        }

        public override string ToString()
        {
            return $@"Matricula: {Matricula}, Nome: {Nome}, Cpf: {Cpf}, Nascimento: {Nascimento}, Sexo: {Sexo}";
        }

    }


}




