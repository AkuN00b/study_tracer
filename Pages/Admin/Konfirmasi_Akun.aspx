<%@ Page Title="Konfirmasi Akun" Language="C#" MasterPageFile="~/Layouts/Template.Master" AutoEventWireup="true" CodeBehind="Konfirmasi_Akun.aspx.cs" Inherits="study_tracer.Pages.Admin.Konfirmasi_Akun" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Konfirmasi Akun - Tracer Study</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <asp:Label Text="Daftar Akun Tracer Study Alumni" runat="server" Font-Bold="true" Font-Size="larger" />
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
            </div>
        </div>
    </div>
    <br />
    <div style="overflow-x: auto; width: 100%;">
        <asp:GridView runat="server" ID="gridDataAkunTracerStudyAlumni" CssClass="table table-hover table-bordered table-condensed table-striped grid scrollstyle" AllowPaging="true"
            AllowSorting="false" AutoGenerateColumns="false" DataKeyNames="id" EmptyDataText="Tidak ada Data Akun Tracer Study Alumni" PageSize="10" PagerStyle-CssClass="pagination-ys"
            ShowHeaderWhenEmpty="true" OnPageIndexChanging="gridDataAkunTracerStudyAlumni_PageIndexChanging" OnRowCommand="gridDataAkunTracerStudyAlumni_RowCommand" EmptyDataRowStyle-HorizontalAlign="Center">
            <PagerSettings Mode="NumericFirstLast" FirstPageText="<<" LastPageText=">>" />
            <Columns>
                <asp:TemplateField HeaderText="No." ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="id" HeaderText="ID Alumni" NullDisplayText="-" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="nim" HeaderText="Nomor Induk Mahasiswa" NullDisplayText="-" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="nik" HeaderText="Nomor Induk Kependudukan" NullDisplayText="-" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="nama" HeaderText="Nama Alumni" NullDisplayText="-" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="alamat" HeaderText="Alamat" NullDisplayText="-" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="tanggal_lahir" HeaderText="Tanggal Lahir" NullDisplayText="-" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="tahun_lulus" HeaderText="Tahun Lulus" NullDisplayText="-" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="email" HeaderText="Email Alumni" NullDisplayText="-" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="status" HeaderText="Status Akun" NullDisplayText="-" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="telepon" HeaderText="Nomor Telepon" NullDisplayText="-" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="created_by" HeaderText="Dibuat oleh" NullDisplayText="-" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="created_date" HeaderText="Dibuat pada" NullDisplayText="-" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="modified_by" HeaderText="Diubah oleh" NullDisplayText="-" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="modified_date" HeaderText="Diubah pada" NullDisplayText="-" ItemStyle-HorizontalAlign="Center" />
                <asp:TemplateField HeaderText="Aksi" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:HyperLink Text="Terima" ID="linkTerima" rel="tooltip" runat="server" data-placement="bottom"
                            title="Terima Akun Alumni" NavigateUrl='<%# "Konfirmasi_Akun_Update.aspx?idTerima=" + Eval("id")  %>'
                            Visible='<%# Eval("status").ToString() == "Belum Diverifikasi" %>'>
                            <i class="fa fa-check" aria-hidden="true"></i>
                        </asp:HyperLink>&nbsp;
                        <asp:HyperLink Text="Tolak" ID="linkTolak" rel="tooltip" runat="server" data-placement="bottom"
                            title="Tolak Akun Alumni" NavigateUrl='<%# "Konfirmasi_Akun_Update.aspx?idTolak=" + Eval("id")  %>'
                            Visible='<%# Eval("status").ToString() == "Belum Diverifikasi" %>'>
                            <i class="fa fa-times" aria-hidden="true"></i>
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Reset Password" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:HyperLink Text="Reset Password" ID="linkResetPassword" rel="tooltip" runat="server" data-placement="bottom"
                            title="Reset Password" NavigateUrl='<%# "Konfirmasi_Akun_Update.aspx?idRP=" + Eval("id")  %>'
                            Visible="true">
                                <i class="fa fa-edit" aria-hidden="true"></i>
                        </asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Update Data" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:HyperLink Text="Update Data" ID="linkUpdateData" rel="tooltip" runat="server" data-placement="bottom"
                            title="Update Data Alumni" NavigateUrl='<%# "Konfirmasi_Akun_Update.aspx?idUD=" + Eval("id")  %>'
                            Visible="true">
                                <i class="fa fa-edit" aria-hidden="true"></i>
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
