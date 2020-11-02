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
    public partial class gider_güncelle : System.Web.UI.Page
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
            comm = new SqlCommand("SELECT harcama_id, harcama_adi FROM Harcamalar", conn);

            try
            {
                //Bağlantımı açıyorum.
                conn.Open();
                //DataReader nesnemi çalıştırıyorum.
                reader = comm.ExecuteReader();
                //DropDownList kontrolüm ilgili alanlarla doluyor.
                ddlHarcamaListe.DataSource = reader;
                ddlHarcamaListe.DataValueField = "harcama_id";
                ddlHarcamaListe.DataTextField = "harcama_adi";
                ddlHarcamaListe.DataBind();
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
            txtHarcamaAdi.Text = "";
            txtHarcamaTutari.Text = "";
            txtHarcamaAciklama.Text = "";

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
            comm = new SqlCommand("SELECT harcama_adi,harcama_tutari,harcama_aciklama FROM Harcamalar WHERE harcama_id = @harcama_id", conn);
            comm.Parameters.Add("@harcama_id", System.Data.SqlDbType.Int);
            comm.Parameters["@harcama_id"].Value = ddlHarcamaListe.SelectedItem.Value;

            try
            {
                //Bağlantımı açıyorum.
                conn.Open();
                reader = comm.ExecuteReader();
                if (reader.Read())
                {
                    //DataReader nesnesi okunduğu sürece ilgili alanlarımı dolduruyorum.
                    txtHarcamaAdi.Text = reader["harcama_adi"].ToString();
                    txtHarcamaTutari.Text = reader["harcama_tutari"].ToString();
                    txtHarcamaAciklama.Text = reader["harcama_aciklama"].ToString();

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
            comm = new SqlCommand("UPDATE Harcamalar SET harcama_adi=@harcama_adi,harcama_tutari=@harcama_tutari,harcama_aciklama=@harcama_aciklama WHERE harcama_id=@harcama_id", conn);
            //Parametre bilgilerim - veri tiplerim ve bu bilgilerin hangi kontrollerden alınacağını belirtiyorum.
            comm.Parameters.Add("@harcama_adi", System.Data.SqlDbType.NVarChar, 50);
            comm.Parameters["@harcama_adi"].Value = txtHarcamaAdi.Text;
            comm.Parameters.Add("@harcama_tutari", System.Data.SqlDbType.Float);
            comm.Parameters["@harcama_tutari"].Value = txtHarcamaTutari.Text;
            comm.Parameters.Add("@harcama_aciklama", System.Data.SqlDbType.NVarChar, 50);
            comm.Parameters["@harcama_aciklama"].Value = txtHarcamaAciklama.Text;

            comm.Parameters.Add("@harcama_id", System.Data.SqlDbType.Int);
            comm.Parameters["@harcama_id"].Value = ddlHarcamaListe.SelectedItem.Value;

            try
            {
                //Bağlantımı açıyorum, komutu çalıştırıyorum.
                conn.Open();
                comm.ExecuteNonQuery();
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