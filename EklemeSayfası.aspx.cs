using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yazlab1_3.v._1
{
    public partial class EklemeSayfası : System.Web.UI.Page
    {
        public string query, constr;
        public MySqlCommand com;
        public SqlConnection con;
        public MySqlConnection mysqlbaglan = new MySqlConnection("Server=localhost;Database=web;Uid=root;Pwd='123456';");
        MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
        MySqlConnection MyCon;

        int x;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void connection()
        {

            conn_string.Server = "localhost";
            conn_string.Port = 3306;
            conn_string.UserID = "root";
            conn_string.Password = "123456";
            conn_string.Database = "web";
            MyCon = new MySqlConnection(conn_string.ToString());

            MyCon.Open();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            connection();

            query = "insert into kullanici (username,psw,file_id,yetki)" + " values (@username, @psw,@file_id,@yetki)"; //insert query  
            com = new MySqlCommand(query, MyCon);
            com.Parameters.Add("@file_id", MySqlDbType.VarChar).Value = 0;
            com.Parameters.Add("@username", MySqlDbType.VarChar).Value = TextBox2.Text;
            com.Parameters.Add("@psw", MySqlDbType.VarChar).Value = TextBox3.Text;
            com.Parameters.Add("@yetki", MySqlDbType.VarChar).Value = 0;
            com.ExecuteNonQuery();

            Response.Redirect("yonetim.aspx");
        }
    }
}