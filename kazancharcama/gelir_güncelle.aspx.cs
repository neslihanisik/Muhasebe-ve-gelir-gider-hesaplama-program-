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
    public partial class gelir_güncelle : System.Web.UI.Page
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
            //Bağlantı ve komut tanımlamalarımç
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            //Bağlantımı satırım. ConfigurationManager ile alıyorum.
            string connectionString = ConfigurationManager.ConnectionStrings["gelirgiderConnectionString"].ConnectionString;
            conn = new SqlConnection(connectionString);
            //Burada komut kısmında bir string toplama işlemim var çünkü benim Ad ve Soyad alanım tablomda ayrı ayrı,
            //Ben bunu DropDownList kontrolümde yan yana göstermek istiyorum o yüzden sorgum bu şekilde.
            comm = new SqlCommand("SELECT gelir_id, gelir_adi FROM Gelirler", conn);

            try
            {
                //Bağlantımı açıyorum.
                conn.Open();
                //DataReader nesnemi çalıştırıyorum.
                reader = comm.ExecuteReader();
                //DropDownList kontrolüm ilgili alanlarla doluyor.
                ddlGelirListe.DataSource = reader;
                ddlGelirListe.DataValueField = "gelir_id";
                ddlGelirListe.DataTextField = "gelir_adi";
                ddlGelirListe.DataBind();
                reader.Close();
            }
            catch
            {
                //Hata meydana gelirse verilecek mesaj.
                lblHata.Text = "Çalışan listesi yüklemesi esnasında hata oluştu!";
            }
            finally
            {
                //Bağlantımı kapatıyorum.
                conn.Close();
            }
            //Herhangi bir isim seçilmediğinde textbox kontrollerim ve butonum kullanılmayacak o yüzden burası da böyle.
            btnGuncelle.Enabled = false;
            txtGelirAdi.Text = "";
            txtGelirTutari.Text = "";
            txtGelirAciklama.Text = "";

        }

        protected void btnSeciniz_Click(object sender, EventArgs e)
        {
            //Sql Bağlantı tanımlamalarımı yapıyorum.
            SqlConnection conn;
            SqlCommand comm;
            SqlDataReader reader;
            string ConnectionString = ConfigurationManager.ConnectionStrings["gelirgiderConnectionString"].ConnectionString;
            conn = new SqlConnection(ConnectionString);
            //Sql Komutum ve hangi parametreye göre verileri çekeceğimi belirtiyorum.
            comm = new SqlCommand("SELECT gelir_adi,gelir_tutari,gelir_aciklama FROM Gelirler WHERE gelir_id = @gelir_id", conn);
            comm.Parameters.Add("@gelir_id", System.Data.SqlDbType.Int);
            comm.Parameters["@gelir_id"].Value = ddlGelirListe.SelectedItem.Value;

            try
            {
                //Bağlantımı açıyorum.
                conn.Open();
                reader = comm.ExecuteReader();
                if (reader.Read())
                {
                    //DataReader nesnesi okunduğu sürece ilgili alanlarımı dolduruyorum.
                    txtGelirAdi.Text = reader["gelir_adi"].ToString();
                    txtGelirTutari.Text = reader["gelir_tutari"].ToString();
                    txtGelirAciklama.Text = reader["gelir_aciklama"].ToString();

                }
                reader.Close();
                btnGuncelle.Enabled = true;
            }

            catch
            {
                //Hata durumu olması halinde..
                lblHata.Text = "Çalışan bilgileri detayı yüklenirken hata oluştu";
            }

            finally
            {
                //Bağlantımı kapatıyorum.
                conn.Close();
            }


        }
        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            //Bağlantı tanımlamalarımı yapıyorum.
            SqlConnection conn;
            SqlCommand comm;
            string connectionString = ConfigurationManager.ConnectionStrings["gelirgiderConnectionString"].ConnectionString;
            conn = new SqlConnection(connectionString);
            //SQL Command yazıyorum bu sefer görüldüğü gibi UPDATE işlemi yapıyorum, update edilecek alanlarımı belirtiyorum.
            comm = new SqlCommand("UPDATE Gelirler SET gelir_adi=@gelir_adi,gelir_tutari=@gelir_tutari,gelir_aciklama=@gelir_aciklama WHERE gelir_id=@gelir_id", conn);
            //Parametre bilgilerim - veri tiplerim ve bu bilgilerin hangi kontrollerden alınacağını belirtiyorum.
            comm.Parameters.Add("@gelir_adi", System.Data.SqlDbType.NVarChar, 50);
            comm.Parameters["@gelir_adi"].Value = txtGelirAdi.Text;
            comm.Parameters.Add("@gelir_tutari", System.Data.SqlDbType.Float);
            comm.Parameters["@gelir_tutari"].Value = txtGelirTutari.Text;
            comm.Parameters.Add("@gelir_aciklama", System.Data.SqlDbType.NVarChar, 50);
            comm.Parameters["@gelir_aciklama"].Value = txtGelirAciklama.Text;

            comm.Parameters.Add("@gelir_id", System.Data.SqlDbType.Int);
            comm.Parameters["@gelir_id"].Value = ddlGelirListe.SelectedItem.Value;

            try
            {
                //Bağlantımı açıyorum, komutu çalıştırıyorum.
                conn.Open();
                comm.ExecuteNonQuery();
                Response.Redirect("default.aspx");
            }
            catch
            {
                //Hata olursa verilecek mesaj
                lblHata.Text = "Güncelleme esnasında hata meydana geldi";
            }
            finally
            {
                conn.Close();
            }
            CalisanListesiniYukle();
        }
    }
}