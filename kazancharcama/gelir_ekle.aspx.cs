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
    public partial class gelir_ekle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                SqlConnection baglanti;
                SqlCommand ekleKomutu; ;
                string ConnectionString = ConfigurationManager.ConnectionStrings["gelirgiderConnectionString"].ConnectionString;
                baglanti = new SqlConnection(ConnectionString);
                ekleKomutu = new SqlCommand("INSERT INTO Gelirler (gelir_adi, gelir_tutari,gelir_aciklama) VALUES (@gelir_adi, @gelir_tutari, @gelir_aciklama)", baglanti);
                ekleKomutu.Parameters.Add("@gelir_adi", System.Data.SqlDbType.NVarChar, 50);
                ekleKomutu.Parameters["@gelir_adi"].Value = txtGelirAdi.Text;
                ekleKomutu.Parameters.Add("@gelir_tutari", System.Data.SqlDbType.Float);
                ekleKomutu.Parameters["@gelir_tutari"].Value = txtGelirTutari.Text;
                ekleKomutu.Parameters.Add("@gelir_aciklama", System.Data.SqlDbType.NVarChar, 50);
                ekleKomutu.Parameters["@gelir_aciklama"].Value = txtGelirAciklama.Text;


                try
                {
                    //Bağlantımı açıyorum.
                    baglanti.Open();
                    //Burada ExcuteNonQuery kullanıyorum, çünkü bana geriye herhangi bir veri listesi geri dönmeyecek.
                    ekleKomutu.ExecuteNonQuery();
                    //Komut çalışıp sonlandıktan sonra tekrar aynı sayfaya yönleneceğim.
                    Response.Redirect("default.aspx");
                }
                catch
                {
                    //hata olursa label kontrolümde mesaj yazılacak.
                    lblHata.Text = "Bağlantıda hata oluştu, veri kaydedilemedi..";
                }
                finally
                {
                    //Bağlantımı kapatıyorum.
                    baglanti.Close();
                }
            }
        }
    }
}