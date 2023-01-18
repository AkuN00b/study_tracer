<%@ Page Title="Detail Jenis Periode" Language="C#" MasterPageFile="~/Layouts/Template.Master" AutoEventWireup="true" CodeBehind="Detail_Jenis_Periode_Edit.aspx.cs" Inherits="study_tracer.Pages.Admin.Detail_Jenis_Periode_Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Detail Jenis Periode Edit - Tracer Study</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <asp:Label ID="titleManipulasiData" runat="server" Font-Bold="True" Font-Size="Larger"></asp:Label>
    </center>
    <br />

    <asp:TextBox runat="server" ID="tbId_detailPeriode" Visible="false" />

    <div class="form-group">
        <asp:Label Text="Jenis Kuesioner" CssClass="mb-1" runat="server" />
        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlJenisKuesioner">
            <asp:ListItem Text="-- Pilih Jenis Kuesioner --" Value="" />
            <asp:ListItem Text="Polman" Value="Polman" />
            <asp:ListItem Text="Dikti" Value="Dikti" />
        </asp:DropDownList>
    </div>

    <div class="form-group">
        <asp:Label Text="Periode" CssClass="mb-1" runat="server" />
        <asp:TextBox MaxLength="4" runat="server" ID="tbPeriode" CssClass="form-control" />
    </div>

    <asp:LinkButton ID="btnKirim" OnClick="btnKirim_Click" CssClass="btn btn-primary btn-block mb-1" runat="server"><i class="fa fa-floppy-o"></i> Edit Data Detail Jenis Periode</asp:LinkButton>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

</asp:Content>
