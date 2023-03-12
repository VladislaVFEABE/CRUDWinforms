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

namespace TestReload
{
    public partial class Loginka : Form
    {
        DataBase DataBase = new DataBase();

        public Loginka()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;//открытие новой формы по центру экрана
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Loginka_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            textBox1.MaxLength = 50;
            textBox2.MaxLength = 50;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var loginUser = textBox1.Text;
            var passwordUser = textBox2.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string stringquery = $"SELECT id,login,password FROM register where login = '{loginUser}' AND password = '{passwordUser}'";//выборка из БД полей id,login,password
            SqlCommand command = new SqlCommand(stringquery ,DataBase.GetConnection()); //возвращаем строку подключения

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                MessageBox.Show($"Вы успешно вошли как {loginUser}", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 reg = new Form1();//создание обьекта к новой форме
                this.Hide();
                reg.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Такого аккаунта в БД нет", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
