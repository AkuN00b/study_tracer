using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace study_tracer
{
	public partial class Register : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                tbAlamat.TextMode = TextBoxMode.MultiLine;
                tbAlamat.Rows = 10;
                loadTahunLulus();
            }
        }

        protected void loadTahunLulus()
        {
            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            conn.Open();

            ddlTahunLulus.DataSource = "";
            ddlTahunLulus.Items.Clear();

            SqlCommand com = new SqlCommand();
            com.Connection = conn;
            com.CommandText = "ts_LoadTahunLulus";
            com.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adap = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adap.Fill(dt);

            ddlTahunLulus.DataSource = dt;
            ddlTahunLulus.DataTextField = "Years";
            ddlTahunLulus.DataValueField = "Years";
            ddlTahunLulus.DataBind();
            ddlTahunLulus.Items.Insert(0, new ListItem("-- Pilih Tahun Lulus --", ""));
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

        }

        protected void btnDaftar_Click(object sender, EventArgs e)
        {
            registrasiAlumni();
        }

        protected void registrasiAlumni()
        {
            string pass1 = tbPassword.Text;
            string pass2 = tbKonfirmasiPassword.Text;

            if (pass1.Trim() == pass2.Trim())
            {
                try
                {
                    DataTable dt = new DataTable();
                    SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                    conn.Open();

                    SqlCommand command = new SqlCommand("ts_InsertRegistrasiAlumni", conn);
                    command.Parameters.AddWithValue("@nim", tbNIM.Text);
                    command.Parameters.AddWithValue("@nik", tbNIK.Text);
                    command.Parameters.AddWithValue("@nama", tbNama.Text);
                    command.Parameters.AddWithValue("@alamat", tbAlamat.Text);
                    command.Parameters.AddWithValue("@tanggal_lahir", tbTanggalLahir.Text);
                    command.Parameters.AddWithValue("@tahun_lulus", ddlTahunLulus.SelectedValue.ToString());
                    command.Parameters.AddWithValue("@email", tbEmail.Text);

                    string encrypt = EncryptPassword(tbPassword.Text, "030518");
                    command.Parameters.AddWithValue("@password", encrypt);
                    command.Parameters.AddWithValue("@telepon", tbTelepon.Text);
                    command.CommandType = CommandType.StoredProcedure;
                    dt.Load(command.ExecuteReader());

                    conn.Close();

                    ClientScript.RegisterStartupScript(this.GetType(), "Error", "berhasilDaftar()", true);
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message.ToString() + "');</script>");
                }
            } else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Error", "passwordTidakSama()", true);
            }
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