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
    public partial class gelir_sil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Sayfam PostBack edilmemişse ve ilk defa yükleniyorsa CalisanListesiniYukle metodunu çalıştır.
            if (!IsPostBack)
            {
                CalisanListesiniYukle();
            }

        }
        //CalisanListesiniYukle metodum.
        private void CalisanListesiniYukle()
        {
            //Bağlantı ve komut tanımlamalarım.
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            //Bağlantımı satırım. ConfigurationManager ile alıyorum.
            string connectionString = ConfigurationManager.ConnectionStrings["gelirgiderConnectionString"].ConnectionString;
            conn = new SqlConnection(connectionString);
            //Burada komut kısmında bir string toplama işlemim var çünkü benim Ad ve Soyad alanım tablomda ayrı ayrı,
            //Ben bunu DropDownList kontrolümde yan yana göstermek istiyorum o yüzden sorgum bu şekilde.
            comm = new SqlCommand("SELECT gelir_id,gelir_adi FROM Gelirler", conn);

            try
            {
                //Bağlantımı açıyorum.
                conn.Open();
                //DataReader nesnemi çalıştırıyorum.
                reader = comm.ExecuteReader();
                //DropDownList kontrolüm ilgili alanlarla doluyor.
                DDLGelirListesi.DataSource = reader;
                DDLGelirListesi.DataValueField = "gelir_id";
                DDLGelirListesi.DataTextField = "gelir_adi";
                DDLGelirListesi.DataBind();
                reader.Close();
            }
            catch
            {
                //Hata meydana gelirse verilecek mesaj.
                lblHata.Text = "Kişi Listesi yüklemesi esnasında hata oluştu!";
            }

            finally
            {
                //Bağlantımı kapatıyorum.
                conn.Close();
            }

        }

        protected void btnGelirSil_Click(object sender, EventArgs e)
        {
            //Sql Bağlantı tanımlamalarımı yapıyorum.
            SqlConnection conn;
            SqlCommand comm;
            string connectionString = ConfigurationManager.ConnectionStrings["gelirgiderConnectionString"].ConnectionString;
            conn = new SqlConnection(connectionString);
            //SQL komutum hangi parametreye göre veri sileceğim, bunu tanımlıyorum.
            comm = new SqlCommand("DELETE FROM Gelirler WHERE gelir_id = @gelir_id", conn);
            comm.Parameters.Add("@gelir_id", System.Data.SqlDbType.Int);
            comm.Parameters["@gelir_id"].Value = DDLGelirListesi.SelectedItem.Value;

            try
            {
                //Bağlantımı açıyorum, komutumu çalıştırıyorum.
                conn.Open();
                comm.ExecuteNonQuery();
            }
            catch
            {
                //Hata meydana gelirse yazdırılacak mesaj.
                lblHata.Text = "Kişi Silme esnasında hata oluştu!";
            }
            finally
            {
                //Bağlantımı kapatıyorum.
                conn.Close();
            }
            //Kişi silindikten sonra tekrar verileri yüklüyorum, silindiğini böylelikle görebilirim..
            CalisanListesiniYukle();
        }

    }
}