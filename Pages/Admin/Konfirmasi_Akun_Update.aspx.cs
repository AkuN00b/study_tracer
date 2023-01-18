using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;

namespace study_tracer.Pages.Admin
{
    public partial class Konfirmasi_Akun_Update : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                resetPassword.Visible = false;
                updateData.Visible = false;

                if (Request.QueryString["idTerima"] != null)
                {
                    DataTable dt = new DataTable();

                    SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                    conn.Open();

                    SqlCommand command = new SqlCommand("ts_UpdateAlumniDiterima", conn);
                    command.Parameters.AddWithValue("@id", Request.QueryString["idTerima"]);
                    command.Parameters.AddWithValue("@namaAdmin", Session["nama"].ToString());
                    command.CommandType = CommandType.StoredProcedure;

                    dt.Load(command.ExecuteReader());

                    conn.Close();

                    Response.Redirect("/Pages/Admin/Konfirmasi_Akun.aspx");
                } else if (Request.QueryString["idTolak"] != null)
                {
                    DataTable dt = new DataTable();

                    SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                    conn.Open();

                    SqlCommand command = new SqlCommand("ts_UpdateAlumniDitolak", conn);
                    command.Parameters.AddWithValue("@id", Request.QueryString["idTolak"]);
                    command.Parameters.AddWithValue("@namaAdmin", Session["nama"].ToString());
                    command.CommandType = CommandType.StoredProcedure;

                    dt.Load(command.ExecuteReader());

                    conn.Close();

                    Response.Redirect("/Pages/Admin/Konfirmasi_Akun.aspx");
                } else if (Request.QueryString["idRP"] != null)
                {
                    resetPassword.Visible = true;
                } else if (Request.QueryString["idUD"] != null)
                {
                    updateData.Visible = true;

                    DataTable dt = new DataTable();

                    SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                    conn.Open();

                    SqlCommand command = new SqlCommand("ts_getDataForUpdateAlumni", conn);
                    command.Parameters.AddWithValue("@id", Request.QueryString["idUD"]);
                    command.CommandType = CommandType.StoredProcedure;

                    dt.Load(command.ExecuteReader());

                    tbNama.Text = dt.Rows[0][0].ToString();
                    tbTahunLulus.Text = dt.Rows[0][1].ToString();

                    conn.Close();
                } else
                {
                    Response.Redirect("/Pages/Admin/Konfirmasi_Akun.aspx");
                }
            }
        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            conn.Open();

            SqlCommand command = new SqlCommand("ts_UpdateAlumniResetPassword", conn);
            command.Parameters.AddWithValue("@id", Request.QueryString["idRP"]);

            string encrypt = EncryptPassword(tbPasswordBaru.Text, "030518");
            command.Parameters.AddWithValue("@password", encrypt);
            command.Parameters.AddWithValue("@namaAdmin", Session["nama"].ToString());
            command.CommandType = CommandType.StoredProcedure;

            dt.Load(command.ExecuteReader());

            conn.Close();

            Response.Redirect("/Pages/Admin/Konfirmasi_Akun.aspx");
        }

        protected void btnUpdateData_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            conn.Open();

            SqlCommand command = new SqlCommand("ts_UpdateAlumni", conn);
            command.Parameters.AddWithValue("@id", Request.QueryString["idUD"]);
            command.Parameters.AddWithValue("@nama", tbNama.Text);
            command.Parameters.AddWithValue("@namaAdmin", Session["nama"].ToString());
            command.Parameters.AddWithValue("@tahunLulus", tbTahunLulus.Text);
            command.CommandType = CommandType.StoredProcedure;

            dt.Load(command.ExecuteReader());

            conn.Close();

            Response.Redirect("/Pages/Admin/Konfirmasi_Akun.aspx");
        }

        public string EncryptPassword(string password, string key)
        {
            string plainText = "";
            using (MD5 md5Hash = MD5.Create())
            {
                plainText = GetMd5Hash(md5Hash, password + key);
            }

            plainText = Base64Encode(plainText);
            for (int i = 1; i <= 10; i++)
            {
                plainText = Scramble(plainText);
            }

            return plainText;
        }

        private static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] array = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
                stringBuilder.Append(array[i].ToString("x2"));
            }

            return stringBuilder.ToString();
        }

        private static string Base64Encode(string plainText)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(bytes);
        }

        private static string Base64Decode(string base64EncodedData)
        {
            byte[] bytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(bytes);
        }

        private string Scramble(string param)
        {
            string text = "";
            string text2 = "";
            string text3 = "";
            for (int i = 0; i < param.Length; i++)
            {
                if (isEven(i))
                {
                    text2 += param[i];
                }
                else
                {
                    text3 += param[i];
                }
            }

            return text2 + text3;
        }

        private bool isEven(int bilangan)
        {
            if (bilangan % 2 == 0)
            {
                return true;
            }

            return false;
        }
    }
}