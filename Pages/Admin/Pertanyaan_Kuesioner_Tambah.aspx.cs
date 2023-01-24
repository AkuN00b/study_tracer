using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace study_tracer.Pages.Admin
{
    public partial class Pertanyaan_Kuesioner_Tambah : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tbDeskripsiPertanyaan.TextMode = TextBoxMode.MultiLine;
                tbDeskripsiPertanyaan.Rows = 10;

                titleManipulasiData.Text = "Pertanyaan Kuesioner Tambah";
                loadDetailPeriode();
            }
        }

        protected void btnKirimm_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                conn.Open();

                SqlCommand command = new SqlCommand("ts_InsertPertanyaanKuesioner", conn);
                command.Parameters.AddWithValue("@deskripsiPertanyaan", tbDeskripsiPertanyaan.Text);
                command.Parameters.AddWithValue("@jenis", ddlJenis.SelectedValue.ToString());
                command.Parameters.AddWithValue("@kode", tbKodePertanyaan.Text);
                command.Parameters.AddWithValue("@nama", Session["nama"].ToString());
                command.Parameters.AddWithValue("@id_detailPeriode", ddlPeriodeDanJenisKuesioner.SelectedValue.ToString());
                command.Parameters.AddWithValue("@pertanyaan_utama", ddlPertanyaanUtama.SelectedValue.ToString());

                command.CommandType = CommandType.StoredProcedure;
                dt.Load(command.ExecuteReader());

                conn.Close();

                ClientScript.RegisterStartupScript(this.GetType(), "Error", "berhasilTambahDataKuesioner()", true);
            }
            catch { }
        }

        protected void loadDetailPeriode()
        {
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            conn.Open();

            ddlPeriodeDanJenisKuesioner.DataSource = "";
            ddlPeriodeDanJenisKuesioner.Items.Clear();
            SqlCommand com = new SqlCommand();
            com.Connection = conn;
            com.CommandText = "ts_getDataDetailJenisPeriode";
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@query", "");

            SqlDataAdapter adap = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adap.Fill(dt);

            ddlPeriodeDanJenisKuesioner.DataSource = dt;
            ddlPeriodeDanJenisKuesioner.DataTextField = "JKP";
            ddlPeriodeDanJenisKuesioner.DataValueField = "id_detailPeriode";
            ddlPeriodeDanJenisKuesioner.DataBind();
            ddlPeriodeDanJenisKuesioner.Items.Insert(0, new ListItem("-- Pilih Jenis dan Periode Kuesioner --", ""));
        }
    }
}