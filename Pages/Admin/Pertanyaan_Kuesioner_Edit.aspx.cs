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
    public partial class Pertanyaan_Kuesioner_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                if (!IsPostBack)
                {
                    try
                    {
                        tbDeskripsiPertanyaan.TextMode = TextBoxMode.MultiLine;
                        tbDeskripsiPertanyaan.Rows = 10;

                        loadDetailPeriode();

                        DataTable dt = new DataTable();

                        SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                        conn.Open();

                        SqlCommand command = new SqlCommand("ts_getDataForUpdatePertanyaanKuesioner", conn);
                        command.Parameters.AddWithValue("@id", Request.QueryString["id"]);
                        command.CommandType = CommandType.StoredProcedure;

                        dt.Load(command.ExecuteReader());

                        tbDeskripsiPertanyaan.Text = dt.Rows[0][0].ToString();
                        ddlJenis.SelectedValue = dt.Rows[0][1].ToString();
                        tbKodePertanyaan.Text = dt.Rows[0][2].ToString();
                        ddlPeriodeDanJenisKuesioner.SelectedValue = dt.Rows[0][3].ToString();
                        ddlPertanyaanUtama.SelectedValue = dt.Rows[0][4].ToString();

                        conn.Close();
                    }
                    catch { }
                }
            }
            else
            {
                Response.Write("<script>window.history.go(-1);</script>");
            }
        }

        protected void btnKirimm_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                conn.Open();

                SqlCommand command = new SqlCommand("ts_UpdatePertanyaanKuesioner", conn);
                command.Parameters.AddWithValue("@id", Request.QueryString["id"]);
                command.Parameters.AddWithValue("@nama", Session["nama"].ToString());
                command.Parameters.AddWithValue("@deskripsiPertanyaan", tbDeskripsiPertanyaan.Text);
                command.Parameters.AddWithValue("@jenis", ddlJenis.SelectedValue.ToString());
                command.Parameters.AddWithValue("@kode", tbKodePertanyaan.Text);
                command.Parameters.AddWithValue("@id_detailPeriode", ddlPeriodeDanJenisKuesioner.SelectedValue.ToString());
                command.Parameters.AddWithValue("@pertanyaan_utama", ddlPertanyaanUtama.SelectedValue.ToString());
                command.CommandType = CommandType.StoredProcedure;
                dt.Load(command.ExecuteReader());

                conn.Close();

                Response.Redirect("/Pages/Admin/Pertanyaan_Kuesioner.aspx");
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