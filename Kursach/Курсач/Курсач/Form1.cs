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

namespace Курсач
{
    public partial class Form1 : Form
    {
        //Подключение Базы данных
        static string connectionString = @"Data Source = HELLCUTECORGI; Initial Catalog = Курсач;Integrated Security = True";
        public SqlConnection Connection = new SqlConnection(connectionString);
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Administrator.Hide();
            Moderator.Hide();
            Client.Hide();
            //Проверка для вошедших
            string CheckLogin = "select count(*) from [Users] where [Никнейм] = '" + textBox1.Text + "'";
            string CheckPassword = "select count(*) from [Users] where [Никнейм] = '" + textBox1.Text + "' and [Пароль] = HASHBYTES('SHA2_256','" + textBox2.Text + "')";
            string CheckName = "select [ФИО] from [Users] where [Никнейм] = '" + textBox1.Text + "'";
            string CheckRole = "select [Роль] from [Users] where [Никнейм] = '" + textBox1.Text + "'";
            SqlCommand cmd1 = new SqlCommand(CheckLogin, Connection);
            SqlCommand cmd2 = new SqlCommand(CheckPassword, Connection);
            SqlCommand cmd3 = new SqlCommand(CheckName, Connection);
            SqlCommand cmd4 = new SqlCommand(CheckRole, Connection);
            Connection.Open();
            if (cmd1.ExecuteScalar().ToString() == "0")
            {
                label3.Show();
                label3.Text = "Вы ввели неверные данные";
            }
            else if (cmd2.ExecuteScalar().ToString() == "0")
            {
                label3.Show();
                label3.Text = "Вы ввели неверный пароль";
            }
            else
            {
                if (cmd4.ExecuteScalar().ToString() == "Администратор")
                {
                    label3.Show();
                    label3.Text = "Добро пожаловать, " + cmd3.ExecuteScalar().ToString();
                    string CheckID = "select [ФИО] from [Users] where [Никнейм] = '" + textBox1.Text + "'";
                    Administrator.Show();
                }
                else if (cmd4.ExecuteScalar().ToString() == "Модератор")
                {
                    label3.Show();
                    label3.Text = "Добро пожаловать, " + cmd3.ExecuteScalar().ToString();
                    string CheckID = "select [ФИО] from [Users] where [Никнейм] = '" + textBox1.Text + "'";
                    SqlCommand cmd5 = new SqlCommand(CheckID, Connection);
                    Moderator.Show();
                }
                else if (cmd4.ExecuteScalar().ToString() == "Клиент")
                {
                    label3.Show();
                    label3.Text = "Добро пожаловать, " + cmd3.ExecuteScalar().ToString();
                    string CheckID = "select [ФИО] from [Users] where [Никнейм] = '" + textBox1.Text + "'";
                    SqlCommand cmd5 = new SqlCommand(CheckID, Connection);
                    Client.Show();
                }
            }
            Connection.Close();
            textBox1.Clear();
            textBox2.Clear();
            panel1.Hide();
        }


          
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "курсачDataSet12.Users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter.Fill(this.курсачDataSet12.Users);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "курсачDataSet11.Основная_информация1". При необходимости она может быть перемещена или удалена.
            this.основная_информация1TableAdapter.Fill(this.курсачDataSet11.Основная_информация1);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "курсачDataSet10.Основная_информация". При необходимости она может быть перемещена или удалена.
            this.основная_информацияTableAdapter.Fill(this.курсачDataSet10.Основная_информация);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "курсачDataSet9.Зарплаты1". При необходимости она может быть перемещена или удалена.
            this.зарплаты1TableAdapter.Fill(this.курсачDataSet9.Зарплаты1);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "курсачDataSet7.Зарплаты". При необходимости она может быть перемещена или удалена.
            this.зарплатыTableAdapter.Fill(this.курсачDataSet7.Зарплаты);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "курсачDataSet5.Услуги". При необходимости она может быть перемещена или удалена.
            this.услугиTableAdapter.Fill(this.курсачDataSet5.Услуги);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "курсачDataSet4.Клиенты1". При необходимости она может быть перемещена или удалена.
            //this.клиенты1TableAdapter.Fill(this.курсачDataSet4.Клиенты1);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "курсачDataSet2.Оборудование". При необходимости она может быть перемещена или удалена.
            this.оборудованиеTableAdapter.Fill(this.курсачDataSet2.Оборудование);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "курсачDataSet.Сотрудники1". При необходимости она может быть перемещена или удалена.
            //this.сотрудники1TableAdapter.Fill(this.курсачDataSet.Сотрудники1);

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            string s2 = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            string s3 = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
            string s4 = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
            string s5 = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
            string s6 = dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString();
            string s7 = dataGridView1[5, dataGridView1.CurrentRow.Index].Value.ToString();
            string ComAdd = " INSERT INTO [Users] ([Никнейм], [ФИО], [Роль], [Пароль], [Статус], [Дата регистрации]) VALUES(N'" + s2 + "', N'" + s3 + "', N'" + s4 + "', HASHBYTES('SHA2_256','"+ s5 +"'), N'" + s6 + "', '" + s7 + "')";

