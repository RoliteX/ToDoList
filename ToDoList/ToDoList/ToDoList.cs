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
using System.Data.Sql;

namespace ToDoList
{
    public partial class ToDoList : Form
    {
        public ToDoList()
        {
            InitializeComponent();
        }

        Connection connect = new Connection();

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Deleted dlt = new Deleted();
            dlt.Show();
        }

        void List()
        {
            SqlConnection conn = new SqlConnection(connect.Adress);
            conn.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_List", conn);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void ToDoList_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connect.Adress);
            conn.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_List", conn);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add add = new Add();
            add.Show();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int selected = dataGridView1.SelectedCells[0].RowIndex;
            TxtID.Text = dataGridView1.Rows[selected].Cells[0].Value.ToString();
            RchToDo.Text = dataGridView1.Rows[selected].Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connect.Adress);
            conn.Open();
            SqlCommand add = new SqlCommand("insert into Tbl_Deleted (Deleted) values (@p1)", conn);
            add.Parameters.AddWithValue("@p1", RchToDo.Text);
            add.ExecuteNonQuery();
            conn.Close();

            conn.Open();
            SqlCommand delete = new SqlCommand("Delete From Tbl_List where ID = @p1", conn);
            delete.Parameters.AddWithValue("@p1", TxtID.Text);
            delete.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("To Do Deleted!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            List();
            TxtID.Clear();
            RchToDo.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List();
        }
    }
}
