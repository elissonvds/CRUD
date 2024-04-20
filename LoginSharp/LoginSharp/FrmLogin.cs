using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LoginSharp
{
    public partial class FrmLogin : Form
    {


        SqlConnection Conexao = new SqlConnection(@"Data Source=DESKTOP-O04EKJO;Initial Catalog=LoginCsharp;Integrated Security=True;Encrypt=False;");
        public FrmLogin()

        {
            InitializeComponent();
            txtUsuario.Select();
        }

        void verificar()
        {
            if(txtUsuario.Text == "" && txtUsuario.Text== "")
            {
                MessageBox.Show("Preencha os campos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //botao entrar
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Conexao.Open(); // abrir conexao
            verificar();
            string query = "SELECT * FROM Usuario WHERE Username = '" + txtUsuario.Text + "'AND Password = '" + txtPassword.Text + "'";
            SqlDataAdapter dp = new SqlDataAdapter(query, Conexao);
            DataTable dt = new DataTable();
            dp.Fill(dt);


            
            
                if(dt.Rows.Count == 1)
               {
                    FrmPrincipal principal = new FrmPrincipal();
                    this.Hide();
                    principal.Show();
                   
                }


            
            else 
            {
                MessageBox.Show("Usuario ou Password Incorreta","Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtUsuario.Text = "";
                txtPassword.Text = "";
                txtUsuario.Select();
            }
             Conexao.Close(); //fechar conexao

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
