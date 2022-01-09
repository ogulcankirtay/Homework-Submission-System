using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using MySql.Data.MySqlClient;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Text;
using yazlab1_3.v._1;
using System.Net;

namespace PDFFileUploadDownLoad
{
    public partial class Default : System.Web.UI.Page
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
            string query = "select pdf.name from web.kullanici,web.pdf where kullanici.id = '" + Kullanici_id + "' and kullanici.file_id=pdf.id";
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
            Label2.Visible = false;
            Kullanici_id = 0;
            if (Request.Cookies["id"] != null)
            {
                Response.Write(Request.Cookies["id"].Value.ToString());
                Kullanici_id = Convert.ToInt32(Request.Cookies["id"].Value.ToString());
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            connection();
            query = "Select MAX(id) from web.pdf "; //insert query
            
            com = new MySqlCommand(query, MyCon);
            com.Parameters.Add("@Name", MySqlDbType.VarChar).Value = pdf_id;



            MyCon.Close();

            connection();
            Label2.Visible = true;
            string filePath = FileUpload1.PostedFile.FileName; // getting the file path of uploaded file  
            string filename1 = System.IO.Path.GetFileName(filePath); // getting the file name of uploaded file  
            string ext = System.IO.Path.GetExtension(filename1); // getting the file extension of uploaded file  
            string type = String.Empty;
            
            if (!FileUpload1.HasFile)
            {
                Label2.Text = "Please Select File";
            }
            else
                if (FileUpload1.HasFile)
                {

                    try
                    {
                        // Added by vithal wadje for Csharp-Corner contribution

                        switch (ext)
                        {
                            case ".pdf":

                                type = "application/pdf";

                                break;

                        }

                    if (type != String.Empty)
                    {
                        ///////// pdf ekleme

                        StringBuilder sb = new StringBuilder();
                        string file = @"C:\Users\ASUS\Desktop\yazlab1-3.v.1\yazlab1-3.v.1\PDFFileUploadDownLoad\" + FileUpload1.FileName;
                        using (PdfReader reader = new PdfReader(file))
                        {
                            for (int pageNo = 1; pageNo <= reader.NumberOfPages; pageNo++)
                            {
                                ITextExtractionStrategy stragecy = new SimpleTextExtractionStrategy();
                                string text = PdfTextExtractor.GetTextFromPage(reader, pageNo, stragecy);
                                text = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(text)));
                                sb.Append(text.ToLower());

                            }
                        }

                        // numara bulma
                        string[] numara = new string[3];
                        int a = sb.ToString().IndexOf("Öğrenci No: ".ToLower(), 0, sb.ToString().Length);
                        int sonuc1 = 0;
                        numara[0] = "";
                        int ogr_sayisi = 0;
                        if (a > 0)
                        {
                            sonuc1 = sb.ToString().IndexOf(" ", a, sb.ToString().Length - a);
                            for (int i = a + 12; i < sonuc1 + "Öğrenci No: ".Length + 2; i++)
                            {
                                numara[0] += "" + sb.ToString().ToCharArray().GetValue(i);
                            }
                            //   Console.Write(numara + "\n");
                            ogr_sayisi++;
                        }
                        a = sb.ToString().IndexOf("Öğrenci No: ".ToLower(), sonuc1, sb.ToString().Length - sonuc1);
                        sonuc1 = 0;
                        numara[1] = "";
                        if (a > 0)
                        {
                            sonuc1 = sb.ToString().IndexOf(" ", a, sb.ToString().Length - a);
                            for (int i = a + 12; i < sonuc1 + "Öğrenci No: ".Length + 2; i++)
                            {
                                numara[1] += "" + sb.ToString().ToCharArray().GetValue(i);
                            }
                            // Console.Write(numara1 + "\n");
                            ogr_sayisi++;
                        }

                        a = sb.ToString().IndexOf("Öğrenci No: ".ToLower(), sonuc1, sb.ToString().Length - sonuc1);
                        numara[2] = "";
                        if (a > 0)
                        {
                            sonuc1 = sb.ToString().IndexOf(" ", a, sb.ToString().Length - a);
                            for (int i = a + 12; i < sonuc1 + "Öğrenci No: ".Length + 2; i++)
                            {
                                numara[2] += "" + sb.ToString().ToCharArray().GetValue(i);
                            }
                            // Console.Write(numara2 + "\n");
                            ogr_sayisi++;
                        }
                        // Ogrenci numara çekme bitiş

                        // Ogrenci ad çekme
                        a = sb.ToString().IndexOf("Adı Soyadı: ".ToLower(), 0, sb.ToString().Length);
                        sonuc1 = 0;
                        string[] ad_soyad = new string[3];
                        ad_soyad[0] = "";
                        if (a > 0)
                        {
                            sonuc1 = sb.ToString().IndexOf("\n", a, sb.ToString().Length - a);
                            for (int i = a + 12; i < sonuc1; i++)
                            {
                                ad_soyad[0] += "" + sb.ToString().ToCharArray().GetValue(i);
                            }
                            //    Console.Write(ad_soyad + "\n");
                        }
                        a = sb.ToString().IndexOf("Adı Soyadı: ".ToLower(), sonuc1, sb.ToString().Length - sonuc1);
                        sonuc1 = 0;
                        ad_soyad[1] = "";
                        if (a > 0)
                        {

                            sonuc1 = sb.ToString().IndexOf("\n", a, sb.ToString().Length - a);
                            for (int i = a + 12; i < sonuc1; i++)
                            {
                                ad_soyad[1] += "" + sb.ToString().ToCharArray().GetValue(i);
                            }
                            //    Console.Write(adsoyad1 + "\n");
                        }
                        a = sb.ToString().IndexOf("Adı Soyadı: ".ToLower(), sonuc1, sb.ToString().Length - sonuc1);
                        sonuc1 = 0;
                        ad_soyad[2] = "";
                        if (a > 0)
                        {

                            sonuc1 = sb.ToString().IndexOf("\n", a, sb.ToString().Length - a);
                            for (int i = a + 12; i < sonuc1; i++)
                            {
                                ad_soyad[2] += "" + sb.ToString().ToCharArray().GetValue(i);
                            }
                            //    Console.Write(adsoyad2 + "\n");
                        }
                        // Ogrenci ad çekme

                        //Öğrenim türü !!!!!!!!!!
                        string ogr_tur = numara[0];
                        if (ogr_tur[5] == 1)
                        {
                            ogr_tur = "1. ogr.";
                        }
                        else
                        {
                            ogr_tur = "2. ogr";
                        }
                        //Öğrenim türü !!!!!!!!!!
                     
                        // ders adı
                        string ders_adi = "";
                        a = sb.ToString().IndexOf("ARAŞTIRMA PROBLEMLERİ".ToLower(), 0, sb.ToString().Length);
                        int b = sb.ToString().IndexOf("BİTİRME PROJESİ".ToLower(), 0, sb.ToString().Length);
                        if (a > 0)
                        {
                            ders_adi = "ARAŞTIRMA PROBLEMLERİ";

                        }
                        else if (b > 0)
                        {
                            ders_adi = "BİTİRME PROJESİ";
                        }

                        // Console.WriteLine(ders_adi);
                        // ders adı

                        // özet
                        string ozet = "";
                        a = sb.ToString().IndexOf("ÖZET".ToLower(), 0, sb.ToString().Length);
                        b = sb.ToString().IndexOf("Anahtar kelimeler:".ToLower(), 0, sb.ToString().Length);
                        for (int i = a; i < b; i++)
                        {
                            ozet += "" + sb.ToString().ToCharArray().GetValue(i);
                        }
                        //Console.Write(ozet);
                        // özet

                        // dönem Tezin Savunulduğu Tarih:
                        Console.WriteLine("\n\tDÖnem \n");
                        string donem = "";
                        string donem_yy = "";
                        string yil = "";

                        a = sb.ToString().IndexOf("Tezin Savunulduğu Tarih: ".ToLower(), 0, sb.ToString().Length);
                        int a1 = sb.ToString().IndexOf(".", a, sb.ToString().Length - a);
                        int a2 = sb.ToString().IndexOf(".", a1, sb.ToString().Length - a1);

                        b = sb.ToString().IndexOf("\n", a, sb.ToString().Length - a);
                        a = a + "Tezin Savunulduğu Tarih: ".Length + 3;
                        for (int i = a; i < a + 2; i++)
                        {
                            donem += "" + sb.ToString()[i];
                        }
                        // Console.WriteLine(donem);
                        if (donem == "01")
                        {
                            donem = "Guz";
                        }
                        else
                        {
                            donem = "yaz";
                        }
                        for (int i = a + 3; i < a + 7; i++)
                        {
                            yil += sb.ToString()[i];
                        }
                        if (donem == "Guz")
                        {

                            yil += "-" + Convert.ToInt32(Convert.ToInt32(yil) + 1);
                        }

                        else
                        {
                            string tmpyil = "";
                            tmpyil += "" + (Convert.ToInt32(yil) - 1) + "-" + yil;
                            yil = tmpyil;
                        }
                        //   Console.WriteLine(donem + " " + yil);
                        donem += yil;
                        // dönem

                        // proje adı
                        Console.WriteLine("\n         proje adı\n");
                        string proje_adı = "";
                        a = sb.ToString().IndexOf("LİSANS TEZİ".ToLower(), 0, sb.ToString().Length);
                        b = sb.ToString().IndexOf("\n", a + 1, sb.ToString().Length - (a + 1));


                        for (int i = b; i < sb.ToString().Length; i++)
                        {
                            char tmp = sb.ToString().ToCharArray()[i];
                            if (Char.IsLetter(tmp) == true)
                            {
                                a = sb.ToString().IndexOf(tmp, b, sb.ToString().Length - b);
                                break;

                            }
                        }
                        int c = sb.ToString().IndexOf("\n", a, sb.ToString().Length - (a));
                        for (int i = a; i < c; i++)
                        {
                            proje_adı += "" + sb.ToString().ToCharArray().GetValue(i);
                        }
                        //    Console.WriteLine(proje_adı);
                        // proje adı

                        //Anahtar kelimeler
                        Console.WriteLine("\n\tanahtar kellimeler\n");
                        string[] anahtar_kelimeler = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
                        a = sb.ToString().IndexOf("Anahtar kelimeler: ".ToLower(), 0, sb.ToString().Length);

                        int sayac = 0;
                        if (a > 0)
                        {

                            b = sb.ToString().IndexOf('.', a, sb.ToString().Length - a);

                            for (int i = a + "Anahtar kelimeler: ".Length; i < b; i++)
                            {

                                // Console.Write(sb.ToString().ToCharArray().GetValue(i)+" "+sayac);
                                if (sb.ToString().ToCharArray().GetValue(i).Equals(','))
                                {
                                    sayac++;
                                }
                                else
                                {
                                    if (sb.ToString().ToCharArray().GetValue(i).Equals('\n'))
                                    {

                                        anahtar_kelimeler[sayac] += " ";
                                    }
                                    else
                                    {
                                        anahtar_kelimeler[sayac] += "" + sb.ToString().ToCharArray().GetValue(i);
                                    }
                                }
                            }

                           
                        }
                        //sıkıntı olabilir sonra bi bak
                        string[] a_kelimeler = new string[sayac + 1];
                        for (int i = 0; i < sayac + 1; i++)
                        {
                            a_kelimeler[i] = anahtar_kelimeler[i];
                            //     Console.WriteLine(a_kelimeler[i]);
                        }
                        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        //Anahtar kelimeler

                        //Danı¸sman bilgileri
                        Console.WriteLine("\n\tDanışman bilgileri\n");
                        string danısman_unvan = "";
                        string danısman_ad = "";
                        a = sb.ToString().IndexOf("Danışman, Kocaeli Üniv.".ToLower(), 0, sb.ToString().Length);
                        string parca = sb.ToString().Substring(0, a);

                        int baslangıc = 0;
                        if (parca.IndexOf("prof", 0, parca.Length) > 0)
                        {
                            baslangıc = parca.IndexOf("prof", 0, parca.Length);

                        }
                        else if (parca.IndexOf("prof", 0, parca.Length) > 0)
                        {
                            baslangıc = parca.IndexOf("prof", 0, parca.Length);

                        }
                        else if (parca.IndexOf("dr", 0, parca.Length) > 0)
                        {

                            baslangıc = parca.IndexOf("doç", 0, parca.Length);
                        }
                        c = sb.ToString().IndexOf(". ".ToLower(), baslangıc, sb.ToString().Length - (baslangıc));
                        b = sb.ToString().IndexOf(". ".ToLower(), c + 1, sb.ToString().Length - (c + 1));
                        string g = "";
                        if (parca.IndexOf("Üyesi".ToLower(), 0, parca.Length) > 0)

                        {

                            g = "üyesi";
                        }
                        else if (parca.IndexOf("Görevlisi".ToLower(), 0, parca.Length) > 0)
                        {
                            g = "görevlisi";
                        }
                        for (int i = baslangıc; i < b; i++)
                        {

                            danısman_unvan += "" + sb.ToString().ToCharArray().GetValue(i);
                        }
                        danısman_unvan += g;
                        //  Console.WriteLine(danısman_unvan);
                        for (int i = b + 2; i < parca.Length; i++)
                        {
                            danısman_ad += "" + parca.ToCharArray()[i];
                        }
                        //  Console.WriteLine(danısman_ad);
                        //Danı¸sman bilgileri

                        //J¨uri bilgileri
                        Console.WriteLine("\n\tjuri bilgileri\n");
                        string [] juri_unvan = new string [3];
                        string [] juri_ad_soyad = new string[3];
                         juri_ad_soyad [1] = "";
                         juri_unvan[1] = "";
                         juri_unvan[2] = "";
                         juri_ad_soyad[2] = "";
                        juri_unvan[0]="";
                        juri_ad_soyad[0] = "";
                        a = sb.ToString().IndexOf("Danışman, Kocaeli Üniv.".ToLower(), 0, sb.ToString().Length);

                        for (int i = a; i < sb.ToString().Length; i++)
                        {
                            char tmp = sb.ToString().ToCharArray()[i];
                            if (Char.IsLetter(tmp) == true)
                            {
                                b = sb.ToString().IndexOf(tmp, a, sb.ToString().Length - a);
                                break;

                            }
                        }
                        a = sb.ToString().IndexOf("\n".ToLower(), b, sb.ToString().Length - b);
                        c = sb.ToString().IndexOf("\n".ToLower(), a + 1, sb.ToString().Length - (a + 1));

                        string gecic = "";
                        for (int i = a; i < c; i++)
                        {
                            juri_unvan[0] += "" + sb.ToString().ToCharArray().GetValue(i);
                        }
                        if (juri_unvan[0].IndexOf("Üyesi".ToLower(), 0, juri_unvan.Length) > 0)

                        {

                            gecic = "üyesi";
                        }
                        else if (juri_unvan[0].IndexOf("Görevlisi".ToLower(), 0, juri_unvan.Length) > 0)
                        {
                            gecic = "görevlisi";
                        }
                        juri_unvan[0] = "";
                        c = sb.ToString().IndexOf(". ".ToLower(), a, sb.ToString().Length - (a));
                        b = sb.ToString().IndexOf(". ".ToLower(), c + 1, sb.ToString().Length - (c + 1));
                        if (a > 0)
                        {
                            for (int i = a + 1; i < b + 1; i++)
                            {
                                juri_unvan[0] += "" + sb.ToString().ToCharArray().GetValue(i);
                            }


                        }
                        juri_unvan[0] += gecic;



                        //Console.WriteLine(juri_unvan);
                        c = sb.ToString().IndexOf("\n", b + 1, sb.ToString().Length - (b + 1));
                        for (int i = b + 2 + gecic.Length; i < c; i++)
                        {
                            juri_ad_soyad[0] += "" + sb.ToString().ToCharArray().GetValue(i);
                        }
                        // Console.WriteLine(juri_ad_soyad);
                        gecic = "";

                        a = sb.ToString().IndexOf("Jüri Üyesi, Kocaeli Üniv".ToLower(), 0, sb.ToString().Length);

                        for (int i = a; i < sb.ToString().Length; i++)
                        {
                            char tmp = sb.ToString().ToCharArray()[i];
                            if (Char.IsLetter(tmp) == true)
                            {
                                b = sb.ToString().IndexOf(tmp, a, sb.ToString().Length - a);
                                break;

                            }
                        }
                        a = sb.ToString().IndexOf("\n".ToLower(), b, sb.ToString().Length - b);
                        c = sb.ToString().IndexOf("\n".ToLower(), a + 1, sb.ToString().Length - (a + 1));

                        gecic = "";
                        for (int i = a; i < c; i++)
                        {
                            juri_unvan[1] += "" + sb.ToString().ToCharArray().GetValue(i);
                        }
                        if (juri_unvan[1].IndexOf("Üyesi".ToLower(), 0, juri_unvan[1].Length) > 0)

                        {

                            gecic = "üyesi";
                        }
                        else if (juri_unvan[1].IndexOf("Görevlisi".ToLower(), 0, juri_unvan[1].Length) > 0)
                        {
                            gecic = "görevlisi";
                        }
                        juri_unvan[1] = "";
                        c = sb.ToString().IndexOf(". ".ToLower(), a, sb.ToString().Length - (a));
                        b = sb.ToString().IndexOf(". ".ToLower(), c + 1, sb.ToString().Length - (c + 1));
                        if (a > 0)
                        {
                            for (int i = a + 1; i < b + 1; i++)
                            {
                                juri_unvan[1] += "" + sb.ToString().ToCharArray().GetValue(i);
                            }


                        }
                        juri_unvan[1] += gecic;



                        //  Console.WriteLine(juri_unvan1);
                        c = sb.ToString().IndexOf("\n", b + 1, sb.ToString().Length - (b + 1));
                        for (int i = b + 2 + gecic.Length; i < c; i++)
                        {
                            juri_ad_soyad[1] += "" + sb.ToString().ToCharArray().GetValue(i);
                        }
                        //Console.WriteLine(juri_ad_soyad1);
                        gecic = "";
                        juri_ad_soyad[2] = danısman_ad;
                        juri_unvan[2] = danısman_unvan;
                        //juri//


                        ///////// pdf ekleme

                       

                        connection();
                        Stream fs = FileUpload1.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs); //reads the binary files  
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length); //counting the file length into bytes  
                        query = "insert into pdf (Name,type,data,Ders_adı,donem,ozet,proje_adı)" + " values (@Name, @type, @Data,@Ders_adı,@donem,@ozet,@proje_adı)"; //insert query  
                        com = new MySqlCommand(query, MyCon);
                        com.Parameters.Add("@Name", MySqlDbType.VarChar).Value = filename1;
                        com.Parameters.Add("@type", MySqlDbType.VarChar).Value = type;
                        com.Parameters.Add("@Data", MySqlDbType.VarBinary).Value = bytes;
                        com.Parameters.Add("@Ders_adı", MySqlDbType.VarChar).Value = ders_adi;
                        com.Parameters.Add("@donem", MySqlDbType.VarChar).Value = donem;
                        com.Parameters.Add("@ozet", MySqlDbType.LongText).Value = ozet;
                        com.Parameters.Add("@proje_adı", MySqlDbType.VarChar).Value = proje_adı;
                        com.ExecuteNonQuery();
                        MyCon.Close();

                       
                        
