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
    public partial class Detail_Jenis_Periode_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["id"] != null)
            {
                if (!IsPostBack)
                {
                    try
                    {
                        DataTable dt = new DataTable();

                        SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                        conn.Open();

                        SqlCommand command = new SqlCommand("ts_getDataForUpdateDetailJenisPeriode", conn);
                        command.Parameters.AddWithValue("@id", Request.QueryString["id"]);
                        command.CommandType = CommandType.StoredProcedure;

                        dt.Load(command.ExecuteReader());

                        tbId_detailPeriode.Text = Request.QueryString["id"].ToString();
                        ddlJenisKuesioner.SelectedValue = dt.Rows[0][0].ToString();
                        tbPeriode.Text = dt.Rows[0][1].ToString();

                        conn.Close();
                    }
                    catch { }
                }
            } else
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

                SqlCommand command = new SqlCommand("ts_UpdateDetailJenisPeriode", conn);
                command.Parameters.AddWithValue("@id", Request.QueryString["id"]);
                command.Parameters.AddWithValue("@nama", Session["nama"].ToString());
                command.Parameters.AddWithValue("@jenis_kuesioner", ddlJenisKuesioner.SelectedValue.ToString());
                command.Parameters.AddWithValue("@periode", tbPeriode.Text);
                command.CommandType = CommandType.StoredProcedure;
                dt.Load(command.ExecuteReader());

                conn.Close();

                Response.Redirect("/Pages/Admin/Detail_Jenis_Periode.aspx");
            }
            catch { }
        }
    }
}