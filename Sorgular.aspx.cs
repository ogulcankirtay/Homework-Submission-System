using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;

namespace yazlab1_3.v._1
{
    public partial class Sorgular : System.Web.UI.Page
    {
        public SqlConnection con;
        public string constr;

        public string query;
        public MySqlCommand com;
        public MySqlConnection mysqlbaglan = new MySqlConnection("Server=localhost;Database=web;Uid=root;Pwd='123456';");
        MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
        MySqlConnection MyCon;



        public void connection()
        {
            //constr = ConfigurationManager.ConnectionStrings["emp"].ToString();
            //con = new SqlConnection(constr);

            conn_string.Server = "localhost";
            conn_string.Port = 3306;
            conn_string.UserID = "root";
            conn_string.Password = "123456";
            conn_string.Database = "web";
            MyCon = new MySqlConnection(conn_string.ToString());


            MyCon.Open();

        }

        protected void Page_Load(object sender, EventArgs e)
        {

            Label1.Visible = false;


        }

        private void rep_bind()
        {
            connection();
            //string query = "select * from web.kullanici where * LIKE '%"+TextBox1.Text+"%'";
            string query = "select * from web.kullanici where username LIKE '%" + TextBox1.Text + "%' or psw LIKE '%" + TextBox1.Text + "%' or file_id LIKE '" + TextBox1.Text + "' or id LIKE '" + TextBox1.Text + "'";



            MySqlDataAdapter da = new MySqlDataAdapter(query, MyCon);



            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();

            MyCon.Close();

        }
        private void rep_bind_yazar()
        {
            connection();
            //string query = "select * from web.kullanici where * LIKE '%"+TextBox1.Text+"%'";
            string query = "SELECT DISTINCT yazar.id,yazar.ad_soyad,yazar.ogr_no,yazar.ogr_tur,yazar.pdf_id FROM anahtar, danisman, juri, pdf, yazar, kullanici " +
                "WHERE yazar.id LIKE '" + TextBox1.Text + "' or yazar.ad_soyad LIKE '%" + TextBox1.Text + "%' or yazar.ogr_no LIKE '%" + TextBox1.Text + "%' or yazar.ogr_tur LIKE '%" + TextBox1.Text + "%' or yazar.pdf_id LIKE '%" + TextBox1.Text + "%'";



            MySqlDataAdapter da = new MySqlDataAdapter(query, MyCon);

            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView2.DataSource = ds;
            GridView2.DataBind();
            MyCon.Close();

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            connection();
            //string query = "select * from web.kullanici where * LIKE '%" + TextBox1.Text + "%'";
            string query = "select * from web.kullanici where username LIKE '%" + TextBox1.Text + "%' or psw LIKE '%" + TextBox1.Text + "%' or file_id LIKE '" + TextBox1.Text + "' or id LIKE '" + TextBox1.Text + "'";
            //string query = "SELECT * FROM anahtar, danisman, juri, pdf, yazar, kullanici " +
            //    "WHERE kullanici.id = kullanici.id and kullanici.file_id = pdf.id and kullanici.file_id = danisman.pdf_id " +
            //    "and kullanici.file_id = anahtar.pdf_id and kullanici.file_id = juri.pdf_id and kullanici.file_id = yazar.pdf_id; ";


            MySqlCommand com = new MySqlCommand(query, MyCon);

            //com.Parameters.AddWithValue("kullanici", TextBox1.Text);
            //'" + TextBox1.Text + "%'"

            MySqlDataReader dr;
            dr = com.ExecuteReader();


            if (dr.HasRows)
            {
                dr.Read();
                rep_bind();
                GridView1.Visible = true;
                TextBox1.Text = "";
                Label1.Text = "";
            }
            else
            {
                GridView1.Visible = false;
                Label1.Visible = true;
                Label1.Text = "The search Term " + TextBox1.Text + " &nbsp;Is Not Available in the Records"; ;

            }
            MyCon.Close();


        }
        protected void Button_Yazar_Click1(object sender, EventArgs e)
        {
            connection();
            string query = "SELECT DISTINCT yazar.id,yazar.ad_soyad,yazar.ogr_no,yazar.ogr_tur,yazar.pdf_id FROM anahtar, danisman, juri, pdf, yazar, kullanici " +
                "WHERE yazar.id LIKE '" + TextBox1.Text + "' or yazar.ad_soyad LIKE '%" + TextBox1.Text + "%' " +
                "or yazar.ogr_no LIKE '%" + TextBox1.Text + "%' or yazar.ogr_tur LIKE '%" + TextBox1.Text + "%' " +
                "or yazar.pdf_id LIKE '%" + TextBox1.Text + "%'";


            MySqlCommand com = new MySqlCommand(query, MyCon);


            MySqlDataReader dr;
            dr = com.ExecuteReader();


            if (dr.HasRows)
            {
                dr.Read();
                rep_bind_yazar();
                GridView2.Visible = true;
                TextBox1.Text = "";
                Label1.Text = "";
            }
            else
            {
                GridView2.Visible = false;
                Label1.Visible = true;
                Label1.Text = "The search Term " + TextBox1.Text + " &nbsp;Is Not Available in the Records"; ;

            }
            MyCon.Close();
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }


        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void rep_bind_ders()
        {
            connection();
            //string query = "select * from web.kullanici where * LIKE '%"+TextBox1.Text+"%'";
            string query = "SELECT DISTINCT pdf.id,pdf.Name,pdf.type,pdf.Data,pdf.Ders_adı,pdf.donem " +
                "FROM anahtar, danisman, juri, pdf, yazar, kullanici " +
                "WHERE pdf.id LIKE '" + TextBox1.Text + "' or pdf.Name LIKE '%onuryazar%' or pdf.type LIKE '%" + TextBox1.Text + "%' or pdf.Data LIKE '%" + TextBox1.Text + "%' " +
                "or pdf.Ders_adı LIKE '%" + TextBox1.Text + "%' or pdf.donem LIKE '%" + TextBox1.Text + "%'";


            MySqlDataAdapter da = new MySqlDataAdapter(query, MyCon);

            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView2.DataSource = ds;
            GridView2.DataBind();
            MyCon.Close();

        }

