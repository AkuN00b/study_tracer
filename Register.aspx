<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Template_Login.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="study_tracer.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Register - Tracer Study</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid p-4" style="height: 518px; overflow:auto; background-color: white; border-radius: 10px;">
        <div class="row">
            <div class="col-md-3">
                <h4>Politeknik Manufaktur Astra</h4>
                <hr />

                <p>Polman Astra adalah sebuah lembaga pendidikan di bawah naungan Yayasan Astra Bina Ilmu (YABI), merupakan salah satu anak perusahaan PT Astra International, Tbk. Polman Astra berlokasi di Komplek Astra International, Tbk., Jalan Gaya Motor Raya no.8, Sunter II, Jakarta Utara, Jakarta 14330.</p><br>

                <h4>Lulusan Polman Astra</h4>
                <hr />
                <img src="/assets/image/alumni.jpg" style="width: 100%"><br><br><br>
            </div>

            <div class="col-md-9">
                <h4>Registrasi Tracer Study</h4>
                <hr />
                <div class="row">
                    <div class="col-md-4">
                        <div class="form-group">
                            <label for="txtNIM">
                                Nomor Induk Mahasiswa (NIM)
                                <span style="color: red;">*</span>
                            </label>
                            <input type="text" name="txtNIM" class="form-control">
                        </div>

                        <div class="form-group">
                            <label for="txtNIK">
                                Nomor Induk Kependudukan (NIK)
                                <span style="color: red;">*</span>
                            </label>
                            <input type="text" name="txtNIK" class="form-control">
                        </div>

                        <div class="form-group">
                            <label for="txtNama">
                                Nama
                                <span style="color: red;">*</span>
                            </label>
                            <input type="text" name="txtNama" class="form-control">
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="form-group">
                            <label for="txtAlamat">
                                Alamat
                                <span style="color: red;">*</span>
                            </label>
                            <input type="text" name="txtAlamat" class="form-control">
                        </div>

                        <div class="form-group">
                            <label for="txtTanggalLahir">
                                Tanggal Lahir
                                <span style="color: red;">*</span>
                            </label>
                            <input type="date" name="txtTanggalLahir" class="form-control">
                        </div>

                        <div class="form-group">
                            <label for="txtTahunLulus">
                                Tahun Lulus
                                <span style="color: red;">*</span>
                            </label>
                            <select class="form-control" name="txtTahunLulus">
                                <option value="2022">2022</option>
                                <option value="2021">2021</option>
                                <option value="2020">2020</option>
                            </select>
                        </div>
                    </div>

                    <div class="col-md-4">
                        <div class="form-group">
                            <label for="txtEmail">
                                Email
                                <span style="color: red;">*</span>
                            </label>
                            <input type="email" name="txtEmail" class="form-control">
                        </div>

                        <div class="form-group">
                            <label for="txtPassword">
                                Password
                                <span style="color: red;">*</span>
                            </label>
                            <input type="password" name="txtPassword" class="form-control">
                        </div>

                        <div class="form-group">
                            <label for="txtTelepon">
                                Nomor Telepon
                                <span style="color: red;">*</span>
                            </label>
                            <input type="number" name="txtTelepon" class="form-control">
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <button id="btnLogin" class="btn btn-primary" style="width: 100%; margin-top: 10px; margin-bottom: 10px;">Masuk</button><br />
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
    </script>
</asp:Content>