            SqlCommand cmd2 = new SqlCommand(ComAdd, Connection);
            Connection.Open();
            cmd2.ExecuteNonQuery();
            Connection.Close();
            this.usersTableAdapter.Fill(this.курсачDataSet12.Users);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.CurrentCell.RowIndex;
            string x1 = dataGridView1[0, row].Value.ToString();
            string ComDel = " Delete from [Users] where [Никнейм] = '" + x1 +"'";

            SqlCommand cmd1 = new SqlCommand(ComDel, Connection);
            Connection.Open();
            cmd1.ExecuteNonQuery();
            Connection.Close();
            this.usersTableAdapter.Fill(this.курсачDataSet12.Users);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.CurrentCell.RowIndex;
            string s1 = dataGridView1[0, row].Value.ToString();
            if (dataGridView1[1, dataGridView1.CurrentRow.Index].Selected == true)
            {
                string s2 = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
                string ComUp = " update [Users] set [ФИО] = '" + s2 + "' where [Никнейм] = '" + s1 + "'";
                SqlCommand cmd2 = new SqlCommand(ComUp, Connection);
                Connection.Open();
                cmd2.ExecuteNonQuery();
                Connection.Close();
            }
            else if (dataGridView1[2, dataGridView1.CurrentRow.Index].Selected == true)
            {
                string s2 = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
                string ComUp = " update [Users] set [Роль] = '" + s2 + "' where [Никнейм] = '" + s1 + "'";
                SqlCommand cmd3 = new SqlCommand(ComUp, Connection);
                Connection.Open();
                cmd3.ExecuteNonQuery();
                Connection.Close();
            }
            else if (dataGridView1[3, dataGridView1.CurrentRow.Index].Selected == true)
            {
                string s2 = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
                string ComUp = " update [Users] set [Пароль] = HASHBYTES('SHA2_256','" + s2 + "') where [Никнейм] = '" + s1 + "'";
                SqlCommand cmd4 = new SqlCommand(ComUp, Connection);
                Connection.Open();
                cmd4.ExecuteNonQuery();
                Connection.Close();
            }
            else if (dataGridView1[4, dataGridView1.CurrentRow.Index].Selected == true)
            {
                string s2 = dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString();
                string ComUp = " update [Users] set [Статус] = N'" + s2 + "' where [Никнейм] = '" + s1 + "'";
                SqlCommand cmd5 = new SqlCommand(ComUp, Connection);
                Connection.Open();
                cmd5.ExecuteNonQuery();
                Connection.Close();
            }
            else if (dataGridView1[5, dataGridView1.CurrentRow.Index].Selected == true)
            {
                string s2 = dataGridView1[5, dataGridView1.CurrentRow.Index].Value.ToString();
                string ComUp = " update [Users] set [Дата регистрации] = N'" + s2 + "' where [Никнейм] = '" + s1 + "'";
                SqlCommand cmd5 = new SqlCommand(ComUp, Connection);
                Connection.Open();
                cmd5.ExecuteNonQuery();
                Connection.Close();
            }
            this.usersTableAdapter.Fill(this.курсачDataSet12.Users);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string s2 = dataGridView6[0, dataGridView6.CurrentRow.Index].Value.ToString();
            string s3 = dataGridView6[1, dataGridView6.CurrentRow.Index].Value.ToString();
            string s4 = dataGridView6[2, dataGridView6.CurrentRow.Index].Value.ToString();
            string ComAdd = " INSERT INTO [Услуги] ([ID_услуги], [Название], [Цена]) VALUES(N'" + s2 + "', N'" + s3 + "', N'" + s4 + "')";

            SqlCommand cmd2 = new SqlCommand(ComAdd, Connection);
            Connection.Open();
            cmd2.ExecuteNonQuery();
            Connection.Close();
            this.услугиTableAdapter.Fill(this.курсачDataSet5.Услуги);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int row = dataGridView6.CurrentCell.RowIndex;
            string y1 = dataGridView6[0, row].Value.ToString();
            string ComDel = " Delete from [Услуги] where [ID_услуги] = '" + y1 + "'";

