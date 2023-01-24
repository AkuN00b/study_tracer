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
    public partial class Detail_Pertanyaan_Jawaban_Hapus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                if (!IsPostBack)
                {
                    try
                    {
                        DataTable dt = new DataTable();

                        SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                        conn.Open();

                        SqlCommand command = new SqlCommand("ts_DeleteDetailPertanyaanJawaban", conn);
                        command.Parameters.AddWithValue("@id", Request.QueryString["id"]);
                        command.CommandType = CommandType.StoredProcedure;

                        dt.Load(command.ExecuteReader());

                        conn.Close();

                        Response.Redirect("/Pages/Admin/Detail_Pertanyaan_Jawaban.aspx");
                    }
                    catch { }
                }
            }
            else
            {
                Response.Write("<script>window.history.go(-1);</script>");
            }
        }
    }
}