        protected void Button_Ders_Click(object sender, EventArgs e)
        {
            connection();
            string query = "SELECT DISTINCT pdf.id,pdf.Name,pdf.type,pdf.Data,pdf.Ders_adı,pdf.donem " +
                "FROM anahtar, danisman, juri, pdf, yazar, kullanici " +
                "WHERE pdf.id LIKE '" + TextBox1.Text + "' or pdf.Name LIKE '%" + TextBox1.Text + "%' or pdf.type LIKE '%" + TextBox1.Text + "%' or pdf.Data LIKE '%" + TextBox1.Text + "%' " +
                "or pdf.Ders_adı LIKE '%" + TextBox1.Text + "%' or pdf.donem LIKE '%" + TextBox1.Text + "%'";


            MySqlCommand com = new MySqlCommand(query, MyCon);


            MySqlDataReader dr;
            dr = com.ExecuteReader();


            if (dr.HasRows)
            {
                dr.Read();
                rep_bind_ders();
                GridView3.Visible = true;
                TextBox1.Text = "";
                Label1.Text = "";
            }
            else
            {
                GridView3.Visible = false;
                Label1.Visible = true;
                Label1.Text = "The search Term " + TextBox1.Text + " &nbsp;Is Not Available in the Records"; ;

            }
            MyCon.Close();
        }

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void rep_bind_proje()
        {
            connection();
            string query = "SELECT DISTINCT pdf.id,pdf.Name,pdf.type,pdf.Data,pdf.Ders_adı,pdf.donem,pdf.ozet,pdf.proje_adı " +
                "FROM anahtar, danisman, juri, pdf, yazar, kullanici " +
                "WHERE pdf.id LIKE '" + TextBox1.Text + "' or pdf.Name LIKE '%" + TextBox1.Text + "%' or pdf.type LIKE '%" + TextBox1.Text + "%' or pdf.Data LIKE '%" + TextBox1.Text + "%' " +
                "or pdf.Ders_adı LIKE '%" + TextBox1.Text + "%' or pdf.donem LIKE '%" + TextBox1.Text + "%'" +
                "or pdf.ozet LIKE '%" + TextBox1.Text + "%' or pdf.proje_adı LIKE '%" + TextBox1.Text + "%'";


            MySqlDataAdapter da = new MySqlDataAdapter(query, MyCon);

            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView4.DataSource = ds;
            GridView4.DataBind();
            MyCon.Close();

        }

