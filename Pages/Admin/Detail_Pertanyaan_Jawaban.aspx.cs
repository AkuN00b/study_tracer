using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace study_tracer.Pages.Admin
{
    public partial class Detail_Pertanyaan_Jawaban : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
            }

            gridDataDetailPertanyaanJawaban.Width = Unit.Percentage(100);
        }

        protected void loadData()
        {

        }

        protected void linkCari_Click(object sender, EventArgs e)
        {

        }

        protected void btnTambah_Click(object sender, EventArgs e)
        {
            panelView.Visible = false;
            panelManipulasiData.Visible = true;

            titleManipulasiData.Text = "Form Tambah Data Detail Pertanyaan Jawaban";
        }

        protected void gridDataDetailPertanyaanJawaban_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridDataDetailPertanyaanJawaban.PageIndex = e.NewPageIndex;
            loadData();
        }

        protected void gridDataDetailPertanyaanJawaban_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "Page")
            {
                string tempId = gridDataDetailPertanyaanJawaban.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();

                if (e.CommandName == "Hapus")
                {
                    deleteDetailPertanyaanJawaban(tempId);
                }
                else if (e.CommandName == "Ubah")
                {

                }
            }
        }

        protected void deleteDetailPertanyaanJawaban(string id)
        {

        }

        protected void btnKirim_Click(object sender, EventArgs e)
        {

        }
    }
}