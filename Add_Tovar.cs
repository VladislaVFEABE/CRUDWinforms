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


    public partial class Add_Tovar : Form
    {
        DataBase DataBase = new DataBase();

        public Add_Tovar()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;//открытие новой формы по центру экрана

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBase.openConnection();
            var type = textBox1.Text;
            var count = textBox2.Text;
            var postavshik = textBox3.Text;
            int price;
            if(int.TryParse(textBox4.Text, out price))//проверка поля textBox4 на тип данных int
            {
                var addQuery = $"INSERT INTO test_db(type_of,count_of,postavka,price) VALUES ('{type}', '{count}', '{postavshik}', '{price}')";
                var command = new SqlCommand(addQuery, DataBase.GetConnection());
                command.ExecuteNonQuery();

                MessageBox.Show("Товар добавлен!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Неправильный тип данных в одном из полей", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            DataBase.closeConnection();
        }
    }
}
