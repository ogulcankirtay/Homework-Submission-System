using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yazlab1_3.v._1
{
    public partial class Guncelle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(Request.QueryString["id"].ToString());
            DataSet1TableAdapters.kullaniciTableAdapter dt = new DataSet1TableAdapters.kullaniciTableAdapter();
            TextBox1.Text = x.ToString();
            TextBox1.Enabled = false;
            if (IsPostBack == false)
            {
                TextBox2.Text = dt.Verigetir(x)[0].username;
                TextBox3.Text = dt.Verigetir(x)[0].psw;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataSet1TableAdapters.kullaniciTableAdapter dt = new DataSet1TableAdapters.kullaniciTableAdapter();
            dt.KullaaniciGuncelle(TextBox2.Text,TextBox3.Text,Convert.ToInt32(TextBox1.Text));
            Response.Redirect("yonetim.aspx");
        }
    }
}