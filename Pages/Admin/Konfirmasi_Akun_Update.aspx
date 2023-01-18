<%@ Page Title="Konfirmasi Akun" Language="C#" MasterPageFile="~/Layouts/Template.Master" AutoEventWireup="true" CodeBehind="Konfirmasi_Akun_Update.aspx.cs" Inherits="study_tracer.Pages.Admin.Konfirmasi_Akun_Update" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Konfirmasi Akun - Tracer Study</title>   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel runat="server" ID="resetPassword">
        <center>
            <asp:Label text="Reset Password Akun Alumni" runat="server" Font-Bold="True" Font-Size="Larger"></asp:Label>
        </center>
        <br />

        <div class="form-group">
            <asp:Label Text="Password Baru" CssClass="mb-1" runat="server" />
            <asp:TextBox runat="server" type="password" ID="tbPasswordBaru" CssClass="form-control" />
        </div>

        <asp:LinkButton ID="btnResetPassword" OnClick="btnResetPassword_Click" CssClass="btn btn-primary btn-block mb-1" runat="server"><i class="fa fa-floppy-o"></i> Reset Password</asp:LinkButton>
    </asp:Panel>

    <asp:Panel runat="server" ID="updateData">
        <center>
            <asp:Label text="Update Data Akun Alumni" runat="server" Font-Bold="True" Font-Size="Larger"></asp:Label>
        </center>
        <br />

        <div class="form-group">
            <asp:Label Text="Nama" CssClass="mb-1" runat="server" />
            <asp:TextBox runat="server" ID="tbNama" CssClass="form-control" />
        </div>

        <div class="form-group">
            <asp:Label Text="Tahun Lulus" CssClass="mb-1" runat="server" />
            <asp:TextBox MaxLength="4" runat="server" ID="tbTahunLulus" CssClass="form-control" />
        </div>

        <asp:LinkButton ID="btnUpdateData" OnClick="btnUpdateData_Click" CssClass="btn btn-primary btn-block mb-1" runat="server"><i class="fa fa-floppy-o"></i> Edit Data Alumni</asp:LinkButton>
    </asp:Panel>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

</asp:Content>
