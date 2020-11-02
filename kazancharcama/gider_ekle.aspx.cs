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
    public partial class gider_ekle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnKaydetGider_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                SqlConnection baglanti;
                SqlCommand ekleKomutu; 
                string ConnectionString = ConfigurationManager.ConnectionStrings["gelirgiderConnectionString"].ConnectionString;
                baglanti = new SqlConnection(ConnectionString);
                ekleKomutu = new SqlCommand("INSERT INTO Harcamalar (harcama_adi, harcama_tutari,harcama_aciklama) VALUES (@harcama_adi, @harcama_tutari, @harcama_aciklama)", baglanti);
                ekleKomutu.Parameters.Add("@harcama_adi", System.Data.SqlDbType.NVarChar, 50);
                ekleKomutu.Parameters["@harcama_adi"].Value = txtGiderAdi.Text;
                ekleKomutu.Parameters.Add("@harcama_tutari", System.Data.SqlDbType.Float);
                ekleKomutu.Parameters["@harcama_tutari"].Value = txtGiderTutari.Text;
                ekleKomutu.Parameters.Add("@harcama_aciklama", System.Data.SqlDbType.NVarChar, 50);
                ekleKomutu.Parameters["@harcama_aciklama"].Value = txtGiderAciklama.Text;


                try
                {
                    //Bağlantımı açıyorum.
                    baglanti.Open();
                    //Burada ExcuteNonQuery kullanıyorum, çünkü bana geriye herhangi bir veri listesi geri dönmeyecek.
                    ekleKomutu.ExecuteNonQuery();
                    //Komut çalışıp sonlandıktan sonra tekrar aynı sayfaya yönleneceğim.
                    Response.Redirect("gider_listele.aspx");
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