        protected void Button_proje_Click(object sender, EventArgs e)
        {
            connection();
            string query = "SELECT DISTINCT pdf.id,pdf.Name,pdf.type,pdf.Data,pdf.Ders_adı,pdf.donem,pdf.ozet,pdf.proje_adı " +
                "FROM anahtar, danisman, juri, pdf, yazar, kullanici " +
                "WHERE pdf.id LIKE '" + TextBox1.Text + "' or pdf.Name LIKE '%" + TextBox1.Text + "%' or pdf.type LIKE '%" + TextBox1.Text + "%' or pdf.Data LIKE '%" + TextBox1.Text + "%' " +
                "or pdf.Ders_adı LIKE '%" + TextBox1.Text + "%' or pdf.donem LIKE '%" + TextBox1.Text + "%'" +
                "or pdf.ozet LIKE '%" + TextBox1.Text + "%' or pdf.proje_adı LIKE '%" + TextBox1.Text + "%'";


            MySqlCommand com = new MySqlCommand(query, MyCon);


            MySqlDataReader dr;
            dr = com.ExecuteReader();


            if (dr.HasRows)
            {
                dr.Read();
                rep_bind_ders();
                GridView4.Visible = true;
                TextBox1.Text = "";
                Label1.Text = "";
            }
            else
            {
                GridView4.Visible = false;
                Label1.Visible = true;
                Label1.Text = "The search Term " + TextBox1.Text + " &nbsp;Is Not Available in the Records"; ;

            }
            MyCon.Close();
        }

        protected void GridView4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        /*
        protected void Button2_Click(object sender, EventArgs e)
        {
            connection();
            string query = "SELECT DISTINCT pdf.id,pdf.Name,pdf.type,pdf.Data,pdf.Ders_adı,pdf.donem,pdf.ozet,pdf.proje_adı " +
                "FROM anahtar, danisman, juri, pdf, yazar, kullanici " +
                "WHERE pdf.id LIKE '" + TextBox1.Text + "' or pdf.Name LIKE '%" + TextBox1.Text + "%' or pdf.type LIKE '%" + TextBox1.Text + "%' or pdf.Data LIKE '%" + TextBox1.Text + "%' " +
                "or pdf.Ders_adı LIKE '%" + TextBox1.Text + "%' or pdf.donem LIKE '%" + TextBox1.Text + "%'" +
                "or pdf.ozet LIKE '%" + TextBox1.Text + "%' or pdf.proje_adı LIKE '%" + TextBox1.Text + "%'";


            MySqlCommand com = new MySqlCommand(query, MyCon);


            MySqlDataReader dr;
            dr = com.ExecuteReader();


            if (dr.HasRows)
            {
                dr.Read();
                rep_bind_ders();
                GridView4.Visible = true;
                TextBox1.Text = "";
                Label1.Text = "";
            }
            else
            {
                GridView4.Visible = false;
                Label1.Visible = true;
                Label1.Text = "The search Term " + TextBox1.Text + " &nbsp;Is Not Available in the Records"; ;

            }
            MyCon.Close();
        }*/
        private void rep_bind_anahtar()
        {
            connection();
            string query = "SELECT DISTINCT anahtar.id,anahtar.name,anahtar.pdf_id " +
                "FROM anahtar, danisman, juri, pdf, yazar, kullanici" +
                "WHERE anahtar.id LIKE '%" + TextBox1.Text + "%' or anahtar.name LIKE '%" + TextBox1.Text + "%' " +
                "or anahtar.pdf_id LIKE '%" + TextBox1.Text + "%'";


            MySqlDataAdapter da = new MySqlDataAdapter(query, MyCon);

            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView5.DataSource = ds;
            GridView5.DataBind();
            MyCon.Close();

        }

        protected void GridView5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button_Anahtar_Click(object sender, EventArgs e)
        {
            connection();
            string query = "SELECT DISTINCT anahtar.id,anahtar.name,anahtar.pdf_id " +
                "FROM anahtar, danisman, juri, pdf, yazar, kullanici " +
                "WHERE anahtar.id LIKE '%" + TextBox1.Text + "%' or anahtar.name LIKE '%" + TextBox1.Text + "%' " +
                "or anahtar.pdf_id LIKE '%" + TextBox1.Text + "%'";


            MySqlCommand com = new MySqlCommand(query, MyCon);


            MySqlDataReader dr;
            dr = com.ExecuteReader();


            if (dr.HasRows)
            {
                dr.Read();
                rep_bind_ders();
                GridView5.Visible = true;
                TextBox1.Text = "";
                Label1.Text = "";
            }
            else
            {
                GridView5.Visible = false;
                Label1.Visible = true;
                Label1.Text = "The search Term " + TextBox1.Text + " &nbsp;Is Not Available in the Records"; ;

            }
            MyCon.Close();
        }

