using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Domain;
using System.Linq.Expressions;
using FirebirdSql.Data.FirebirdClient;


namespace EM.Repository
{
    public class RepositorioAluno : RepositorioAbstrato<Aluno>
    {

        public override void Add(Aluno objeto)
        {
            if (GetAll().Contains(objeto))
            {
                throw new Exception("Matricula já cadastrada!");
            }
            if (Get(aluno => aluno.Cpf == objeto.Cpf && aluno.Matricula != objeto.Matricula).Any() && objeto.Cpf.Length > 0)
            {
                throw new Exception("Cpf já cadastrado!");
            }
            using (FbConnection conexao = BancoDeDados.Conexao())
            {

                string inserindo = $@"INSERT INTO ALUNOS (MATRICULA, NOME, CPF, NASCIMENTO, SEXO)
                                      VALUES ({objeto.Matricula}, '{objeto.Nome}', '{objeto.Cpf}', '{objeto.Nascimento:dd/MM/yyyy}', {(int)objeto.Sexo})";
                FbCommand cmd = new FbCommand(inserindo, conexao);
                cmd.ExecuteNonQuery();
            }
        }

        public override void Remove(Aluno objeto)
        {
            using (FbConnection conexao = BancoDeDados.Conexao())
            {
                string deletando = $"DELETE from ALUNOS where MATRICULA={objeto.Matricula}";
                FbCommand cmd = new FbCommand(deletando, conexao);
                cmd.ExecuteNonQuery();
            }
        }
        public override void Update(Aluno objeto)
        {
            if (Get(aluno => aluno.Cpf == objeto.Cpf && aluno.Matricula != objeto.Matricula).Any())
            {
                throw new Exception("CPF já cadastrado!");
            }

            using (FbConnection conexao = BancoDeDados.Conexao())
            {

                string atualizando = $"UPDATE ALUNOS set NOME='{objeto.Nome}', CPF='{objeto.Cpf}', NASCIMENTO='{objeto.Nascimento:dd/MM/yyyy}', SEXO={(int)objeto.Sexo} WHERE MATRICULA={objeto.Matricula}";
                FbCommand cmd = new FbCommand(atualizando, conexao);
                cmd.ExecuteNonQuery();

            }
        }
        public override IEnumerable<Aluno> GetAll()
        {

            using (FbConnection conexao = BancoDeDados.Conexao())
            {
                string consulta = $"SELECT * FROM ALUNOS";
                var alunos = new List<Aluno>();
                FbCommand cmd = new FbCommand(consulta, conexao);
                var dtr = cmd.ExecuteReader();
                while (dtr.Read())
                {
                    Aluno aluno = new Aluno
                    {
                        Matricula = dtr.GetInt32(dtr.GetOrdinal("MATRICULA")),
                        Nome = dtr[1].ToString(),
                        Cpf = dtr[2].ToString(),
                        Nascimento = DateTime.Parse(dtr[3].ToString()),
                        Sexo = (EnumeradorSexo)dtr[4]
                    };
                    alunos.Add(aluno);
                }
                return alunos;

            }
        }

        public override IEnumerable<Aluno> Get(Expression<Func<Aluno, bool>> predicate)
        {
            return GetAll().Where(predicate.Compile());
        }
        public Aluno GetByMatricula(int matricula)
        {
            using (FbConnection conexao = BancoDeDados.Conexao())
            {
                Aluno aluno = new Aluno();
                string consulta = $"SELECT * FROM ALUNOS where MATRICULA={matricula}";
                FbCommand cmd = new FbCommand(consulta, conexao);
                var dtr = cmd.ExecuteReader();

                while (dtr.Read())
                {
                    aluno.Matricula = Convert.ToInt32(dtr[0]);
                    aluno.Nome = dtr[1].ToString();
                    aluno.Cpf = dtr[2].ToString();
                    aluno.Nascimento = DateTime.Parse(dtr[3].ToString());
                    aluno.Sexo = (EnumeradorSexo)dtr[4];
                }
                return (aluno.Nome == null) ? null : aluno;
            }
        }

        public IEnumerable<Aluno> GetByContendoNoNome(string parteNome)
        {

            using (FbConnection conexao = BancoDeDados.Conexao())
            {


                string consulta = $"SELECT * FROM ALUNOS WHERE LOWER(NOME) LIKE LOWER('%{parteNome}%')";
                FbCommand cmd = new FbCommand(consulta, conexao);
                List<Aluno> alunos = new List<Aluno>();
                var dtr = cmd.ExecuteReader();
                while (dtr.Read())
                {
                    Aluno aluno = new Aluno
                    {
                        Matricula = Convert.ToInt32(dtr[0]),
                        Nome = dtr[1].ToString(),
                        Cpf = dtr[2].ToString(),
                        Nascimento = DateTime.Parse(dtr[3].ToString()),
                        Sexo = (EnumeradorSexo)dtr[4]
                    };
                    alunos.Add(aluno);
                }
                return alunos;

            }
        }


    }
}

