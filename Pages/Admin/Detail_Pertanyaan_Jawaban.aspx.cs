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
    public partial class Detail_Pertanyaan_Jawaban : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
            }

            gridDataDetailPertanyaanJawaban.Width = Unit.Percentage(100);
        }

        protected void loadData()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand("ts_getDataDetailPertanyaanJawaban", connection);
            cmd.Parameters.AddWithValue("@query", txtCari.Text);
            cmd.CommandType = CommandType.StoredProcedure;
            dt.Load(cmd.ExecuteReader());

            gridDataDetailPertanyaanJawaban.DataSource = dt;
            gridDataDetailPertanyaanJawaban.DataBind();

            connection.Close();
        }

        protected void linkCari_Click(object sender, EventArgs e)
        {
            loadData();
        }

        protected void btnTambah_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Pages/Admin/Detail_Pertanyaan_Jawaban_Tambah.aspx");
        }

        protected void gridDataDetailPertanyaanJawaban_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridDataDetailPertanyaanJawaban.PageIndex = e.NewPageIndex;
            loadData();
        }

        protected void gridDataDetailPertanyaanJawaban_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void deleteDetailPertanyaanJawaban(string id)
        {

        }

        protected void btnKirim_Click(object sender, EventArgs e)
        {

        }
    }
}