        protected void GridView5_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void GridView6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void rep_bind_donem()
        {
            connection();
            string query = "SELECT DISTINCT pdf.id,pdf.Name,pdf.type,pdf.Data,pdf.Ders_adı,pdf.donem,pdf.ozet,pdf.proje_adı " +
                "FROM anahtar, danisman, juri, pdf, yazar, kullanici " +
                "WHERE pdf.id LIKE '" + TextBox1.Text + "' or pdf.Name LIKE '%" + TextBox1.Text + "%' or pdf.type LIKE '%" + TextBox1.Text + "%' or pdf.Data LIKE '%" + TextBox1.Text + "%' " +
                "or pdf.Ders_adı LIKE '%" + TextBox1.Text + "%' or pdf.donem LIKE '%" + TextBox1.Text + "%'" +
                "or pdf.ozet LIKE '%" + TextBox1.Text + "%' or pdf.proje_adı LIKE '%" + TextBox1.Text + "%'";


            MySqlDataAdapter da = new MySqlDataAdapter(query, MyCon);

            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView6.DataSource = ds;
            GridView6.DataBind();
            MyCon.Close();

        }

        protected void Button_Donem_Click(object sender, EventArgs e)
        {

            connection();
            string query = "SELECT DISTINCT pdf.id,pdf.Name,pdf.type,pdf.Data,pdf.Ders_adı,pdf.donem,pdf.ozet,pdf.proje_adı " +
                "FROM anahtar, danisman, juri, pdf, yazar, kullanici " +
                "WHERE pdf.id LIKE '" + TextBox1.Text + "' or pdf.Name LIKE '%" + TextBox1.Text + "%' or pdf.type LIKE '%" + TextBox1.Text + "%' or pdf.Data LIKE '%" + TextBox1.Text + "%' " +
                "or pdf.Ders_adı LIKE '%" + TextBox1.Text + "%' or pdf.donem LIKE '%" + TextBox1.Text + "%'" +
                "or pdf.ozet LIKE '%" + TextBox1.Text + "%' or pdf.proje_adı LIKE '%" + TextBox1.Text + "%'";


            MySqlCommand com = new MySqlCommand(query, MyCon);


            MySqlDataReader dr;
            dr = com.ExecuteReader();


            if (dr.HasRows)
            {
                dr.Read();
                rep_bind_ders();
                GridView6.Visible = true;
                TextBox1.Text = "";
                Label1.Text = "";
            }
            else
            {
                GridView6.Visible = false;
                Label1.Visible = true;
                Label1.Text = "The search Term " + TextBox1.Text + " &nbsp;Is Not Available in the Records"; ;

            }
            MyCon.Close();
        }
        private void rep_bind_sorgu()
        {
            connection();
            string query = " SELECT DISTINCT pdf.Name,pdf.donem,pdf.proje_adı " +
                " FROM web.anahtar, web.danisman, web.juri, web.pdf, web.yazar, web.kullanici " +
                " WHERE pdf.Name LIKE '%" + TextBox1.Text + "%' " +
                " or pdf.donem LIKE '%" + TextBox1.Text + "%'" +
                " or pdf.proje_adı LIKE '%" + TextBox1.Text + "%'";

     
            MySqlDataAdapter da = new MySqlDataAdapter(query, MyCon);

            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView7.DataSource = ds;
            GridView7.DataBind();
            MyCon.Close();

        }

        protected void Button_sorgu2_Click(object sender, EventArgs e)
        {
            connection();
            string query = " SELECT DISTINCT pdf.Name,pdf.donem,pdf.proje_adı " +
                " FROM web.anahtar, web.danisman, web.juri, web.pdf, web.yazar, web.kullanici " +
                " WHERE pdf.Name LIKE '%" + TextBox1.Text + "%' " +
                " or pdf.donem LIKE '%" + TextBox1.Text + "%'" +
                " or pdf.proje_adı LIKE '%" + TextBox1.Text + "%'";

            MySqlDataAdapter da = new MySqlDataAdapter(query, MyCon);

            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView7.DataSource = ds;
            GridView7.DataBind();
            MyCon.Close();

        }


        protected void GridView7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}