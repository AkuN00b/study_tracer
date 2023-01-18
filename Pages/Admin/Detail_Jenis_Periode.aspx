<%@ Page Title="Detail Jenis Periode" Language="C#" MasterPageFile="~/Layouts/Template.Master" AutoEventWireup="true" CodeBehind="Detail_Jenis_Periode.aspx.cs" Inherits="study_tracer.Pages.Admin.Detail_Jenis_Periode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Detail Jenis Periode - Tracer Study</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <asp:Label Text="Daftar Detail Jenis Periode" runat="server" Font-Bold="true" Font-Size="larger" />
    </center>
    <br />

    <div class="row">
        <div class="col-lg-12">
            <div class="input-group">
                <asp:TextBox runat="server" CssClass="form-control" ID="txtCari" placeholder="Pencarian" />
                <span class="input-group-btn">
                    <asp:LinkButton runat="server" ID="linkCari" CssClass="btn btn-secondary" OnClick="linkCari_Click"><i class="fa fa-search"></i>&nbsp;Cari</asp:LinkButton>
                </span>

                <span class="input-group-btn">
                    <button class="btn btn-success dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="true"><i class="fa fa-filter"></i>&nbsp;Filter</button>
                    <div class="dropdown-menu dropdown-menu-right" style="padding: 20px; min-width: 300px !important;">
                        <div class="form-group">
                            <label style='font-weight: bold;' for="ddStatus">Status</label>
                            <asp:DropDownList runat="server" ID="ddStatus" CssClass="form-control dropdown" Style="min-width: 260px !important;">
                                <asp:ListItem Text="-- Semua --" Value="3"></asp:ListItem>
                                <asp:ListItem Text="Belum Diverifikasi" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Diterima" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Ditolak" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </span>

                <span class="input-group-btn">
                    <asp:LinkButton runat="server" ID="btnTambah" CssClass="btn btn-primary" OnClick="btnTambah_Click"><i class="fa fa-plus"></i>&nbsp;Tambah</asp:LinkButton>
                </span>
            </div>
        </div>
    </div>
    <br />
    <div style="overflow-x: auto; width: 100%;">
        <asp:GridView runat="server" ID="gridDataDetailJenisPeriode" CssClass="table table-hover table-bordered table-condensed table-striped grid scrollstyle" AllowPaging="true"
            AllowSorting="false" AutoGenerateColumns="false" DataKeyNames="id_detailPeriode" EmptyDataText="Tidak ada Data Detail Jenis Periode" PageSize="10" PagerStyle-CssClass="pagination-ys"
            ShowHeaderWhenEmpty="true" OnPageIndexChanging="gridDataDetailJenisPeriode_PageIndexChanging" OnRowCommand="gridDataDetailJenisPeriode_RowCommand" EmptyDataRowStyle-HorizontalAlign="Center">
            <PagerSettings Mode="NumericFirstLast" FirstPageText="<<" LastPageText=">>" />
            <Columns>
                <asp:TemplateField HeaderText="No." ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="id_detailPeriode" HeaderText="ID Detail Jenis Periode" NullDisplayText="-" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="jenis_kuesioner" HeaderText="Jenis Kuesioner" NullDisplayText="-" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="periode" HeaderText="Periode (Tahun)" NullDisplayText="-" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="created_by" HeaderText="Dibuat oleh" NullDisplayText="-" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="created_date" HeaderText="Dibuat pada" NullDisplayText="-" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="modified_by" HeaderText="Diubah oleh" NullDisplayText="-" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="modified_date" HeaderText="Diubah pada" NullDisplayText="-" ItemStyle-HorizontalAlign="Center" />
                <asp:TemplateField HeaderText="Aksi" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:HyperLink Text="Ubah" ID="linkUbah" rel="tooltip" runat="server" data-placement="bottom" 
                            title="Ubah Detail Jenis Periode" NavigateUrl='<%# "Detail_Jenis_Periode_Edit.aspx?id=" + Eval("id_detailPeriode")  %>' 
                            Visible="true">
                            <i class="fa fa-edit" aria-hidden="true"></i>
                        </asp:HyperLink>&nbsp;
                        <asp:HyperLink Text="Hapus" ID="linkHapus" rel="tooltip" runat="server" data-placement="bottom" 
                            title="Hapus Detail Jenis Periode" NavigateUrl='<%# "Detail_Jenis_Periode_Hapus.aspx?id=" + Eval("id_detailPeriode")  %>' 
                            Visible="true">
                            <i class="fa fa-trash" aria-hidden="true"></i>
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script type="text/javascript">
        $('.dropdown-menu').click(function (event) {
            event.stopPropagation();
        });

        function Selectall() {
            if ($('.checkAll_parent').is(':checked')) {
                // .checkAll_child cssClass will be assigned to all other checkboxes in your control
                $('.checkAll_child').attr('checked', 'true');
            }
            else {
                $('.checkAll_child').removeAttr('checked', 'false');
            }
        }

        function checkAllCheckbox() {
            $(".checkAll_child").change(function () {
                //if ($('.checkAll_child:checked').length == $('.checkAll_child').length) {
                //    //do something

                //}
                alert($('.checkAll_child').length);
            });
        }
    </script>
</asp:Content>