            SqlCommand cmd1 = new SqlCommand(ComDel, Connection);
            Connection.Open();
            cmd1.ExecuteNonQuery();
            Connection.Close();
            this.услугиTableAdapter.Fill(this.курсачDataSet5.Услуги);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int row = dataGridView6.CurrentCell.RowIndex;
            string s1 = dataGridView6[0, row].Value.ToString();
            if (dataGridView6[0, dataGridView6.CurrentRow.Index].Selected == true)
            {
                string s2 = dataGridView6[0, dataGridView6.CurrentRow.Index].Value.ToString();
                string ComUp = " update [Услуги] set [ID_услуги] = N'" + s2 + "' where [ID_услуги] = '" + s1 + "'";
                SqlCommand cmd1 = new SqlCommand(ComUp, Connection);
                Connection.Open();
                cmd1.ExecuteNonQuery();
                Connection.Close();
            }
            else if (dataGridView6[1, dataGridView6.CurrentRow.Index].Selected == true)
            {
                string s2 = dataGridView6[1, dataGridView6.CurrentRow.Index].Value.ToString();
                string ComUp = " update [Услуги] set [Название] = '" + s2 + "' where [ID_услуги] = '" + s1 + "'";
                SqlCommand cmd2 = new SqlCommand(ComUp, Connection);
                Connection.Open();
                cmd2.ExecuteNonQuery();
                Connection.Close();
            }
            else if (dataGridView6[2, dataGridView6.CurrentRow.Index].Selected == true)
            {
                string s2 = dataGridView6[2, dataGridView6.CurrentRow.Index].Value.ToString();
                string ComUp = " update [Услуги] set [Цена] = '" + s2 + "' where [ID_услуги] = '" + s1 + "'";
                SqlCommand cmd3 = new SqlCommand(ComUp, Connection);
                Connection.Open();
                cmd3.ExecuteNonQuery();
                Connection.Close();
            }
            this.услугиTableAdapter.Fill(this.курсачDataSet5.Услуги);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string s2 = dataGridView4[0, dataGridView4.CurrentRow.Index].Value.ToString();
            string s3 = dataGridView4[1, dataGridView4.CurrentRow.Index].Value.ToString();
            string s4 = dataGridView4[2, dataGridView4.CurrentRow.Index].Value.ToString();
            string s5 = dataGridView4[3, dataGridView4.CurrentRow.Index].Value.ToString();
            string s6 = dataGridView4[4, dataGridView4.CurrentRow.Index].Value.ToString();
            string s7 = dataGridView4[5, dataGridView4.CurrentRow.Index].Value.ToString();
            string s8 = dataGridView4[6, dataGridView4.CurrentRow.Index].Value.ToString();
            string ComAdd = " INSERT INTO [Основная информация ] ([ID_оборудования], [Сотрудник], [ID_услуги], [Дата_аренды], [Время_аренды], [Клиент], [Цена]) VALUES('" + s2 + "', N'" + s3 + "', '" + s4 + "', '" + s5 + "', '" + s6 + "', N'" + s7 + "', '" + s8 + "')";

            SqlCommand cmd2 = new SqlCommand(ComAdd, Connection);
            Connection.Open();
            cmd2.ExecuteNonQuery();
            Connection.Close();
            this.основная_информацияTableAdapter.Fill(this.курсачDataSet10.Основная_информация);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int row = dataGridView4.CurrentCell.RowIndex;
            string y1 = dataGridView4[0, row].Value.ToString();
            string y2 = dataGridView4[2, row].Value.ToString();
            string y3 = dataGridView4[3, row].Value.ToString();
            string y4 = dataGridView4[5, row].Value.ToString();
            string ComDel = " Delete from [Основная информация] where [ID_оборудования] = '" + y1 + "' and [ID_услуги] = '" + y2 + "' and [Дата_аренды] = '" + y3 + "' and [Клиент] = '" + y4 + "'"; 

