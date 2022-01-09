using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yazlab1_3.v._1
{
    public partial class adminGiris : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            string x = TextBox1.Text;
            string y = TextBox2.Text;
            DataSet1TableAdapters.kullaniciTableAdapter dt = new DataSet1TableAdapters.kullaniciTableAdapter();
            DataSet1.kullaniciDataTable user;
            user = dt.AdminListesi();
            int durum = 0;
            foreach (DataSet1.kullaniciRow kullaniciRow in user)
            {
                if (kullaniciRow.username == x && kullaniciRow.psw == y && kullaniciRow.yetki == 1)
                {
                    HttpCookie Cookie = new HttpCookie("id");
                    Cookie.Value = kullaniciRow.id.ToString();
                    Cookie.Expires = DateTime.Now.AddHours(1);
                    Response.Cookies.Add(Cookie);
                    Response.Redirect("yonetim.aspx");
                    durum = 1;
                }


            }
            if (durum == 0)
            {
                Response.Redirect("adminGiris.aspx");
            }


        }
    }
}