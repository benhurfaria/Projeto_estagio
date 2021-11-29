using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EM.Domain;
using EM.Repository;
using iTextSharp;
namespace EM.WindowsForms
{
    public partial class Form1 : Form
    {
        RepositorioAluno repositorio = new RepositorioAluno();
        BindingSource bs = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            cbSexo.Text = "Masculino";
            dgv.DataSource = bs;
            bs.DataSource = repositorio.GetAll();
            bs.ResetBindings(false);
        }     

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if(!Char.IsDigit(chr) && chr!= 8)
            {
                e.Handled = true;
            }
        }

        private void _adicionar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMatricula.Text))
            {
                MessageBox.Show("Matricula vazia!");
                txtMatricula.Focus();
                return;
            }
            if (!DateTime.TryParse(mtxtNascimento.Text, out DateTime data))
            {
                MessageBox.Show("Nascimento inválido");
                return;
            }

            if (_adicionar.Text == "Adicionar")
            {
                if (validaCpf(txtCpf.Text) || txtCpf.Text.Length == 0)
                {
                    try
                    {
                        EnumeradorSexo sexo = cbSexo.Text.Equals("Masculino") ? EnumeradorSexo.Masculino : EnumeradorSexo.Feminino;
                        Aluno aluno = new Aluno(Convert.ToInt32(txtMatricula.Text), txtNome.Text, txtCpf.Text, Convert.ToDateTime(mtxtNascimento.Text), sexo);
                        repositorio.Add(aluno);
                        bs.DataSource = repositorio.GetAll();
                        dgv.DataSource = bs;                    
                        btnLimpa_Click(sender, e);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Cpf invalido!", "Tente novamente", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                }
            }
            else
            {
                if (validaCpf(txtCpf.Text) || txtCpf.Text.Length == 0)
                {
                    try
                    {
                        EnumeradorSexo sexo = cbSexo.Text.Equals("Masculino") ? EnumeradorSexo.Masculino : EnumeradorSexo.Feminino;
                        Aluno aluno = new Aluno(Convert.ToInt32(txtMatricula.Text), txtNome.Text, txtCpf.Text, Convert.ToDateTime(mtxtNascimento.Text), sexo);
                        repositorio.Update(aluno);
                        bs.DataSource = repositorio.GetAll();
                        dgv.DataSource = bs;
                        btnLimpa_Click(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Cpf invalido!", "Tente novamente", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                }
            }
        }

        private void btnLimpa_Click(object sender, EventArgs e)
        {
            txtCpf.Clear();
            txtMatricula.Clear();
            txtNome.Clear();
            mtxtNascimento.Clear();
            cbSexo.Text = "Masculino";
            txtPesquisa.Text = "";
            if(btnLimpa.Text == "Cancelar")
            {
                btnLimpa.Text = "Limpar";
                _adicionar.Text = "Adicionar";
                gpBox.Text = "Novo aluno";
                txtMatricula.Enabled = true;
            }
        }

        

        private void deletar_Click(object sender, EventArgs e)
        {
            if(!(bs.Current is Aluno))
            {
                MessageBox.Show("Nao existe aluno!", "Exclusão invalida", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                return;
            }

            if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja apagar o registro?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                repositorio.Remove((Aluno)bs.Current);
                bs.DataSource = repositorio.GetAll();
                dgv.DataSource = bs;
                btnLimpa_Click(sender, e);
            }
        }

        

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!(bs.Current is Aluno aluno))
            {
                MessageBox.Show("Estudante nao selecionado");
                return;
            }
            btnLimpa.Text = "Cancelar";
            _adicionar.Text = "Modificar";
            gpBox.Text = "Editando aluno";
            txtMatricula.Enabled = false;
            txtMatricula.Text = Convert.ToString(aluno.Matricula);
            txtNome.Text = aluno.Nome;
            cbSexo.SelectedItem = aluno.Sexo;
            mtxtNascimento.Text = Convert.ToString(aluno.Nascimento);
            txtCpf.Text = aluno.Cpf;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int matricula;
            
            if (Int32.TryParse(txtPesquisa.Text, out matricula))
            {
                bs.DataSource = repositorio.GetByMatricula(matricula);
            }
            else
            {
                bs.DataSource = repositorio.GetByContendoNoNome(txtPesquisa.Text);
            }
        }
        public static bool validaCpf(string Cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf;
            string digito;
            int cont = 0;
            int soma;
            int resto;

            Cpf = Cpf.Trim();
            Cpf = Cpf.Replace(".", "").Replace("-", "");
            if (Cpf.Length != 11)
                return false;
            tempCpf = Cpf.Substring(0, 9);
            soma = 0;
            for(int i=1; i < 9;i++)
            {
                if (tempCpf[0] == tempCpf[i])
                    cont++;
            }
            if (cont == 8)
                return false;
            for (int i = 0;i < 9;i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0;i < 10;i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return Cpf.EndsWith(digito);

        }

        private void txtCpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
            }
        }

        private void iText_Click(object sender, EventArgs e)
        {

        }
    }
}