            SqlCommand cmd1 = new SqlCommand(ComDel, Connection);
            Connection.Open();
            cmd1.ExecuteNonQuery();
            Connection.Close();
            this.основная_информацияTableAdapter.Fill(this.курсачDataSet10.Основная_информация);
        }

        private void button11_Click(object sender, EventArgs e)
        {
          
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string s1 = dataGridView3[0, dataGridView3.CurrentRow.Index].Value.ToString();
            string s2 = dataGridView3[1, dataGridView3.CurrentRow.Index].Value.ToString();
            string s3 = dataGridView3[2, dataGridView3.CurrentRow.Index].Value.ToString();
            string s4 = dataGridView3[3, dataGridView3.CurrentRow.Index].Value.ToString();
            string s5 = dataGridView3[4, dataGridView3.CurrentRow.Index].Value.ToString();
            string s6 = dataGridView3[5, dataGridView3.CurrentRow.Index].Value.ToString();
            string s7 = dataGridView3[6, dataGridView3.CurrentRow.Index].Value.ToString();
            string s8 = dataGridView3[7, dataGridView3.CurrentRow.Index].Value.ToString();
            string s9 = dataGridView3[8, dataGridView3.CurrentRow.Index].Value.ToString();
            string ComAdd = " INSERT INTO [Оборудование] ([ID_оборудования], [Вид_оборудования], [Фирма], [Цена_оборудования], [Платформа], [Монитор/Телевизор], [Мышь], [Клавиатура], [Наушники]) VALUES('" + s1 + "', N'" + s2 + "', N'" + s3 + "', '" + s4 + "', N'" + s5 + "', N'" + s6 + "' , N'" + s7 + "', N'" + s8 + "', N'" + s9 + "')";

            SqlCommand cmd2 = new SqlCommand(ComAdd, Connection);
            Connection.Open();
            cmd2.ExecuteNonQuery();
            Connection.Close();
            this.оборудованиеTableAdapter.Fill(this.курсачDataSet2.Оборудование);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int row = dataGridView3.CurrentCell.RowIndex;
            string z1 = dataGridView3[0, row].Value.ToString();
            string ComDel = " Delete from [Оборудование] where [ID_оборудования] = '" + z1 + "'";

            SqlCommand cmd1 = new SqlCommand(ComDel, Connection);
            Connection.Open();
            cmd1.ExecuteNonQuery();
            Connection.Close();
            this.оборудованиеTableAdapter.Fill(this.курсачDataSet2.Оборудование);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            int row = dataGridView3.CurrentCell.RowIndex;
            string s1 = dataGridView3[0, row].Value.ToString();
            if (dataGridView3[0, dataGridView3.CurrentRow.Index].Selected == true)
            {
                string s2 = dataGridView3[0, dataGridView3.CurrentRow.Index].Value.ToString();
                string ComUp = " update [Оборудование] set [ID_оборудования] = N'" + s2 + "' where [ID_оборудования] = '" + s1 + "'";
                SqlCommand cmd1 = new SqlCommand(ComUp, Connection);
                Connection.Open();
                cmd1.ExecuteNonQuery();
                Connection.Close();
            }
            else if (dataGridView3[1, dataGridView3.CurrentRow.Index].Selected == true)
            {
                string s2 = dataGridView3[1, dataGridView3.CurrentRow.Index].Value.ToString();
                string ComUp = " update [Оборудование] set [Вид_оборудования] = '" + s2 + "' where [ID_оборудования] = '" + s1 + "'";
                SqlCommand cmd2 = new SqlCommand(ComUp, Connection);
                Connection.Open();
                cmd2.ExecuteNonQuery();
                Connection.Close();
            }
            else if (dataGridView3[2, dataGridView3.CurrentRow.Index].Selected == true)
            {
                string s2 = dataGridView3[2, dataGridView3.CurrentRow.Index].Value.ToString();
                string ComUp = " update [Оборудование] set [Фирма] = '" + s2 + "' where [ID_оборудования] = '" + s1 + "'";
                SqlCommand cmd3 = new SqlCommand(ComUp, Connection);
                Connection.Open();
                cmd3.ExecuteNonQuery();
                Connection.Close();
            }
            else if (dataGridView3[3, dataGridView3.CurrentRow.Index].Selected == true)
            {
                string s2 = dataGridView3[3, dataGridView3.CurrentRow.Index].Value.ToString();
                string ComUp = " update [Оборудование] set [Цена_оборудования] = '" + s2 + "' where [ID_оборудования] = '" + s1 + "'";
                SqlCommand cmd4 = new SqlCommand(ComUp, Connection);
                Connection.Open();
                cmd4.ExecuteNonQuery();
                Connection.Close();
            }
            else if (dataGridView3[4, dataGridView3.CurrentRow.Index].Selected == true)
            {
                string s2 = dataGridView3[4, dataGridView3.CurrentRow.Index].Value.ToString();
                string ComUp = " update [Оборудование] set [Платформа] = N'" + s2 + "' where [ID_оборудования] = '" + s1 + "'";
                SqlCommand cmd5 = new SqlCommand(ComUp, Connection);
                Connection.Open();
                cmd5.ExecuteNonQuery();
                Connection.Close();
            }
            else if (dataGridView3[5, dataGridView3.CurrentRow.Index].Selected == true)
            {
                string s2 = dataGridView3[5, dataGridView3.CurrentRow.Index].Value.ToString();
                string ComUp = " update [Оборудование] set [Монитор/Телевизор] = N'" + s2 + "' where [ID_оборудования] = '" + s1 + "'";
                SqlCommand cmd5 = new SqlCommand(ComUp, Connection);
                Connection.Open();
                cmd5.ExecuteNonQuery();
                Connection.Close();
            }
            else if (dataGridView3[6, dataGridView3.CurrentRow.Index].Selected == true)
            {
                string s2 = dataGridView3[6, dataGridView3.CurrentRow.Index].Value.ToString();
                string ComUp = " update [Оборудование] set [Мышь] = N'" + s2 + "' where [ID_оборудования] = '" + s1 + "'";
                SqlCommand cmd5 = new SqlCommand(ComUp, Connection);
                Connection.Open();
                cmd5.ExecuteNonQuery();
                Connection.Close();
            }
            else if (dataGridView3[7, dataGridView3.CurrentRow.Index].Selected == true)
            {
                string s2 = dataGridView3[7, dataGridView3.CurrentRow.Index].Value.ToString();
                string ComUp = " update [Оборудование] set [Клавиатура] = N'" + s2 + "' where [ID_оборудования] = '" + s1 + "'";
                SqlCommand cmd5 = new SqlCommand(ComUp, Connection);
                Connection.Open();
                cmd5.ExecuteNonQuery();
                Connection.Close();
            }
            else if (dataGridView3[8, dataGridView3.CurrentRow.Index].Selected == true)
            {
                string s2 = dataGridView3[8, dataGridView3.CurrentRow.Index].Value.ToString();
                string ComUp = " update [Оборудование] set [Наушники] = N'" + s2 + "' where [ID_оборудования] = '" + s1 + "'";
                SqlCommand cmd5 = new SqlCommand(ComUp, Connection);
                Connection.Open();
                cmd5.ExecuteNonQuery();
                Connection.Close();
            }
            this.оборудованиеTableAdapter.Fill(this.курсачDataSet2.Оборудование);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string s1 = dataGridView2[0, dataGridView2.CurrentRow.Index].Value.ToString();
            string s2 = dataGridView2[1, dataGridView2.CurrentRow.Index].Value.ToString();
            string s3 = dataGridView2[2, dataGridView2.CurrentRow.Index].Value.ToString();
            string s4 = dataGridView2[3, dataGridView2.CurrentRow.Index].Value.ToString();
            string ComAdd = " INSERT INTO [Зарплаты] ([Работник], [Оклад], [Дата], [Премия]) VALUES(N'" + s1 + "', '" + s2 + "', '" + s3 + "', '" + s4 + "')";

            SqlCommand cmd2 = new SqlCommand(ComAdd, Connection);
            Connection.Open();
            cmd2.ExecuteNonQuery();
            Connection.Close();
            this.зарплатыTableAdapter.Fill(this.курсачDataSet7.Зарплаты);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            string s1 = dataGridView7[0, dataGridView7.CurrentRow.Index].Value.ToString();
            string s2 = dataGridView7[1, dataGridView7.CurrentRow.Index].Value.ToString();
            string s3 = dataGridView7[2, dataGridView7.CurrentRow.Index].Value.ToString();
            string s4 = dataGridView7[3, dataGridView7.CurrentRow.Index].Value.ToString();
            string s5 = dataGridView7[4, dataGridView7.CurrentRow.Index].Value.ToString();
            string s6 = dataGridView7[5, dataGridView7.CurrentRow.Index].Value.ToString();
            string s7 = dataGridView7[6, dataGridView7.CurrentRow.Index].Value.ToString();
            string s8 = dataGridView7[7, dataGridView7.CurrentRow.Index].Value.ToString();
            string s9 = dataGridView7[8, dataGridView7.CurrentRow.Index].Value.ToString();
            string ComAdd = " INSERT INTO [Оборудование] ([ID_оборудования], [Вид_оборудования], [Фирма], [Цена_оборудования], [Платформа], [Монитор/Телевизор], [Мышь], [Клавиатура], [Наушники]) VALUES('" + s1 + "', N'" + s2 + "', N'" + s3 + "', '" + s4 + "', N'" + s5 + "', N'" + s6 + "' , N'" + s7 + "', N'" + s8 + "', N'" + s9 + "')";

            SqlCommand cmd2 = new SqlCommand(ComAdd, Connection);
            Connection.Open();
            cmd2.ExecuteNonQuery();
            Connection.Close();
            this.оборудованиеTableAdapter.Fill(this.курсачDataSet2.Оборудование);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            int row = dataGridView7.CurrentCell.RowIndex;
            string z1 = dataGridView7[0, row].Value.ToString();
            string ComDel = " Delete from [Оборудование] where [ID_оборудования] = '" + z1 + "'";

            SqlCommand cmd1 = new SqlCommand(ComDel, Connection);
            Connection.Open();
            cmd1.ExecuteNonQuery();
            Connection.Close();
            this.оборудованиеTableAdapter.Fill(this.курсачDataSet2.Оборудование);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            int row = dataGridView7.CurrentCell.RowIndex;
            string s1 = dataGridView7[0, row].Value.ToString();
            if (dataGridView7[0, dataGridView7.CurrentRow.Index].Selected == true)
            {
                string s2 = dataGridView7[0, dataGridView7.CurrentRow.Index].Value.ToString();
                string ComUp = " update [Оборудование] set [ID_оборудования] = N'" + s2 + "' where [ID_оборудования] = '" + s1 + "'";
                SqlCommand cmd1 = new SqlCommand(ComUp, Connection);
                Connection.Open();
                cmd1.ExecuteNonQuery();
                Connection.Close();
            }
            else if (dataGridView7[1, dataGridView7.CurrentRow.Index].Selected == true)
            {
                string s2 = dataGridView7[1, dataGridView7.CurrentRow.Index].Value.ToString();
                string ComUp = " update [Оборудование] set [Вид_оборудования] = '" + s2 + "' where [ID_оборудования] = '" + s1 + "'";
                SqlCommand cmd2 = new SqlCommand(ComUp, Connection);
                Connection.Open();
                cmd2.ExecuteNonQuery();
                Connection.Close();
            }
            else if (dataGridView7[2, dataGridView7.CurrentRow.Index].Selected == true)
            {
                string s2 = dataGridView7[2, dataGridView7.CurrentRow.Index].Value.ToString();
                string ComUp = " update [Оборудование] set [Фирма] = '" + s2 + "' where [ID_оборудования] = '" + s1 + "'";
                SqlCommand cmd3 = new SqlCommand(ComUp, Connection);
                Connection.Open();
                cmd3.ExecuteNonQuery();
                Connection.Close();
            }
            else if (dataGridView7[3, dataGridView7.CurrentRow.Index].Selected == true)
            {
                string s2 = dataGridView7[3, dataGridView7.CurrentRow.Index].Value.ToString();
                string ComUp = " update [Оборудование] set [Цена_оборудования] = '" + s2 + "' where [ID_оборудования] = '" + s1 + "'";
                SqlCommand cmd4 = new SqlCommand(ComUp, Connection);
                Connection.Open();
                cmd4.ExecuteNonQuery();
                Connection.Close();
            }
            else if (dataGridView7[4, dataGridView7.CurrentRow.Index].Selected == true)
            {
                string s2 = dataGridView7[4, dataGridView7.CurrentRow.Index].Value.ToString();
                string ComUp = " update [Оборудование] set [Платформа] = N'" + s2 + "' where [ID_оборудования] = '" + s1 + "'";
                SqlCommand cmd5 = new SqlCommand(ComUp, Connection);
                Connection.Open();
                cmd5.ExecuteNonQuery();
                Connection.Close();
            }
            else if (dataGridView7[5, dataGridView7.CurrentRow.Index].Selected == true)
            {
                string s2 = dataGridView7[5, dataGridView7.CurrentRow.Index].Value.ToString();
                string ComUp = " update [Оборудование] set [Монитор/Телевизор] = N'" + s2 + "' where [ID_оборудования] = '" + s1 + "'";
                SqlCommand cmd5 = new SqlCommand(ComUp, Connection);
                Connection.Open();
                cmd5.ExecuteNonQuery();
                Connection.Close();
            }
            else if (dataGridView7[6, dataGridView7.CurrentRow.Index].Selected == true)
            {
                string s2 = dataGridView7[6, dataGridView7.CurrentRow.Index].Value.ToString();
                string ComUp = " update [Оборудование] set [Мышь] = N'" + s2 + "' where [ID_оборудования] = '" + s1 + "'";
                SqlCommand cmd5 = new SqlCommand(ComUp, Connection);
                Connection.Open();
                cmd5.ExecuteNonQuery();
                Connection.Close();
            }
            else if (dataGridView7[7, dataGridView7.CurrentRow.Index].Selected == true)
            {
                string s2 = dataGridView7[7, dataGridView7.CurrentRow.Index].Value.ToString();
                string ComUp = " update [Оборудование] set [Клавиатура] = N'" + s2 + "' where [ID_оборудования] = '" + s1 + "'";
                SqlCommand cmd5 = new SqlCommand(ComUp, Connection);
                Connection.Open();
                cmd5.ExecuteNonQuery();
                Connection.Close();
            }
            else if (dataGridView7[8, dataGridView7.CurrentRow.Index].Selected == true)
            {
                string s2 = dataGridView7[8, dataGridView7.CurrentRow.Index].Value.ToString();
                string ComUp = " update [Оборудование] set [Наушники] = N'" + s2 + "' where [ID_оборудования] = '" + s1 + "'";
                SqlCommand cmd5 = new SqlCommand(ComUp, Connection);
                Connection.Open();
                cmd5.ExecuteNonQuery();
                Connection.Close();
            }
            this.оборудованиеTableAdapter.Fill(this.курсачDataSet2.Оборудование);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            string s2 = dataGridView8[0, dataGridView8.CurrentRow.Index].Value.ToString();
            string s3 = dataGridView8[1, dataGridView8.CurrentRow.Index].Value.ToString();
            string s4 = dataGridView8[2, dataGridView8.CurrentRow.Index].Value.ToString();
            string s5 = dataGridView8[3, dataGridView8.CurrentRow.Index].Value.ToString();
            string s6 = dataGridView8[4, dataGridView8.CurrentRow.Index].Value.ToString();
            string s7 = dataGridView8[5, dataGridView8.CurrentRow.Index].Value.ToString();
            string s8 = dataGridView8[6, dataGridView8.CurrentRow.Index].Value.ToString();
            string ComAdd = " INSERT INTO [Основная информация ] ([ID_оборудования], [Сотрудник], [ID_услуги], [Дата_аренды], [Время_аренды], [Клиент], [Цена]) VALUES('" + s2 + "', N'" + s3 + "', '" + s4 + "', '" + s5 + "', '" + s6 + "', N'" + s7 + "', '" + s8 + "')";

            SqlCommand cmd2 = new SqlCommand(ComAdd, Connection);
            Connection.Open();
            cmd2.ExecuteNonQuery();
            Connection.Close();
            this.основная_информацияTableAdapter.Fill(this.курсачDataSet10.Основная_информация);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            int row = dataGridView8.CurrentCell.RowIndex;
            string y1 = dataGridView8[0, row].Value.ToString();
            string y2 = dataGridView8[2, row].Value.ToString();
            string y3 = dataGridView8[3, row].Value.ToString();
            string y4 = dataGridView8[5, row].Value.ToString();
            string ComDel = " Delete from [Основная информация] where [ID_оборудования] = '" + y1 + "' and [ID_услуги] = '" + y2 + "' and [Дата_аренды] = '" + y3 + "' and [Клиент] = '" + y4 + "'";

            SqlCommand cmd1 = new SqlCommand(ComDel, Connection);
            Connection.Open();
            cmd1.ExecuteNonQuery();
            Connection.Close();
            this.основная_информацияTableAdapter.Fill(this.курсачDataSet10.Основная_информация);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            string s2 = dataGridView10[0, dataGridView10.CurrentRow.Index].Value.ToString();
            string s3 = dataGridView10[1, dataGridView10.CurrentRow.Index].Value.ToString();
            string s4 = dataGridView10[2, dataGridView10.CurrentRow.Index].Value.ToString();
            string ComAdd = " INSERT INTO [Услуги] ([ID_услуги], [Название], [Цена]) VALUES(N'" + s2 + "', N'" + s3 + "', N'" + s4 + "')";

            SqlCommand cmd2 = new SqlCommand(ComAdd, Connection);
            Connection.Open();
            cmd2.ExecuteNonQuery();
            Connection.Close();
            this.услугиTableAdapter.Fill(this.курсачDataSet5.Услуги);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            int row = dataGridView10.CurrentCell.RowIndex;
            string y1 = dataGridView10[0, row].Value.ToString();
            string ComDel = " Delete from [Услуги] where [ID_услуги] = '" + y1 + "'";

            SqlCommand cmd1 = new SqlCommand(ComDel, Connection);
            Connection.Open();
            cmd1.ExecuteNonQuery();
            Connection.Close();
            this.услугиTableAdapter.Fill(this.курсачDataSet5.Услуги);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            int row = dataGridView10.CurrentCell.RowIndex;
            string s1 = dataGridView10[0, row].Value.ToString();
            if (dataGridView10[0, dataGridView10.CurrentRow.Index].Selected == true)
            {
                string s2 = dataGridView10[0, dataGridView10.CurrentRow.Index].Value.ToString();
                string ComUp = " update [Услуги] set [ID_услуги] = N'" + s2 + "' where [ID_услуги] = '" + s1 + "'";
                SqlCommand cmd1 = new SqlCommand(ComUp, Connection);
                Connection.Open();
                cmd1.ExecuteNonQuery();
                Connection.Close();
            }
            else if (dataGridView10[1, dataGridView10.CurrentRow.Index].Selected == true)
            {
                string s2 = dataGridView10[1, dataGridView10.CurrentRow.Index].Value.ToString();
                string ComUp = " update [Услуги] set [Название] = '" + s2 + "' where [ID_услуги] = '" + s1 + "'";
                SqlCommand cmd2 = new SqlCommand(ComUp, Connection);
                Connection.Open();
                cmd2.ExecuteNonQuery();
                Connection.Close();
            }
            else if (dataGridView10[2, dataGridView10.CurrentRow.Index].Selected == true)
            {
                string s2 = dataGridView10[2, dataGridView10.CurrentRow.Index].Value.ToString();
                string ComUp = " update [Услуги] set [Цена] = '" + s2 + "' where [ID_услуги] = '" + s1 + "'";
                SqlCommand cmd3 = new SqlCommand(ComUp, Connection);
                Connection.Open();
                cmd3.ExecuteNonQuery();
                Connection.Close();
            }
            this.услугиTableAdapter.Fill(this.курсачDataSet5.Услуги);
        }

        private void button27_Click(object sender, EventArgs e)
        {

            string s2 = dataGridView5[0, dataGridView5.CurrentRow.Index].Value.ToString();
            string s3 = dataGridView5[1, dataGridView5.CurrentRow.Index].Value.ToString();
            string s4 = dataGridView5[2, dataGridView5.CurrentRow.Index].Value.ToString();
            string s5 = dataGridView5[3, dataGridView5.CurrentRow.Index].Value.ToString();
            string s6 = dataGridView5[4, dataGridView5.CurrentRow.Index].Value.ToString();
            string s7 = dataGridView5[5, dataGridView5.CurrentRow.Index].Value.ToString();
            string ComAdd = " INSERT INTO [Users] ([Никнейм], [ФИО], [Роль], [Пароль], [Статус], [Дата регистрации]) VALUES(N'" + s2 + "', N'" + s3 + "', N'" + s4 + "', HASHBYTES('SHA2_256','" + s5 + "'), N'" + s6 + "', '" + s7 + "')";

            SqlCommand cmd2 = new SqlCommand(ComAdd, Connection);
            Connection.Open();
            cmd2.ExecuteNonQuery();
            Connection.Close();
            this.usersTableAdapter.Fill(this.курсачDataSet12.Users);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            int row = dataGridView5.CurrentCell.RowIndex;
            string x1 = dataGridView5[0, row].Value.ToString();
            string ComDel = " Delete from [Users] where [Никнейм] = '" + x1 + "'";

            SqlCommand cmd1 = new SqlCommand(ComDel, Connection);
            Connection.Open();
            cmd1.ExecuteNonQuery();
            Connection.Close();
            this.usersTableAdapter.Fill(this.курсачDataSet12.Users);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            int row = dataGridView5.CurrentCell.RowIndex;
            string s1 = dataGridView5[0, row].Value.ToString();
            if (dataGridView5[1, dataGridView5.CurrentRow.Index].Selected == true)
            {
                string s2 = dataGridView5[1, dataGridView5.CurrentRow.Index].Value.ToString();
                string ComUp = " update [Users] set [ФИО] = '" + s2 + "' where [Никнейм] = '" + s1 + "'";
                SqlCommand cmd2 = new SqlCommand(ComUp, Connection);
                Connection.Open();
                cmd2.ExecuteNonQuery();
                Connection.Close();
            }
            else if (dataGridView5[2, dataGridView5.CurrentRow.Index].Selected == true)
            {
                string s2 = dataGridView5[2, dataGridView5.CurrentRow.Index].Value.ToString();
                string ComUp = " update [Users] set [Роль] = '" + s2 + "' where [Никнейм] = '" + s1 + "'";
                SqlCommand cmd3 = new SqlCommand(ComUp, Connection);
                Connection.Open();
                cmd3.ExecuteNonQuery();
                Connection.Close();
            }
            else if (dataGridView5[3, dataGridView5.CurrentRow.Index].Selected == true)
            {
                string s2 = dataGridView5[3, dataGridView5.CurrentRow.Index].Value.ToString();
                string ComUp = " update [Users] set [Пароль] = HASHBYTES('SHA2_256','" + s2 + "') where [Никнейм] = '" + s1 + "'";
                SqlCommand cmd4 = new SqlCommand(ComUp, Connection);
                Connection.Open();
                cmd4.ExecuteNonQuery();
                Connection.Close();
            }
            else if (dataGridView5[4, dataGridView5.CurrentRow.Index].Selected == true)
            {
                string s2 = dataGridView5[4, dataGridView5.CurrentRow.Index].Value.ToString();
                string ComUp = " update [Users] set [Статус] = N'" + s2 + "' where [Никнейм] = '" + s1 + "'";
                SqlCommand cmd5 = new SqlCommand(ComUp, Connection);
                Connection.Open();
                cmd5.ExecuteNonQuery();
                Connection.Close();
            }
            else if (dataGridView5[5, dataGridView5.CurrentRow.Index].Selected == true)
            {
                string s2 = dataGridView5[5, dataGridView5.CurrentRow.Index].Value.ToString();
                string ComUp = " update [Users] set [Дата регистрации] = N'" + s2 + "' where [Никнейм] = '" + s1 + "'";
                SqlCommand cmd5 = new SqlCommand(ComUp, Connection);
                Connection.Open();
                cmd5.ExecuteNonQuery();
                Connection.Close();
            }
            this.usersTableAdapter.Fill(this.курсачDataSet12.Users);
        }
    }
}
