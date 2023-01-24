<%@ Page Title="Pertanyaan Kuesioner" Language="C#" MasterPageFile="~/Layouts/Template.Master" AutoEventWireup="true" CodeBehind="Pertanyaan_Kuesioner_Tambah.aspx.cs" Inherits="study_tracer.Pages.Admin.Pertanyaan_Kuesioner_Tambah" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Pertanyaan Kuesioner Tambah - Tracer Study</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <asp:Label ID="titleManipulasiData" runat="server" Font-Bold="True" Font-Size="Larger"></asp:Label>
    </center>
    <br />

    <div class="form-group">
        <asp:Label Text="Deskripsi Pertanyaan" CssClass="mb-1" runat="server" />
        <asp:TextBox runat="server" ID="tbDeskripsiPertanyaan" CssClass="form-control" />
    </div>

    <div class="form-group">
        <asp:Label Text="Bentuk Jawaban" CssClass="mb-1" runat="server" />
        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlJenis">
            <asp:ListItem Text="-- Pilih Bentuk Jawaban --" />
            <asp:ListItem Text="Combo Box" Value="Combo Box" />
            <asp:ListItem Text="Radio Button" Value="Radio Button" />
            <asp:ListItem Text="Text Box" Value="Text Box" />
            <asp:ListItem Text="Check Box" Value="Check Box" />
            <asp:ListItem Text="DateTime Picker" Value="DateTime Picker" />
        </asp:DropDownList>
    </div>

    <div class="form-group">
        <asp:Label Text="Kode Pertanyaan" CssClass="mb-1" runat="server" />
        <asp:TextBox runat="server" ID="tbKodePertanyaan" CssClass="form-control" />
    </div>

    <div class="form-group">
        <asp:Label Text="Periode dan Jenis Kuesioner" CssClass="mb-1" runat="server" />
        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlPeriodeDanJenisKuesioner">
        </asp:DropDownList>
    </div>

    <div class="form-group">
        <asp:Label Text="Pertanyaan Utama?" CssClass="mb-1" runat="server" />
        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlPertanyaanUtama">
            <asp:ListItem Text="-- Pilih Apakah Pertanyaan Utama? --" />
            <asp:ListItem Text="Ya" Value="Ya" />
            <asp:ListItem Text="Tidak" Value="Tidak" />
        </asp:DropDownList>
    </div>

    <asp:LinkButton ID="btnKirimm" OnClick="btnKirimm_Click" CssClass="btn btn-primary btn-block mb-1" runat="server"><i class="fa fa-floppy-o"></i>&nbsp;Tambah Data Pertanyaan Kuesioner</asp:LinkButton>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
