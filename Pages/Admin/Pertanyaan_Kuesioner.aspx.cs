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
    public partial class Pertanyaan_Kuesioner : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
            }

            gridDataPertanyaanKuesioner.Width = Unit.Percentage(100);
        }

        protected void loadData()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand("ts_getDataPertanyaanKuesioner", connection);
            cmd.Parameters.AddWithValue("@query", txtCari.Text);
            cmd.CommandType = CommandType.StoredProcedure;
            dt.Load(cmd.ExecuteReader());

            gridDataPertanyaanKuesioner.DataSource = dt;
            gridDataPertanyaanKuesioner.DataBind();

            connection.Close();
        }

        protected void linkCari_Click(object sender, EventArgs e)
        {
            loadData();
        }

        protected void gridDataPertanyaanKuesioner_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridDataPertanyaanKuesioner.PageIndex = e.NewPageIndex;
            loadData();
        }

        protected void gridDataPertanyaanKuesioner_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        
        }

        protected void deleteDataPKU(string id)
        {

        }

        protected void btnTambah_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnKirim_Click(object sender, EventArgs e)
        {

        }

        protected void btnTambahh_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Pages/Admin/Pertanyaan_Kuesioner_Tambah.aspx");
        }

        protected void btnKirimm_Click(object sender, EventArgs e)
        {

        }
    }
}