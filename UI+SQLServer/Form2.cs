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

namespace UI_SQLServer
{
    public partial class Form2 : Form
    {
        int rows = 0;
        public Form2()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        Boolean SqlComExec(string s)
        {
            if (s.Length > 0)
            {
                try
                {
                    string _connectionString = @"Data Source=JOUD\INSTANCE_2K19_01;Initial Catalog=mydb;Integrated Security=True";

                    using (SqlConnection _con = new SqlConnection(_connectionString))
                    {
                        _con.Open();
                        string queryStatement = s;
                        using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
                        {
                            _cmd.ExecuteNonQuery();
                            rows++;
                        }
                    }
                    MessageBox.Show("Done");
                    return true;
                }
                catch
                {
                    MessageBox.Show("Enter a Correct Statement Please");
                }
            }
            return false;
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string _connectionString = @"Data Source=JOUD\INSTANCE_2K19_01;Initial Catalog=mydb;Integrated Security=True";

            using (SqlConnection _con = new SqlConnection(_connectionString))
            {
                _con.Open();
                string queryStatement = "INSERT INTO mydb.dbo.video(title,video_desc,genre,langue)VALUES('" + txt_add_title.Text.ToString() + "','" + txt_add_description.Text.ToString() + "', '" + txt_add_genre.Text.ToString() + "','" + txt_add_language.Text.ToString() + "')";
                
                using (SqlCommand _cmd  = new SqlCommand(queryStatement, _con))
                {
                    _cmd.ExecuteNonQuery();
                    rows++;
                }
            }
            txt_add_title.Text = "";
            txt_add_description.Text = "";
            txt_add_genre.Text = "";
            txt_add_language.Text = "";
            lb_rows_affected.Text = rows.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string _connectionString = @"Data Source=JOUD\INSTANCE_2K19_01;Initial Catalog=mydb;Integrated Security=True";
            using (SqlConnection _con = new SqlConnection(_connectionString))
            {
                _con.Open();
                string queryStatement = "DELETE FROM mydb.dbo.video WHERE(title ='" + txt_delete_title.Text.ToString() + "')";
                
                using (SqlCommand _cmd = new SqlCommand(queryStatement, _con))
                {
                    _cmd.ExecuteNonQuery();
                    rows++;
                }
            }
            txt_delete_title.Text = "";
            lb_rows_affected.Text = rows.ToString();
        }

        private void excute_Click(object sender, EventArgs e)
        {

            SqlComExec(txt_command.Text);
            txt_command.Text = "";
        }
    }
}
