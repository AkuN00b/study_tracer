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

namespace study_tracer
{
	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
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

		protected void btnLogin_Click(object sender, EventArgs e)
		{
			string role;

			if (txtUsername.Text == "" || txtPassword.Text == "")
			{
				Response.Write("<script>alert('Teks Kosong !!');</script>");
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
					command.Parameters.AddWithValue("@password", txtPassword.Text);
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

						Response.Redirect("/Pages/Admin/Dashboard.aspx");
					}
					else
					{
						DataTable dts = new DataTable();
						SqlConnection conns = new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
						conns.Open();

						SqlCommand commands = new SqlCommand("ts_LoginAlumni", conns);
						commands.Parameters.AddWithValue("@username", txtUsername.Text);
						commands.Parameters.AddWithValue("@password", txtPassword.Text);
						commands.CommandType = CommandType.StoredProcedure;

						SqlDataAdapter sdas = new SqlDataAdapter(commands);
						sdas.Fill(dts);

						conns.Close();

						if (dts.Rows.Count != 0)
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
						} else
						{
							Response.Write("<script>alert('Username atau Password tidak sesuai !!');</script>");
						}
					}
				}
				catch (Exception ex)
				{
					Response.Write("<script>alert('" + ex.Message.ToString() + "');</script>");
				}
			}
		}
	}
}