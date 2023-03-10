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
    public partial class Detail_Pertanyaan_Jawaban_Tambah : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                titleManipulasiData.Text = "Detail Pertanyaan Jawaban Tambah";

                loadPertanyaanKuesionerTurunan();
                loadJawabanKuesioner();
            }
        }

        protected void loadPertanyaanKuesionerTurunan()
        {
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            conn.Open();

            ddlPertanyaanTurunan.DataSource = "";
            ddlPertanyaanTurunan.Items.Clear();
            SqlCommand com = new SqlCommand();
            com.Connection = conn;
            com.CommandText = "ts_getDataPertanyaanKuesionerTidakUtama";
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@query", "");

            SqlDataAdapter adap = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adap.Fill(dt);

            ddlPertanyaanTurunan.DataSource = dt;
            ddlPertanyaanTurunan.DataTextField = "ddlPKU";
            ddlPertanyaanTurunan.DataValueField = "id_pku";
            ddlPertanyaanTurunan.DataBind();
            ddlPertanyaanTurunan.Items.Insert(0, new ListItem("-- Pilih Pertanyaan Turunan --", ""));
        }

        protected void loadJawabanKuesioner()
        {
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            conn.Open();

            ddlJawabanKuesioner.DataSource = "";
            ddlJawabanKuesioner.Items.Clear();
            SqlCommand com = new SqlCommand();
            com.Connection = conn;
            com.CommandText = "ts_getDataJawabanKuesioner";
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@query", "");

            SqlDataAdapter adap = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adap.Fill(dt);

            ddlJawabanKuesioner.DataSource = dt;
            ddlJawabanKuesioner.DataTextField = "ddlJK";
            ddlJawabanKuesioner.DataValueField = "id_jawabanKuesioner";
            ddlJawabanKuesioner.DataBind();
            ddlJawabanKuesioner.Items.Insert(0, new ListItem("-- Pilih Jawaban Kuesioner --", ""));
        }

        protected void btnKirim_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                conn.Open();

                SqlCommand command = new SqlCommand("ts_InsertDetailPertanyaanJawaban", conn);
                command.Parameters.AddWithValue("@nama", Session["nama"].ToString());
                command.Parameters.AddWithValue("@id_jawabanKuesioner", ddlJawabanKuesioner.SelectedValue.ToString());
                command.Parameters.AddWithValue("@id_pku_answer", ddlPertanyaanTurunan.SelectedValue.ToString());

                command.CommandType = CommandType.StoredProcedure;
                dt.Load(command.ExecuteReader());

                conn.Close();

                ClientScript.RegisterStartupScript(this.GetType(), "Error", "berhasilTambahDataDPJ()", true);
            }
            catch { }
        }
    }
}