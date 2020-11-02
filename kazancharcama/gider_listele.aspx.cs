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
    public partial class gelir_listele : System.Web.UI.Page
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
            comm = new SqlCommand("SELECT Harcamalar.harcama_adi, Harcamalar.harcama_tutari,Harcamalar.harcama_aciklama FROM Harcamalar  ", conn);
            try
            {
                //Bağlantımı açıyorum.
                conn.Open();
                reader = comm.ExecuteReader();

                txtGiderListele.DataSource = reader;
                txtGiderListele.DataBind();

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