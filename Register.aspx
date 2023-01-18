<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Template_Login.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Register.aspx.cs" Inherits="study_tracer.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Register - Tracer Study</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid p-4" style="background-color: white; border-radius: 20px;">
        <div class="row">
            <div class="col-md-4">
                <h4>Politeknik Manufaktur Astra</h4>
                <hr />

                <p>Polman Astra adalah sebuah lembaga pendidikan di bawah naungan Yayasan Astra Bina Ilmu (YABI), merupakan salah satu anak perusahaan PT Astra International, Tbk. Polman Astra berlokasi di Komplek Astra International, Tbk., Jalan Gaya Motor Raya no.8, Sunter II, Jakarta Utara, Jakarta 14330.</p><br>

                <h4>Lulusan Polman Astra</h4>
                <hr />
                <img src="/assets/image/alumni.jpg" style="width: 100%"><br><br><br>
            </div>

            <div class="col-md-8">
                <h4>Registrasi Tracer Study</h4>
                <hr />
                <div class="row">
                    <div class="col-md-4">
                        <div class="form-group">
                            <label for="txtNIM">
                                Nomor Induk Mahasiswa (NIM)
                                <span style="color: red;">*</span>
                            </label>
                            <asp:TextBox MaxLength="10" runat="server" ID="tbNIM" cssclass="form-control" />
                        </div>                        

                        <div class="form-group">
                            <label for="txtNama">
                                Nama
                                <span style="color: red;">*</span>
                            </label>
                            <asp:TextBox MaxLength="100" runat="server" ID="tbNama" cssclass="form-control" />
                        </div>
                        <div class="form-group">
                            <label for="txtNIK">
                                Nomor Induk Kependudukan (NIK)
                                <span style="color: red;">*</span>
                            </label>
                            <asp:TextBox MaxLength="16" runat="server" ID="tbNIK" cssclass="form-control" />
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="form-group">
                            <label for="txtTanggalLahir">
                                Tanggal Lahir
                                <span style="color: red;">*</span>
                            </label>
                            <asp:TextBox type="date" runat="server" ID="tbTanggalLahir" CssClass="form-control" />
                        </div>

                        <div class="form-group">
                            <label for="txtTahunLulus">
                                Tahun Lulus
                                <span style="color: red;">*</span>
                            </label>
                            <asp:DropDownList runat="server" ID="ddlTahunLulus" CssClass="form-control">
                            </asp:DropDownList>                            
                        </div>

                        <div class="form-group">
                            <label for="txtTelepon">
                                Nomor Telepon
                                <span style="color: red;">*</span>
                            </label>
                            <asp:TextBox MaxLength="13" runat="server" ID="tbTelepon" cssclass="form-control" />
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="form-group">
                            <label for="txtEmail">
                                Email
                                <span style="color: red;">*</span>
                            </label>
                            <asp:TextBox MaxLength="100" runat="server" ID="tbEmail" type="email" cssclass="form-control" />
                        </div>

                        <div class="form-group">
                            <label for="txtPassword">
                                Password
                                <span style="color: red;">*</span>
                            </label>
                            <asp:TextBox MaxLength="50" type="password" runat="server" ID="tbPassword" cssclass="form-control" />
                        </div>

                        <div class="form-group">
                            <label for="txtKonfirmasiPassword">
                                Konfirmasi Password
                                <span style="color: red;">*</span>
                            </label>
                            <asp:TextBox MaxLength="50" type="password" runat="server" ID="tbKonfirmasiPassword" cssclass="form-control" />
                        </div>
                    </div>

                    <div class="col-md-12">
                        <div class="form-group">
                            <label for="txtAlamat">
                                Alamat
                                <span style="color: red;">*</span>
                            </label>
                            <asp:TextBox runat="server" ID="tbAlamat" cssclass="form-control" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <asp:Button id="btnDaftar" runat="server" onclick="btnDaftar_Click" class="btn btn-primary" style="width: 100%; margin-top: 10px; margin-bottom: 10px;" Text="Daftar" /><br />
        <span style="margin-top: 20px; padding-bottom: 20px;">Kembali untuk <a href='/'>Login</a>.</span>
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

        <%--var date
        var ddl = document.getElementById('<%= ddlTahunLulus.ClientID %>');
        var option;

        option = document.createElement("option");
        option.innerHTML = "-- Pilih Tahun Lulus --";
        option.selected;
        option.disabled;
        ddl.append(option);

        for (var i = 1; i <= 3; i++) {            
            date = new Date().getFullYear() - i;

            option = document.createElement("option");
            option.value = date;
            option.innerHTML = date;

            ddl.append(option);
        }--%>
    </script>
</asp:Content>