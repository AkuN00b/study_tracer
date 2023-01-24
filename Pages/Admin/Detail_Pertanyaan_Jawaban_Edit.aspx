<%@ Page Title="Detail Pertanyaan Jawaban" Language="C#" MasterPageFile="~/Layouts/Template.Master" AutoEventWireup="true" CodeBehind="Detail_Pertanyaan_Jawaban_Edit.aspx.cs" Inherits="study_tracer.Pages.Admin.Detail_Pertanyaan_Jawaban_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Detail Pertanyaan Jawaban Edit - Tracer Study</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <asp:Label ID="titleManipulasiData" runat="server" Font-Bold="True" Font-Size="Larger"></asp:Label>
    </center>
    <br />

    <div class="form-group">
        <asp:Label Text="Jawaban Kuesioner" CssClass="mb-1" runat="server" />
        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlJawabanKuesioner">
        </asp:DropDownList>
    </div>

    <div class="form-group">
        <asp:Label Text="Pertanyaan Turunan" CssClass="mb-1" runat="server" />
        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlPertanyaanTurunan">
        </asp:DropDownList>
    </div>

    <asp:LinkButton ID="btnKirim" OnClick="btnKirim_Click" CssClass="btn btn-primary btn-block mb-1" runat="server"><i class="fa fa-floppy-o"></i>&nbsp;Edit Data Detail Pertanyaan Jawaban</asp:LinkButton>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
