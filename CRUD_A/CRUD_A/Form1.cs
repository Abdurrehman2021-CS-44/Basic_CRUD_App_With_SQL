using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CRUD_A
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into student values (@ID, @S_Name, @Department)", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(txtId.Text));
            cmd.Parameters.AddWithValue("@S_Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Department", txtDep.Text);
            cmd.ExecuteNonQuery();
            clearFields();
            BindData();
        }

        private void btnRet_Click(object sender, EventArgs e)
        {
            BindData();
        }
        private void clearFields() 
        {
            txtId.Clear();
            txtName.Clear();
            txtDep.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("DELETE from student WHERE ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(txtId.Text));
            cmd.ExecuteNonQuery();
            clearFields();
            BindData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Update student SET S_Name=@S_Name, Department=@Department WHERE ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(txtId.Text));
            cmd.Parameters.AddWithValue("@S_Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Department", txtDep.Text);
            cmd.ExecuteNonQuery();
            clearFields();
            BindData();
        }

        private void BindData() 
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select ID, S_Name As Name, Department from student", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewStudents.DataSource = dt;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT ID, S_Name As Name, Department FROM student WHERE ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(txtId.Text));
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewStudents.DataSource = dt;
            clearFields();
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (char.IsDigit(c))
            {
                e.Handled = false;
            }
            else if (c == 8)
            {
                e.Handled = false;
            }
            else 
            {
                e.Handled = true;
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (char.IsLetter(c)) 
            { 
                e.Handled = false;
            }
            else if (c == 8) 
            {
                e.Handled = false;
            }
            else if (c == 32) 
            {
                e.Handled = false;
            }
            else 
            {
                e.Handled = true;
            }
        }

        private void txtDep_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (char.IsLetter(c))
            {
                e.Handled = false;
            }
            else if (c == 8)
            {
                e.Handled = false;
            }
            else if (c == 32)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
