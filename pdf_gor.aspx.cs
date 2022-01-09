using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
namespace yazlab1_3.v._1
{
    public partial class pdf_gor : System.Web.UI.Page
    {

        public string query, constr;
        public MySqlCommand com;
        public SqlConnection con;
        public MySqlConnection mysqlbaglan = new MySqlConnection("Server=localhost;Database=web;Uid=root;Pwd='123456';");
        MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
        MySqlConnection MyCon;
        int pdf_id;
        int Kullanici_id;
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
        private void rep_bind()
        {
            connection();
            //string query = "select * from web.kullanici where * LIKE '%"+TextBox1.Text+"%'";

            string query = "select DISTINCT pdf.name from web.pdf ";
            //string query = "SELECT * from web.kullanici,web.pdf where kullanici.id = '8' and kullanici.file_id = pdf.id";
            //string query = "SELECT * from web.kullanici";
            MySqlDataAdapter da = new MySqlDataAdapter(query, MyCon);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            MyCon.Close();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            connection();


            string query = "select DISTINCT pdf.name from web.pdf ";
          //  Label2.Text = "select pdf.data from web.kullanici,web.pdf where kullanici.id = '" + Kullanici_id + "'and kullanici.file_id=pdf.id";
            MySqlCommand com = new MySqlCommand(query, MyCon);

            MySqlDataReader dr;
            dr = com.ExecuteReader();


            if (dr.HasRows)
            {
                dr.Read();
                rep_bind();
                GridView1.Visible = true;
                //filename=dr.GetString(0);
            //    Label2.Text = "" + dr.GetString(0);
            }
            else
            {
                GridView1.Visible = false;
              //  Label2.Visible = true;

            }
            MyCon.Close();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            connection();

            string filename = "";
            string query = "select DISTINCT pdf.name from web.pdf ";
            MySqlCommand com = new MySqlCommand(query, MyCon);

            MySqlDataReader dr;
            dr = com.ExecuteReader();


            if (dr.HasRows)
            {
                dr.Read();

                filename = dr.GetString(0);
             
            }


            MyCon.Close();


            string dosyayolu = "//PDFFileUploadDownLoad//" + filename;
            string filepath = Server.MapPath(dosyayolu);
            WebClient user = new WebClient();
            Byte[] FileBuffer = user.DownloadData(filepath);
            if (FileBuffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("count-length", FileBuffer.Length.ToString());
                Response.BinaryWrite(FileBuffer);
            }
        }
    }
}