using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.Entidades;
using View.Model;

namespace View
{
    public partial class CadTelefone : Form
    {
        public CadTelefone()
        {
            InitializeComponent();
        }

        //obj tabela pode pegar todos os componentes do usuariont pra trazer pra cá.
        UsuarioEnt objtabela = new UsuarioEnt();

        private void limparcampos()
        {

            txtnome.Clear();
            txttelefone.Clear();
            txtID.Clear();
            txtnome.Focus();
        }

        private void btnexcluir_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    objtabela.Id = Convert.ToInt32(txtID.Text);
                    objtabela.Nome = Convert.ToString(txtnome.Text);
                    objtabela.Telefone = Convert.ToString(txttelefone.Text);

                    int x = UsuarioModelo.Deletar(objtabela);
                    if (x > 0)
                    {
                        MessageBox.Show(string.Format("O usuário {0} foi deletado com sucesso !", txtnome.Text));


                    }
                    else
                    {
                        MessageBox.Show("Usuario não foi deletado!");
                    }
                    limparcampos();
                    ListarGrid();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }



        }

        private void btninserir_Click(object sender, EventArgs e)
        {
            //Ele envia para a tabela
            objtabela.Nome = txtnome.Text;
            objtabela.Telefone = txttelefone.Text;

            int x = UsuarioModelo.Inserir(objtabela);

            if (x > 0)
            {
                MessageBox.Show(string.Format("Usuario {0} foi Inserido", txtnome.Text));
                ListarGrid();

            }
            else
            {
                MessageBox.Show("Não foi Inserido!");
            }

        }



        //dg inicia com o programa!
        private void CadTelefone_Load(object sender, EventArgs e)
        {
            ListarGrid();
        }

        private void ListarGrid()
        {
            try
            {
                //cria uma lista 
                List<UsuarioEnt> lista = new List<UsuarioEnt>();
                lista = new UsuarioModelo().Lista();
                grid.AutoGenerateColumns = false;
                //grid data source receb os dados que vem da lista 
                grid.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = grid.CurrentRow.Cells[0].Value.ToString();
            txtnome.Text = grid.CurrentRow.Cells[1].Value.ToString();
            txttelefone.Text = grid.CurrentRow.Cells[2].Value.ToString();

        }

        private void txtconsulta_TextChanged(object sender, EventArgs e)
        {
            if (txtconsulta.Text == "")
            {
                ListarGrid();
                return;

            }
            try
            {
                limparcampos();
                txtconsulta.Focus();
                //Pega o nome que vc escreveu no campo e joga no objtabela
                objtabela.Nome = txtconsulta.Text;
                List<UsuarioEnt> lista = new List<UsuarioEnt>();
                lista = new UsuarioModelo().Consulta(objtabela);

                grid.AutoGenerateColumns = false;
                grid.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar dados" + ex.Message);
            }

        }

        private void btnalterar_Click(object sender, EventArgs e)
        {
            try
            {
                objtabela.Id = Convert.ToInt32(txtID.Text);
                objtabela.Nome = Convert.ToString(txtnome.Text);
                objtabela.Telefone = Convert.ToString(txttelefone.Text);

                int x = UsuarioModelo.Alterar(objtabela);
                if (x > 0)
                {
                    MessageBox.Show(string.Format("Usuario {0} foi Alterado", txtnome.Text));
                    ListarGrid();
                }
                else
                {
                    MessageBox.Show("Não alterado!");
                }
                limparcampos();
                ListarGrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
