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
    public partial class Form1 : Form
    {
        DataBase DataBase = new DataBase();
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;//открытие новой формы по центру экрана
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var familiya = textBox1.Text;
            var name = textBox2.Text;
            var otchestvo = textBox3.Text;
            var login = textBox4.Text;
            var password = textBox5.Text;
            var password_confirm = textBox6.Text;
            var data = textBox7.Text;
            var email = textBox8.Text;
            var phone = textBox9.Text;
            string zaprosreg = $"INSERT INTO register(familiya,name, otchestvo,login,password,password_confirm,data,email,phone) " +
                $"VALUES ('{familiya}', '{name}', '{otchestvo}', '{login}', '{password}', '{password_confirm}', '{data}', '{email}', '{phone}')";
            SqlCommand command = new SqlCommand(zaprosreg, DataBase.GetConnection());

            DataBase.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Аккаунт успешно создан", "Уведомление");
                Loginka log = new Loginka();
                this.Hide();
                log.ShowDialog();
            }

            else
            {
                MessageBox.Show("Аккаунт не создан");
            }
           DataBase.closeConnection();
        }

        private Boolean checkuser()//логический метод возвращающий true or false
        {
            var loginUserr = textBox1.Text;
            var passwordd = textBox2.Text;
            var passwordd_confirmm = textBox3.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string zaprosreg = $"SELECT id,login,password,password_confirm FROM register WHERE login = '{loginUserr}' AND password = '{passwordd}' AND password_confirm = '{passwordd_confirmm}'";

            SqlCommand command = new SqlCommand(zaprosreg, DataBase.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Пользователь уже существует!");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
