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
    public partial class Deleted : Form
    {
        public Deleted()
        {
            InitializeComponent();
        }

        Connection connect = new Connection();

        private void Deleted_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connect.Adress);
            conn.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Deleted", conn);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
    }
}
