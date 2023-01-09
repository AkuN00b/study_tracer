<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Template_Login.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="study_tracer.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Login - Tracer Study</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="polman-form-login">
        <h4>Login Tracer Study</h4>
        <hr />

        <div class="form-group">
            <label for="txtUsername">
                Nomor Induk Mahasiswa (NIM)
                <span style="color: red;">*</span>
            </label>
            <asp:TextBox runat="server" ID="txtUsername" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtPassword">
                Kata Sandi
                <span style="color: red;">*</span>
            </label>
            <asp:TextBox runat="server" TextMode="Password" ID="txtPassword" CssClass="form-control" />
        </div>

        <asp:Button Text="Masuk" runat="server" CssClass="btn btn-primary" Width="100%" id="btnLogin" OnClick="btnLogin_Click" /><br />
        <span style="margin-top: 20px;">Belum Terdaftar Sebagai Alumni? <a href='/Register.aspx'>Klik disini</a>.</span>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script type="text/javascript">
        function showAlert() {
            $("#txtUsername").effect("shake");
            $("#txtPassword").effect("shake");
        }

        function showAlertCaptcha() {
            $("#txtCaptcha").effect("shake");
        }
    </script>
</asp:Content>
