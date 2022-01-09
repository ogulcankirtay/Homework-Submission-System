using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace yazlab1_3.v._1
{
    public partial class anasayfa : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = 0;
            if (Request.Cookies["id"] != null)
            {
                Response.Write(Request.Cookies["id"].Value.ToString());
                id=Convert.ToInt32(Request.Cookies["id"].Value.ToString());
            }
 
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
    
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataSet1TableAdapters.kullaniciTableAdapter dt = new DataSet1TableAdapters.kullaniciTableAdapter();
            //dt.EklePdf();


        }
    }
}