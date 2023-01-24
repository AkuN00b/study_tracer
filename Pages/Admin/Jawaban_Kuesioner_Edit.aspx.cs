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
    public partial class Jawaban_Kuesioner_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                if (!IsPostBack)
                {
                    try
                    {
                        loadPertanyaanKuesioner();

                        DataTable dt = new DataTable();

                        SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                        conn.Open();

                        SqlCommand command = new SqlCommand("ts_getDataForUpdateJawabanKuesioner", conn);
                        command.Parameters.AddWithValue("@id", Request.QueryString["id"]);
                        command.CommandType = CommandType.StoredProcedure;

                        dt.Load(command.ExecuteReader());

                        ddlPertanyaan.SelectedValue = dt.Rows[0][0].ToString();
                        tbDeskripsiJawaban.Text = dt.Rows[0][1].ToString();
                        tbKodeJawaban.Text = dt.Rows[0][2].ToString();
                        tbNilaiJawaban.Text = dt.Rows[0][3].ToString();
                        ddlTextbox.SelectedValue = dt.Rows[0][4].ToString();

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

        protected void btnKirim_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                conn.Open();

                SqlCommand command = new SqlCommand("ts_UpdateJawabanKuesioner", conn);
                command.Parameters.AddWithValue("@id", Request.QueryString["id"]);
                command.Parameters.AddWithValue("@id_pku", ddlPertanyaan.SelectedValue.ToString());
                command.Parameters.AddWithValue("@nama", Session["nama"].ToString());
                command.Parameters.AddWithValue("@deskripsiJawaban", tbDeskripsiJawaban.Text);
                command.Parameters.AddWithValue("@kode", tbKodeJawaban.Text);
                command.Parameters.AddWithValue("@nilaiJawaban", tbNilaiJawaban.Text);
                command.Parameters.AddWithValue("@textbox", ddlTextbox.SelectedValue.ToString());
                command.CommandType = CommandType.StoredProcedure;
                dt.Load(command.ExecuteReader());

                conn.Close();

                Response.Redirect("/Pages/Admin/Jawaban_Kuesioner.aspx");
            }
            catch { }
        }

        protected void loadPertanyaanKuesioner()
        {
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            conn.Open();

            ddlPertanyaan.DataSource = "";
            ddlPertanyaan.Items.Clear();
            SqlCommand com = new SqlCommand();
            com.Connection = conn;
            com.CommandText = "ts_getDataPertanyaanKuesioner";
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@query", "");

            SqlDataAdapter adap = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adap.Fill(dt);

            ddlPertanyaan.DataSource = dt;
            ddlPertanyaan.DataTextField = "ddlPKU";
            ddlPertanyaan.DataValueField = "id_pku";
            ddlPertanyaan.DataBind();
            ddlPertanyaan.Items.Insert(0, new ListItem("-- Pilih Pertanyaan Kuesioner --", ""));
        }
    }
}