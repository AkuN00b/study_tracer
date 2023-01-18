using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace study_tracer.Pages.Admin
{
    public partial class Pertanyaan_Kuesioner : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tbDeskripsiPertanyaan.TextMode = TextBoxMode.MultiLine;
                tbDeskripsiPertanyaan.Rows = 10;
                loadData();
            }

            gridDataPertanyaanKuesioner.Width = Unit.Percentage(100);
        }

        protected void loadData()
        {

        }

        protected void linkCari_Click(object sender, EventArgs e)
        {

        }

        protected void gridDataPertanyaanKuesioner_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridDataPertanyaanKuesioner.PageIndex = e.NewPageIndex;
            loadData();
        }

        protected void gridDataPertanyaanKuesioner_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "Page")
            {
                string tempId = gridDataPertanyaanKuesioner.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();

                if (e.CommandName == "Hapus")
                {
                    deleteDataPKU(tempId);
                } else if (e.CommandName == "Ubah")
                {

                }
            }
        }

        protected void deleteDataPKU(string id)
        {

        }

        protected void btnTambah_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnKirim_Click(object sender, EventArgs e)
        {

        }

        protected void btnTambahh_Click(object sender, EventArgs e)
        {
            panelView.Visible = false;
            panelManipulasiData.Visible = true;

            titleManipulasiData.Text = "Form Tambah Data Pertanyaan Kuesioner";
        }

        protected void btnKirimm_Click(object sender, EventArgs e)
        {

        }
    }
}