                        //pdf_id bulma//
                        connection();
                        query = "Select MAX(id) from web.pdf "; //insert query
                        com = new MySqlCommand(query,MyCon);
                        MySqlDataReader dr;
                        dr = com.ExecuteReader();
                        if (dr.HasRows)
                        {
                            dr.Read();
                            pdf_id = dr.GetInt32(0);
                        }
                        MyCon.Close();
                        //pdf_id bulma///

                        //kullanıcı_pdf_eşleştir//
                        connection();
                        query = "update kullanici set file_id='" + pdf_id + "' where id='" + Kullanici_id + "'";
                        Label2.Text = "update kullanici set file_id='" + pdf_id + "' where id='" + Kullanici_id + "'";

                        com = new MySqlCommand(query, MyCon);
                        com.ExecuteNonQuery();
                        MyCon.Close();
                        //kullanıcı_pdf_eşleştir//
                        //yazardatabase


                        Label2.ForeColor = System.Drawing.Color.Green;

                        connection();
                        for (int i = 0; i < ogr_sayisi; i++)
                        {
                            query = "insert into yazar (ad_soyad,ogr_no,ogr_tur,pdf_id)" + " values (@ad_soyad, @ogr_no, @ogr_tur,@pdf_id)"; //insert query  
                            com = new MySqlCommand(query, MyCon);
                            com.Parameters.Add("@ad_soyad", MySqlDbType.VarChar).Value = ad_soyad[i];
                            com.Parameters.Add("@ogr_no", MySqlDbType.VarChar).Value = numara[i];
                            com.Parameters.Add("@ogr_tur", MySqlDbType.VarChar).Value = ogr_tur;
                            com.Parameters.Add("@pdf_id", MySqlDbType.Int32).Value = pdf_id;
                            com.ExecuteNonQuery();
                        }
                        MyCon.Close();
                        //yazardatabase 

