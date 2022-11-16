using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_Application
{
    internal class CRUD
    {
        private static SqlConnection connection = new SqlConnection(DataSource.DS);

        public static void Create(int id, string Name, string Address, int Salary)
        {
            try
            {


                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("insert into Student (id,Name,Address,Salary) values('" + id + "','" + Name + "','" + Address + "','" + Salary + "')", connection);
                sqlCommand.ExecuteNonQuery();
                connection.Close();



            }
            catch
            {
                MessageBox.Show("Something went wrong! Please try again", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }


        public static void Delete(int id)
        {
            try
            {


                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("delete teacher where id=(" + id + ")", connection);
                sqlCommand.ExecuteNonQuery();
                connection.Close();


            }
            catch
            {
                MessageBox.Show("Something went wrong! Please try again", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }


        public static void Update(int id, string Name, string Address, int Salary)
        {
            try
            {


                connection.Open();
                int id_new=Int32.Parse(id.ToString());
                SqlCommand sqlCommand = new SqlCommand("Update teacher where id ='" + id + "', Name = '" + Name + "',Address='" + Address + "',Salary='" + Salary + "' where id =" + id_new + "", connection);
                sqlCommand.ExecuteNonQuery();
                connection.Close();


            }
            catch
            {


                MessageBox.Show("Something went wrong! Please try again", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }
    }
}
