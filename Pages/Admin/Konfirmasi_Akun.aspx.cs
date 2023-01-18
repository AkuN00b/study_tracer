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
    public partial class Konfirmasi_Akun : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
            }

            gridDataAkunTracerStudyAlumni.Width = Unit.Percentage(100);
        }

        protected void loadData()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@query", txtCari.Text);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ts_getDataRegistrasiAlumni";
            cmd.Connection = connection;

            try
            {
                connection.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // table konfirmasi akun
                    dt.Columns.Add(new DataColumn("id", typeof(string)));
                    dt.Columns.Add(new DataColumn("nim", typeof(string)));
                    dt.Columns.Add(new DataColumn("nik", typeof(string)));
                    dt.Columns.Add(new DataColumn("nama", typeof(string)));
                    dt.Columns.Add(new DataColumn("alamat", typeof(string)));
                    dt.Columns.Add(new DataColumn("tanggal_lahir", typeof(string)));
                    dt.Columns.Add(new DataColumn("tahun_lulus", typeof(string)));
                    dt.Columns.Add(new DataColumn("email", typeof(string)));
                    dt.Columns.Add(new DataColumn("status", typeof(string)));
                    dt.Columns.Add(new DataColumn("telepon", typeof(string)));
                    dt.Columns.Add(new DataColumn("created_by", typeof(string)));
                    dt.Columns.Add(new DataColumn("created_date", typeof(string)));
                    dt.Columns.Add(new DataColumn("modified_by", typeof(string)));
                    dt.Columns.Add(new DataColumn("modified_date", typeof(string)));

                    while (reader.Read())
                    {
                        DataRow dr = null;
                        dr = dt.NewRow();

                        dr["id"] = reader["id"];
                        dr["nim"] = reader["nim"];
                        dr["nik"] = reader["nik"];
                        dr["nama"] = reader["nama"];
                        dr["alamat"] = reader["alamat"];

                        DateTime date = new DateTime();
                        date = DateTime.Parse(reader["tanggal_lahir"].ToString());
                        string tempTanggalLahir = date.Day.ToString() + " " + getMonth(date.Month.ToString()) + " " + date.ToString("yyyy");

                        dr["tanggal_lahir"] = tempTanggalLahir;
                        dr["tahun_lulus"] = reader["tahun_lulus"];
                        dr["email"] = reader["email"];
                        dr["status"] = reader["status"];
                        dr["telepon"] = reader["telepon"];

                        dr["created_by"] = reader["created_by"];

                        date = DateTime.Parse(reader["created_date"].ToString());
                        tempTanggalLahir = date.Day.ToString() + " " + getMonth(date.Month.ToString()) + " " + date.ToString("yyyy") + " " + date.ToString("HH") + ":" + date.ToString("mm") + ":" + date.ToString("ss");
                        dr["created_date"] = tempTanggalLahir;

                        dr["modified_by"] = reader["modified_by"];

                        date = DateTime.Parse(reader["modified_date"].ToString());
                        tempTanggalLahir = date.Day.ToString() + " " + getMonth(date.Month.ToString()) + " " + date.ToString("yyyy") + " " + date.ToString("HH") + ":" + date.ToString("mm") + ":" + date.ToString("ss");
                        dr["modified_date"] = tempTanggalLahir;

                        dt.Rows.Add(dr);
                    }

                    gridDataAkunTracerStudyAlumni.DataSource = dt;
                    gridDataAkunTracerStudyAlumni.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        private string getMonth(string index)
        {
            string bulan = "";
            switch (index)
            {
                case "1": bulan = "Januari"; break;
                case "2": bulan = "Februari"; break;
                case "3": bulan = "Maret"; break;
                case "4": bulan = "April"; break;
                case "5": bulan = "Mei"; break;
                case "6": bulan = "Juni"; break;
                case "7": bulan = "Juli"; break;
                case "8": bulan = "Agustus"; break;
                case "9": bulan = "September"; break;
                case "10": bulan = "Oktober"; break;
                case "11": bulan = "November"; break;
                case "12": bulan = "Desember"; break;
            }
            return bulan;
        }

        protected void linkCari_Click(object sender, EventArgs e)
        {
            loadData();
        }

        protected void gridDataAkunTracerStudyAlumni_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridDataAkunTracerStudyAlumni.PageIndex = e.NewPageIndex;
            loadData();
        }

        protected void gridDataAkunTracerStudyAlumni_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}