                        //juriDatabase
                        connection();
                        for (int i = 0; i < 3; i++)
                        {
                            query = "insert into juri (ad_soyad,unvan,pdf_id)" + " values (@ad_soyad, @unvan,@pdf_id)"; //insert query  
                            com = new MySqlCommand(query, MyCon);
                            com.Parameters.Add("@ad_soyad", MySqlDbType.VarChar).Value = juri_ad_soyad[i];
                            com.Parameters.Add("@unvan", MySqlDbType.VarChar).Value = juri_unvan[i];
                            com.Parameters.Add("@pdf_id", MySqlDbType.Int32).Value = pdf_id;
                            com.ExecuteNonQuery();
                        }
                        MyCon.Close();
                        //juriDatabase

                        //danışmanDatabase//
                        
                        connection();
                        query = "insert into danisman (ad_soyad,unvan,pdf_id)" + " values (@ad_soyad,@unvan,@pdf_id)"; //insert query  
                        com = new MySqlCommand(query, MyCon);
                        com.Parameters.Add("@ad_soyad", MySqlDbType.VarChar).Value = danısman_ad;
                        com.Parameters.Add("@unvan", MySqlDbType.VarChar).Value = danısman_unvan;
                        com.Parameters.Add("@pdf_id", MySqlDbType.Int32).Value = pdf_id;
                            com.ExecuteNonQuery();
                        MyCon.Close();
                        //danışmanDatabase//

