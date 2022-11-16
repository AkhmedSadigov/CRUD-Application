using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CRUD_Application.CRUD;

namespace CRUD_Application
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        SqlConnection conn;
        SqlCommand cmd;
        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection("Data Source=LAPTOP-D0D6I3G9\\SQLEXPRESS;Initial Catalog=school;Integrated Security=True");
            cmd = new SqlCommand();
            cmd.Connection = conn;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string query = $"insert into teacher values('{txtId.Text.ToString()}','{txtName.Text}','{txtAddress.Text}','{txtSalary.Text.ToString()}')";
            cmd.CommandText= query;
            conn.Open();
            cmd.ExecuteNonQuery();
            cleardata();
            conn.Close();
            displaydata();
        }

        private void cleardata()
        {
            txtId.Clear();
            txtName.Clear();
            txtAddress.Clear();
            txtSalary.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd=conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update teacher set name='" + txtName.Text + "',Address='" + txtAddress.Text + "',Salary='" + txtSalary.Text + "'where id='" + txtId.Text.ToString()+"' ";
            cmd.ExecuteNonQuery();
            conn.Close();
            displaydata();
            cleardata();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            displaydata();
        }

        private void displaydata()
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from teacher";
            cmd.ExecuteNonQuery();
            DataTable dt=new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView.DataSource = dt;
            conn.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string query = $"delete teacher where id='{txtId.Text.ToString()}'";
            cmd.CommandText=query;
            conn.Open();
            cmd.ExecuteNonQuery();
            dataGridView.DataSource=query;
            cleardata();
            conn.Close();
            displaydata();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}