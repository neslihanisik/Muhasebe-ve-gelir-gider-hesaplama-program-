using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace kazancharcama
{
    public partial class Ekle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                btnEkle_Click();
            
            }
        }
        //metodum
        private void btnEkle_Click()
        {
            
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
          
            string connectionString = ConfigurationManager.ConnectionStrings["gelirgiderConnectionString"].ConnectionString;
            conn = new SqlConnection(connectionString);
            //Sql query burada, SELECT işlemi ile iki tablodan veri alıp tek bir tablodan veri okunuyor gibi oluyor.
            comm = new SqlCommand("SELECT Gelirler.gelir_adi, Gelirler.gelir_tutari,Gelirler.gelir_aciklama FROM Gelirler  ", conn);
            try
            {
                //Bağlantımı açıyorum.
                conn.Open();
                reader = comm.ExecuteReader();
               
                txtGelirListele.DataSource = reader;
                txtGelirListele.DataBind();

                reader.Close();
                
            }
       
            catch
            {
                Response.Write("Veri listelenemedi, hata oluştu!!");
            }
          
            finally
            {
                conn.Close();
            }
        }
       

    }
}