                        //anahtar kelime
                        connection(); 
                    
                        for (int i = 0; i < sayac + 1; i++)
                        {  
                            query = "insert into anahtar(name,pdf_id)" + " values (@name,@pdf_id)"; //insert query  
                        com = new MySqlCommand(query, MyCon);
                            com.Parameters.Add("@name", MySqlDbType.VarChar).Value = a_kelimeler[i];
                            com.Parameters.Add("@pdf_id", MySqlDbType.Int32).Value = pdf_id;
                            com.ExecuteNonQuery();

                        }
                        MyCon.Close();
                        // anahtarkelime
                    }
                    else
                        {
                            Label2.ForeColor = System.Drawing.Color.Red;

                            Label2.Text = "Select Only PDF Files";


                        }
                    }
                    catch (Exception ex)
                    {
                     Label2.Text = "Error: " + ex.Message.ToString();
                    

                }
                FileUpload1.SaveAs(@"C:\Users\ASUS\Desktop\yazlab1-3.v.1\yazlab1-3.v.1\PDFFileUploadDownLoad\" + FileUpload1.FileName);
                

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            connection();
           
            
           string query = "select pdf.name from web.kullanici,web.pdf where kullanici.id = '" + Kullanici_id + "'and kullanici.file_id=pdf.id";
             Label2.Text = "select pdf.data from web.kullanici,web.pdf where kullanici.id = '" + Kullanici_id + "'and kullanici.file_id=pdf.id";
            MySqlCommand com = new MySqlCommand(query, MyCon);

            MySqlDataReader dr;
            dr = com.ExecuteReader();


            if (dr.HasRows)
            {
                dr.Read();
                rep_bind();
                GridView1.Visible = true;
                //filename=dr.GetString(0);
                Label2.Text = ""+dr.GetString(0);
            }
            else
            {
                GridView1.Visible = false;
                Label2.Visible = true;

            }
            MyCon.Close();
        }

        protected void SqlDataSource1_Selecting(object sender, System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            connection();

            string filename="";
            string query = "select pdf.name from web.kullanici,web.pdf where kullanici.id = '" + Kullanici_id + "'and kullanici.file_id=pdf.id";
            Label2.Text = "select pdf.data from web.kullanici,web.pdf where kullanici.id = '" + Kullanici_id + "'and kullanici.file_id=pdf.id";
            MySqlCommand com = new MySqlCommand(query, MyCon);

            MySqlDataReader dr;
            dr = com.ExecuteReader();


            if (dr.HasRows)
            {
                dr.Read();
         
               filename = dr.GetString(0);
                Label2.Text = "aaaa" + dr.GetString(0);
            }
           
           
            MyCon.Close();
        

        string dosyayolu= filename;
            string filepath = Server.MapPath(dosyayolu);
            WebClient user = new WebClient();
            Byte[] FileBuffer = user.DownloadData(filepath);
            if (FileBuffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("count-length",FileBuffer.Length.ToString());
                Response.BinaryWrite(FileBuffer);
            }
        }
    
        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
           
        }

    }
   
}
