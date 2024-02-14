<%@ Page Title="" Language="C#" MasterPageFile="~/Makina.Master" AutoEventWireup="true" CodeBehind="404.aspx.cs" Inherits="SifirGibiMakina.Hata" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
  <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="error-page py-6">
                        <i class="fas fa-exclamation-circle fa-5x"></i>
                        <h4>Sayfa Bulunamadı!</h4>
                        <p>Aradığınız sayfa bulunamamıştır. <br> Lütfen kontrol edip tekrar deneyin. <br> (Hata kodu: 404)</p>
                        <button class="btn btn-success px-5">Anasayfa</button>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
