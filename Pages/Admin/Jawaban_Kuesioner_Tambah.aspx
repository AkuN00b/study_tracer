<%@ Page Title="Jawaban Kuesioner" Language="C#" MasterPageFile="~/Layouts/Template.Master" AutoEventWireup="true" CodeBehind="Jawaban_Kuesioner_Tambah.aspx.cs" Inherits="study_tracer.Pages.Admin.Jawaban_Kuesioner_Tambah" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Jawaban Kuesioner Tambah - Tracer Study</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
        <asp:Label Text="Nilai Jawaban" CssClass="mb-1" runat="server" />
        <asp:TextBox runat="server" ID="tbNilaiJawaban" CssClass="form-control" />
    </div>

    <div class="form-group">
        <asp:Label Text="Butuh Textbox?" CssClass="mb-1" runat="server" />
        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlTextbox">
            <asp:ListItem Text="-- Pilih Butuh Textbox? --" />
            <asp:ListItem Text="Ya" Value="Ya" />
            <asp:ListItem Text="Tidak" Value="Tidak" />
        </asp:DropDownList>
    </div>

    <asp:LinkButton ID="btnKirim" OnClick="btnKirim_Click" CssClass="btn btn-primary btn-block mb-1" runat="server"><i class="fa fa-floppy-o"></i>&nbsp;Tambah Data Jawaban Kuesioner</asp:LinkButton>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
