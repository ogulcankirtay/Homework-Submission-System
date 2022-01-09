using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;

namespace yazlab1_3.v._1
{
    public partial class yonetim : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet1TableAdapters.kullaniciTableAdapter dt = new DataSet1TableAdapters.kullaniciTableAdapter();
            Repeater2.DataSource = dt.AdminListesi();
            Repeater2.DataBind();

        }
   

    }
}

