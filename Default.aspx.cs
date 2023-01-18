using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace study_tracer
{
	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
                if (Session["role"] == null)
                {

                }
                else
                {
                    if (Session["role"].ToString() == "Alumni")
                    {
                        Response.Redirect("/Pages/Alumni/Dashboard.aspx");
                    }
                    else if (Session["role"].ToString() == "Admin")
                    {
                        Response.Redirect("/Pages/Admin/Dashboard.aspx");
                    }
                }
            }
		}

		protected void btnLogin_Click(object sender, EventArgs e)
		{
			string role;

			if (txtUsername.Text == "" || txtPassword.Text == "")
			{
                ClientScript.RegisterStartupScript(this.GetType(), "Error", "tekskosong()", true);
            }
            else
			{
				try
				{
					DataTable dt = new DataTable();
					SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
					conn.Open();

					SqlCommand command = new SqlCommand("ts_LoginAdmin", conn);
					command.Parameters.AddWithValue("@username", txtUsername.Text);
					command.Parameters.AddWithValue("@password", EncryptPassword(txtPassword.Text, "030518"));
					command.CommandType = CommandType.StoredProcedure;

					SqlDataAdapter sda = new SqlDataAdapter(command);
					sda.Fill(dt);

					conn.Close();

					if (dt.Rows.Count != 0)
					{
						role = "Admin";

						Session["id"] = dt.Rows[0][0].ToString();
						Session["nama"] = dt.Rows[0][1].ToString();
						Session["role"] = role;

                        ClientScript.RegisterStartupScript(this.GetType(), "Error", "berhasilAdmin()", true);
					}
					else
					{
						DataTable dts = new DataTable();
						SqlConnection conns = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
						conns.Open();

						SqlCommand commands = new SqlCommand("ts_LoginAlumni", conns);
						commands.Parameters.AddWithValue("@username", txtUsername.Text);
						commands.Parameters.AddWithValue("@password", EncryptPassword(txtPassword.Text, "030518"));
						commands.CommandType = CommandType.StoredProcedure;

						SqlDataAdapter sdas = new SqlDataAdapter(commands);
						sdas.Fill(dts);

						conns.Close();

						if (dts.Rows.Count != 0)
						{
                            string status;
                            status = dts.Rows[0][9].ToString();

                            if (status.Equals("Diterima"))
                            {
                                role = "Alumni";

                                Session["id"] = dts.Rows[0][0].ToString();
                                Session["nim"] = dts.Rows[0][1].ToString();
                                Session["nik"] = dts.Rows[0][2].ToString();
                                Session["nama"] = dts.Rows[0][3].ToString();
                                Session["alamat"] = dts.Rows[0][4].ToString();
                                Session["tanggal_lahir"] = dts.Rows[0][5].ToString();
                                Session["tahun_lulus"] = dts.Rows[0][6].ToString();
                                Session["email"] = dts.Rows[0][7].ToString();
                                Session["telepon"] = dts.Rows[0][10].ToString();
                                Session["role"] = role;

                                Response.Redirect("/Pages/Alumni/Dashboard.aspx");
                            }
                            else if (status.Equals("Belum Diverifikasi"))
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "Error", "belumDiverifikasi()", true);
                            }
                            else if (status.Equals("Ditolak"))
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "Error", "ditolak()", true);
                            }
                        } else
						{
                            ClientScript.RegisterStartupScript(this.GetType(), "Error", "error()", true);
                        }
                    }
				}
				catch (Exception ex)
				{
					Response.Write("<script>alert('" + ex.Message.ToString() + "');</script>");
				}
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