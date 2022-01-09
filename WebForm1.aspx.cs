using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace yazlab1_3.v._1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

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
                if (kullaniciRow.username == x && kullaniciRow.psw == y)
                {
                    HttpCookie Cookie = new HttpCookie("id");
                    Cookie.Value = kullaniciRow.id.ToString();
                    Cookie.Expires = DateTime.Now.AddHours(1);
                    Response.Cookies.Add(Cookie);
                    Response.Redirect("PDFFileUploadDownLoad/Default.aspx");
                    durum = 1;
                }
           
                
            }
            if (durum == 0)
            {
                Response.Redirect("WebForm1.aspx");
            }
                     

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("admingiris.aspx");
        }
    }
}