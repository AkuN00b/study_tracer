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
    public partial class Jawaban_Kuesioner : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
            }

            gridDataJawabanKuesioner.Width = Unit.Percentage(100);
        }

        protected void loadData()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand("ts_getDataJawabanKuesioner", connection);
            cmd.Parameters.AddWithValue("@query", txtCari.Text);
            cmd.CommandType = CommandType.StoredProcedure;
            dt.Load(cmd.ExecuteReader());

            gridDataJawabanKuesioner.DataSource = dt;
            gridDataJawabanKuesioner.DataBind();

            connection.Close();
        }

        protected void linkCari_Click(object sender, EventArgs e)
        {
            loadData();
        }

        protected void btnTambah_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Pages/Admin/Jawaban_Kuesioner_Tambah.aspx");
        }

        protected void gridDataJawabanKuesioner_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridDataJawabanKuesioner.PageIndex = e.NewPageIndex;
            loadData();
        }

        protected void gridDataJawabanKuesioner_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
        }

        protected void deleteDataJawabanKuesioner(string id)
        {

        }

        protected void btnKirim_Click(object sender, EventArgs e)
        {

        }
    }
}