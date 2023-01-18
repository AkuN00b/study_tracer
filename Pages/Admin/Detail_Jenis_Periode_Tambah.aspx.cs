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
    public partial class Detail_Jenis_Periode_Tambah : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                titleManipulasiData.Text = "Detail Jenis Periode Tambah";
            }
        }

        protected void btnKirim_Click(object sender, EventArgs e)
        {

        }

        protected void btnKirim_Click1(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                conn.Open();

                SqlCommand command = new SqlCommand("ts_InsertDetailJenisPeriode", conn);
                command.Parameters.AddWithValue("@nama", Session["nama"].ToString());
                command.Parameters.AddWithValue("@jenis_kuesioner", ddlJenisKuesioner.SelectedValue.ToString());
                command.Parameters.AddWithValue("@periode", tbPeriode.Text);

                command.CommandType = CommandType.StoredProcedure;
                dt.Load(command.ExecuteReader());

                conn.Close();

                ClientScript.RegisterStartupScript(this.GetType(), "Error", "berhasilTambahDataDJP()", true);
            }
            catch { }
        }
    }
}