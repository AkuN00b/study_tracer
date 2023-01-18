<%@ Page Title="Jawaban Kuesioner" Language="C#" MasterPageFile="~/Layouts/Template.Master" AutoEventWireup="true" CodeBehind="Jawaban_Kuesioner.aspx.cs" Inherits="study_tracer.Pages.Admin.Jawaban_Kuesioner" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Jawaban Kuesioner - Tracer Study</title>    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel runat="server" ID="panelView">
        <center>
            <asp:Label ID="Label1" runat="server" Text="Daftar Jawaban Kuesioner" Font-Bold="True" Font-Size="Larger"></asp:Label>
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
            <asp:GridView runat="server" ID="gridDataJawabanKuesioner" CssClass="table table-hover table-bordered table-condensed table-striped grid scrollstyle" AllowPaging="true"
                AllowSorting="false" AutoGenerateColumns="false" DataKeyNames="id_jawabanKuesioner" EmptyDataText="Tidak ada Data Jawaban Kuesioner" PageSize="10" PagerStyle-CssClass="pagination-ys"
                ShowHeaderWhenEmpty="true" OnPageIndexChanging="gridDataJawabanKuesioner_PageIndexChanging" OnRowCommand="gridDataJawabanKuesioner_RowCommand">
                <PagerSettings Mode="NumericFirstLast" FirstPageText="<<" LastPageText=">>" />
                <Columns>
                    <asp:TemplateField HeaderText="No." ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="id_pku" HeaderText="ID Pertanyaan Kuesioner" NullDisplayText="-" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="id_jawabanKuesioner" HeaderText="ID Jawaban Kuesioner" NullDisplayText="-" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="deskripsiJawaban" HeaderText="Deskripsi Jawaban" NullDisplayText="-" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false" />
                    <asp:BoundField DataField="kode" HeaderText="Kode Jawaban" NullDisplayText="-" ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false" />
                    <asp:BoundField DataField="textbox" HeaderText="Textbox?" NullDisplayText="-" ItemStyle-HorizontalAlign="center" /> 
                    <asp:BoundField DataField="created_by" HeaderText="Dibuat oleh" NullDisplayText="-" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="created_date" HeaderText="Dibuat pada" NullDisplayText="-" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="modified_by" HeaderText="Diubah oleh" NullDisplayText="-" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="modified_date" HeaderText="Diubah pada" NullDisplayText="-" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="Aksi" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:LinkButton Text="Ubah" CssClass="btn btn-warning" ID="btnUbah" CommandName="Ubah" runat="server" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'></asp:LinkButton>&nbsp;
                            <asp:LinkButton Text="Hapus" CssClass="btn btn-danger" ID="btnHapus" CommandName="Hapus" runat="server" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </asp:Panel>

    <asp:Panel runat="server" ID="panelManipulasiData" Visible="false">
        <center>
            <asp:Label ID="titleManipulasiData" runat="server" Font-Bold="True" Font-Size="Larger"></asp:Label>
        </center>
        <br />

        <asp:TextBox runat="server" ID="tbId_jawabanKuesioner" Visible="false" />

        <div class="form-group">
            <asp:Label Text="Jawaban untuk Pertanyaan" CssClass="mb-1" runat="server" />
            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlPertanyaan">
            </asp:DropDownList>
        </div>

        <div class="form-group">
            <asp:Label Text="Deskripsi Jawaban" CssClass="mb-1" runat="server" />
            <asp:TextBox runat="server" ID="tbDeskripsiJawaban" CssClass="form-control" />
        </div>

        <div class="form-group">
            <asp:Label Text="Kode Jawaban" CssClass="mb-1" runat="server" />
            <asp:TextBox runat="server" ID="tbKodeJawaban" CssClass="form-control" />
        </div>

        <div class="form-group">
            <asp:Label Text="Butuh Textbox?" CssClass="mb-1" runat="server" />
            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlTextbox">
                <asp:ListItem Text="Ya" Value="Ya" />
                <asp:ListItem Text="Tidak" Value="Tidak" />
            </asp:DropDownList>
        </div>

        <asp:LinkButton ID="btnKirim" OnClick="btnKirim_Click" CssClass="btn btn-primary btn-block mb-1" runat="server"><i class="fa fa-floppy-o"></i>&nbsp;Tambah Data Jawaban Kuesioner</asp:LinkButton>
    </asp:Panel>
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
