using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace ToDoList
{
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
        }

        Connection connect = new Connection();

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("This place cannot be left blank!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlConnection conn = new SqlConnection(connect.Adress);
                conn.Open();
                SqlCommand add = new SqlCommand("insert into Tbl_List (TODO) values (@a1)", conn);
                add.Parameters.AddWithValue("@a1", richTextBox1.Text);
                add.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Added to To-Do!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
